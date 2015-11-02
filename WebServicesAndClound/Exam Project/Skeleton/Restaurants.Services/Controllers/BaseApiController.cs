using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Restaurants.Data;

namespace Restaurants.Services.Controllers
{
    public class BaseApiController : ApiController
    {
        public BaseApiController()
            : this(new RestaurantsData(new RestaurantsContext()))
        {
        }

        public BaseApiController(IRestaurantsData data)
        {
            this.Data = data;
        }

        protected IRestaurantsData Data { get; set; }
    }
}