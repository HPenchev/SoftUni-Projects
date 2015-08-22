using BookStoreService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;

namespace BookStoreService.Controllers
{
    [RoutePrefix("api/authors")]
    public class AuthorsController : ApiController
    {
        private BookShopEntities context = new BookShopEntities();

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetAuthor(int id)
        {
            var author = this.context.Authors
                .Where(a => a.Id == id)
                .Select(a => new
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName
                })
                .FirstOrDefault();

            if (author == null)
            {
                return this.BadRequest("Invalid author ID");
            }

            return this.Ok(new AuthorViewModel()
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName
            });
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]AuthorBindingModel author)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            Author newAuthor = new Author()
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName
                };
           
            this.context.Authors.Add(newAuthor);

            context.SaveChanges();

            return this.Ok(new AuthorViewModel(newAuthor));
        }

        [HttpGet]
        [EnableQuery]
        [Route("{id}/books")]
        public IHttpActionResult GetBooks(int id)
        {
            if (!context.Authors.Any(a => a.Id == id))
            {
                return this.BadRequest("Invalid author Id");
            }

            var books = this.context.Books
                .Where(b => b.Author.Id == id)
                .Select(b => new BookViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    Price = b.Price,
                    Copies = b.Copies,
                    Edition = b.Edition.ToString(),
                    ReleaseDate = b.ReleaseDate,
                    AgeRestriction = b.AgeRestriction.ToString(),
                    Author = new AuthorViewModel()
                    {
                        Id = b.Author.Id,
                        FirstName = b.Author.FirstName,
                        LastName = b.Author.LastName
                    },
                    Categories = b.Categories.Select(c => c.Name).ToList()
                });

            return this.Ok(books);
        }
    }
}