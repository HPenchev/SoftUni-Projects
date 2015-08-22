using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
//using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using System.Web.Script.Serialization;
using BookStoreService.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using BooksShopModels;

namespace BookStoreService.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private BookShopEntities context = new BookShopEntities();

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetBook(int id)
        {
            var book = this.context.Books
                .Where(b => b.Id == id)
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
                })
                .FirstOrDefault();

            if (book == null)
            {
                return this.BadRequest("Invalid book ID");
            }

            return this.Ok(book);
        }

        [HttpGet]
        [EnableQuery]        
        public IHttpActionResult SearchBooks([FromUri]string search)
        {            
            var books = context.Books
                .Where(b => b.Title.Contains(search) || b.Title.Contains(search))
                .Select(b => new {
                    id = b.Id,
                    Title = b.Title
                })
                .OrderBy(b => b.Title)
                .Take(10);

            return this.Ok(books);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateBook([FromUri] int id, [FromBody]BookUpdateBindingModel book)
        {            
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var dbBook = this.context.Books.Find(id);
            if (dbBook == null)
            {
                return this.BadRequest("Invalid book ID");
            }                      

            var js = new JavaScriptSerializer();
            var req = js.Deserialize<Dictionary<string, string>>(new StreamReader(HttpContext.Current.Request.InputStream).ReadToEnd());

            if (req.ContainsKey("Title") || req.ContainsKey("title"))
            {
                dbBook.Title = book.Title;
            }

            if (req.ContainsKey("Description") || req.ContainsKey("description"))
            {
                dbBook.Description = book.Description;
            }

            if (req.ContainsKey("Price") || req.ContainsKey("price"))
            {
                dbBook.Price = book.Price;
            }

            if (req.ContainsKey("Copies") || req.ContainsKey("copies"))
            {
                dbBook.Copies = book.Copies;
            }

            if (req.ContainsKey("Edition") || req.ContainsKey("edition"))
            {
                dbBook.Edition = book.Edition;
            }

            if (req.ContainsKey("ReleaseDate") || req.ContainsKey("releaseDate"))
            {
                dbBook.ReleaseDate = book.ReleaseDate;
            }

            if (req.ContainsKey("AgeRestriction") || req.ContainsKey("ageRestriction"))
            {
                dbBook.AgeRestriction = book.AgeRestriction;
            }

            if (req.ContainsKey("AuthorId ") || req.ContainsKey("authorId "))
            {
                dbBook.AuthorId = book.AuthorId;
            }

            context.SaveChanges();

            return this.Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteBook([FromUri]int id)
        {
            var book = this.context.Books.Find(id);

            if (book == null)
            {
                return this.BadRequest("Invalid book ID");
            }

            this.context.Books.Remove(book);
            context.SaveChanges();
            return this.Ok();
        }

        [HttpPost]
        public IHttpActionResult AddBook([FromBody]BookAddBindingModel book)
        {
            var author = context.Authors.Find(book.AuthorId);
            if (author == null)
            {
                return this.BadRequest("Invalid author Id");
            }

            var newBook = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                Price = book.Price,
                Copies = book.Copies,
                Edition = book.Edition,
                ReleaseDate = book.ReleaseDate,
                AuthorId = book.AuthorId,
                Author = author
            };

            string[] categories = book.Categories.Split(' ');

            foreach (string category in categories)
            {
                if (!context.Categories.Any(c => c.Name == category))
                {
                    return this.BadRequest("Invalid category name " + category);
                }

                newBook.Categories.Add(context.Categories.Where(c => c.Name == category).First());
            }

            context.Books.Add(newBook);
            context.SaveChanges();

            return this.Ok(new BookViewModel(newBook));
        }

        [Authorize]
        [HttpPut]
        [Route("buy/{id}")]
        public IHttpActionResult BuyBook(int id)
        {
            string userId = this.User.Identity.GetUserId();
            if (userId == null)
            {
                return this.Unauthorized();
            }

            var book = this.context.Books.Find(id);
            if (book == null)
            {
                return this.BadRequest("Invalid book ID");
            }

            if (book.Copies < 1)
            {
                return this.BadRequest("Not enough book copies");
            }

            book.Copies--;

            var purchase = new Purchase()
            {
                Price = book.Price,
                DateOfPurchase = DateTime.Now,
                BookId = book.Id,
                User = context.Users.Find(userId)
            };

            this.context.Purchases.Add(purchase);

            context.SaveChanges();
            return this.Ok();
        }

        [HttpPut]
        
        [Route("recall/{id}")]
        public IHttpActionResult RecallPurchase(int id)
        {
            var purchase = context.Purchases.Find(id);

            if(purchase == null)
            {
                return this.BadRequest("Invalid purchase ID");
            }
            
            if (( DateTime.Now - purchase.DateOfPurchase).Days >=30)
            {
                return this.BadRequest("Purchase can't be recalled in 30 or more days");
            }

            var book = context.Books.Find(purchase.BookId);

            if (book == null)
            {
                return this.BadRequest("No book found in database");
            }

            book.Copies++;
            purchase.IsRecalled = true;
            context.SaveChanges();
            return this.Ok();
        }
    }
}
