using News.Data;
using News.Services.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace News.Services.Controllers
{
    [RoutePrefix("api/news")]
    public class NewsController : ApiController
    {
        private IRepository<News.Models.News> repo;

        public NewsController()
            : this(new NewsRepository(new NewsEntities())) {}

        public NewsController(IRepository<News.Models.News> repo)
        {
            this.repo = repo;
        }

        [HttpGet]        
        public IQueryable<News.Models.News> GetAllNews()
        {
            var news = this.repo.All().OrderByDescending(n => n.PublishDate);
            return news;
        }

        [HttpPost]
        public IHttpActionResult PostNews([FromBody]NewsPostBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var news = new News.Models.News()
            {
                Title = model.Title,
                Content = model.Content,
                PublishDate = model.PublishDate
            };

            news = this.repo.Add(news);
            this.repo.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = news.Id }, news);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateNews([FromUri]int id, [FromBody]NewsPostBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            
            var news = repo.Find(id);

            if (news == null)
            {
                return this.BadRequest("No news with id " + id);
            }

            news.Title = model.Title;
            news.Content = model.Content;
            news.PublishDate = model.PublishDate;

            repo.Update(news);
            repo.SaveChanges();

            return this.Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteNews([FromUri]int id)
        {
            var news = repo.Find(id);

            if (news == null)
            {
                return this.BadRequest("Invalid news id");
            }
            
            this.repo.Delete(news);
            this.repo.SaveChanges();

            return this.Ok();
        }
    }
}