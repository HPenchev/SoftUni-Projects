using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BugTracker.Data;
using BugTracker.RestServices.Models;

namespace BugTracker.RestServices.Controllers
{

    [RoutePrefix("api")]
    public class CommentsController : BaseApiController
    {
        public CommentsController()
            : base() { }

        public CommentsController(IBugTrackerData data)
            : base(data) { }

        [HttpGet]
        [Route("comments")]
        public IQueryable<CommentDetailedViewModel> GetAllComments()
        {
            var comments = this.Data.Comments.All()
                .OrderByDescending(c => c.PublishDate)
                .Select(c => new CommentDetailedViewModel()
                {
                    Id = c.Id,
                    Text = c.Text,
                    Author = c.Author == null ? null : c.Author.UserName,
                    DateCreated = c.PublishDate,
                    BugId = c.BugId,
                    BugTitle = c.Bug.Title
                });

            return comments;
        }
    }
}