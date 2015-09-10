using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BugTracker.Data;

namespace BugTracker.RestServices.Controllers
{
    public class BaseApiController : ApiController
    {
        public BaseApiController()
            : this(new BugTrackerData(new BugTrackerDbContext()))
        {
        }

        public BaseApiController(IBugTrackerData data)
        {
            this.Data = data;
        }

        protected IBugTrackerData Data { get; set; }
    }
}