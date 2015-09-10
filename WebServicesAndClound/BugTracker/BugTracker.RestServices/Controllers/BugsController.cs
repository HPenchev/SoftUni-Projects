using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BugTracker.Data;
using BugTracker.Data.Models;
using BugTracker.RestServices.Models;
using Microsoft.AspNet.Identity;
using BugTracker.Data.Models.Enumerations;

namespace BugTracker.RestServices.Controllers
{
    [RoutePrefix("api")]
    public class BugsController : BaseApiController
    {
        public BugsController()
            : base() { }

        public BugsController(IBugTrackerData data)
            : base(data) { }

        [HttpGet]
        [Route("bugs")]
        public IQueryable<BugBaseViewModel> ListAllBugs()
        {
            var bugs = this.Data.Bugs.All()
                .OrderByDescending(b => b.PublishDate)
                .Select(b => new BugBaseViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Status = b.Status.ToString(),
                    Description = b.Description,
                    Authror = b.Author == null ? null : b.Author.UserName,
                    DateCreated = b.PublishDate
                });

            return bugs;
        }

        [HttpGet]
        [Route("bugs/{id}")]
        public IHttpActionResult GetBugById([FromUri]int id)
        {
            var bug = this.Data.Bugs.Find(id);

            if (bug == null)
            {
                return this.NotFound();
            }

            var result = new BugDetailedViewModel()
            {
                Id = bug.Id,
                Title = bug.Title,
                Description = bug.Description,
                Authror = bug.Author == null ? null : bug.Author.UserName,
                Status = bug.Status.ToString(),
                DateCreated = bug.PublishDate
            };

            var comments = bug.Comments
                .OrderByDescending(c => c.PublishDate)
                .Select(c => new CommentViewModel
                {
                    Id = c.Id,
                    Text = c.Text,
                    Author = c.Author == null ? null : c.Author.UserName,
                    DateCreated = c.PublishDate
                })
                .ToList();


            result.Comments = comments;

            var context = new BugTrackerDbContext();
            var testcommentsFromDb = context.Comments;
            var testComments = this.Data.Comments.All();

            return this.Ok(result);
        }

        [HttpPost]
        [Route("bugs")]
        public IHttpActionResult PostBug([FromBody]BugBindingModel bugModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var userId = this.User.Identity.GetUserId();
            User user = null;    

            if (userId != null)
            {
                user = this.Data.Users.Find(userId);
            }

            var bug = new Bug()
            {
                Title = bugModel.Title,
                Description = bugModel.Description,
                Author = user,
                Status = BugStatus.Open,
                PublishDate = DateTime.Now
            };

            this.Data.Bugs.Add(bug);
            this.Data.SaveChanges();

            if (user == null)
            {
                return this.CreatedAtRoute(
                    "DefaultApi",
                    new { id = bug.Id, controller = "bugs" },
                    new { bug.Id, Message = "Anonymous bug submitted." });
            }

            return this.CreatedAtRoute(
                    "DefaultApi",
                    new { id = bug.Id, controller = "bugs" },
                    new { bug.Id, Author = User.Identity.GetUserName(), Message = "User bug submitted." });
        }

        [HttpPatch]
        [Route("bugs/{id}")]
        public IHttpActionResult EditBug(
            [FromBody] BugPatchBindingModel bugModel,
            [FromUri]int id)
        {
            if (bugModel == null)
            {
                return this.BadRequest("Bug data required");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            if (bugModel.Status.ToLower() != null &&
                bugModel.Status.ToLower() != "open" &&
                bugModel.Status.ToLower() != "inprogress" &&
                bugModel.Status.ToLower() != "fixed" &&
                bugModel.Status.ToLower() != "closed")
            {
                return this.BadRequest("Invalid model state");
            }

            var bug = this.Data.Bugs.Find(id);

            if (bug == null)
            {
                return this.NotFound();
            }

            if (bugModel.Title != null)
            {
                bug.Title = bugModel.Title;
            }

            if (bugModel.Description != null)
            {
                bug.Description = bugModel.Description;
            }

            if (bugModel.Status != null)
            {
                bug.Status = (BugStatus)Enum.Parse(typeof(BugStatus), bugModel.Status, true);
            }

            this.Data.Bugs.Update(bug);
            this.Data.SaveChanges();

            return this.Ok(new
                {
                    Message = "Bug #" + bug.Id + " patched."
                });
        }

        [HttpDelete]
        [Route("bugs/{id}")]
        public IHttpActionResult DeleteBug([FromUri]int id)
        {
            var bug = this.Data.Bugs.Find(id);

            if (bug == null)
            {
                return this.NotFound();
            }

            var comments = bug.Comments.ToList();

            foreach (var comment in comments)
            {
                this.Data.Comments.Delete(comment);
            }

            this.Data.Bugs.Delete(bug);

            this.Data.SaveChanges();

            return this.Ok(new
                {
                    Message = "Bug #" + bug.Id + " successfully deleted."
                });
        }

        [Route("bugs/filter")]
        [HttpGet]
        public IQueryable<BugBaseViewModel> ListBugsByFilter(
            [FromUri]string keyword = null,
            [FromUri]string statuses = null,
            [FromUri]string author = null)
        {
            var bugs = this.ListAllBugs();

            if (keyword != null)
            {
                bugs = bugs.Where(b => b.Title.ToLower().Contains(keyword.ToLower()));
            }

            if (statuses != null)
            {
                bugs = 
                    bugs.Where(b => statuses.ToLower().Contains(b.Status.ToString().ToLower()));
            }

            if (author != null)
            {
                bugs = bugs.Where(b => b.Authror == author);
            }

            return bugs;
        }

        [HttpGet]
        [Route("bugs/{id}/comments")]
        public IHttpActionResult GetCommentsForAGivenBug([FromUri]int id)
        {
            var bug = this.Data.Bugs.Find(id);

            if (bug == null)
            {
                return this.NotFound();
            }

            var comments = bug.Comments
                .OrderByDescending(c => c.PublishDate)
                .Select(c => new CommentViewModel
                {
                    Id = c.Id,
                    Text = c.Text,
                    DateCreated = c.PublishDate,
                    Author = c.Author == null ? null : c.Author.UserName
                });

            return this.Ok(comments);
        }

        [HttpPost]
        [Route("bugs/{id}/comments")]
        public IHttpActionResult PostAComment(
            [FromUri]int id, 
            [FromBody]CommentBindingModel commentModel)
        {
            if (commentModel == null)
            {
                return this.BadRequest("Comment data is required");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var bug = this.Data.Bugs.Find(id);

            if (bug == null)
            {
                return this.NotFound();
            }

            var userId = this.User.Identity.GetUserId();
            User user = null;
            if (userId != null)
            {
                user = this.Data.Users.Find(id);
            }

            var comment = new Comment()
            {
                Text = commentModel.Text,
                PublishDate = DateTime.Now,
                Author = user,
                BugId = bug.Id,
                Bug = bug
            };

            bug.Comments.Add(comment);

            this.Data.Comments.Add(comment);
            this.Data.Bugs.Update(bug);
            this.Data.SaveChanges();

            if (user == null)
            {
                return this.Ok(new
                {
                    Id = comment.Id,
                    Message = "Added anonimous comment for bug #" + bug.Id
                });
            }

            return this.Ok(new
                {
                    Id = comment.Id,
                    Author = user.UserName,
                    Message = "User comment added for bug #" + bug.Id
                });
        }
    }
}