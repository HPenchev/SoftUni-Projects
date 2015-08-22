using BookStoreService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStoreService.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private BookShopEntities context = new BookShopEntities();

        [HttpGet]
        [Route("{username}/purchases")]
        public IHttpActionResult GetUserPurchases(string username)
        {
            var user = context.Users.Where(u => u.UserName == username).FirstOrDefault();
            if (user == null)
            {
                return this.BadRequest(string.Format("No user {0} in database", username));
            }

            return this.Ok(new UserPurchasesViewModel(user));
        }
    }
}
