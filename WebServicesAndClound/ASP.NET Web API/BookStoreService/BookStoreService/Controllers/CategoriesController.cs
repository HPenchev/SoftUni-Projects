using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using BookStoreService.Models;

namespace BookStoreService.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        private BookShopEntities context = new BookShopEntities();

        [HttpGet]
        [EnableQuery]
        public IQueryable<CategoryViewModel> GetCategories()
        {
            var categories = context.Categories.Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                });

            return categories;
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetCategory([FromUri]int id)
        {
            var category = context.Categories
                .Where(c => c.Id == id)
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .FirstOrDefault();

            if (category == null)
            {
                return this.BadRequest("Invalid category Id");
            }

            return this.Ok(category);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult EditCategory([FromUri]int id, [FromBody]CategoryBindingModel category)
        {
            var dbCategory = context.Categories.Find(id);
            if (dbCategory == null)
            {
                return this.BadRequest("Invalid category ID");
            }

            dbCategory.Name = category.Name;

            context.SaveChanges();
            return this.Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteCategory([FromUri]int id)
        {
            var category = context.Categories.Find(id);
            if (category == null)
            {
                return this.BadRequest("Invalid category Id");
            }

            context.Categories.Remove(category);
            context.SaveChanges();
            return this.Ok();
        }

        [HttpPost]
        public IHttpActionResult AddCategory([FromBody]CategoryBindingModel category)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            if (context.Categories.Any(c => c.Name == category.Name))
            {
                return this.BadRequest("Category already exists");
            }

            Category newCategory = new Category()
            {
                Name = category.Name
            };

            context.Categories.Add(newCategory);
            context.SaveChanges();
            return this.Ok(new CategoryViewModel(newCategory));
        }
    }
}
