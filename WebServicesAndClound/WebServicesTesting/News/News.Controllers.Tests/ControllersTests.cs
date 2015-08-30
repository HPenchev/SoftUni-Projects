using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using News.Services.Controllers;
using System.Web.Http.Routing;
using News.Services.Models;
using System.Threading;

namespace News.Controllers.Tests
{
    [TestClass]
    public class ControllersTests
    {
        [TestMethod]
        public void ListAllNewsItems_WhenCorrect_ShouldReturnAllNewsItems()
        {
            var repo = CreateRepo();

            var controller = new NewsController(repo);

            var news = controller.GetAllNews();

            SetupController(controller, "news");            

            Assert.AreEqual(3, news.Count());

            var testedNews = news.Where(n => n.Title == "News1").FirstOrDefault();
            Assert.AreEqual("News1", testedNews.Title);
            Assert.AreEqual("Content1", testedNews.Content);
            Assert.AreEqual(new DateTime(2015, 1, 20).ToShortDateString(),
                testedNews.PublishDate.ToShortDateString());

            testedNews = news.Where(n => n.Title == "News2").FirstOrDefault();
            Assert.AreEqual("News2", testedNews.Title);
            Assert.AreEqual("Content2", testedNews.Content);
            Assert.AreEqual(new DateTime(2015, 1, 21).ToShortDateString(),
                testedNews.PublishDate.ToShortDateString());

            testedNews = news.Where(n => n.Title == "News3").FirstOrDefault();
            Assert.AreEqual("News3", testedNews.Title);
            Assert.AreEqual("Content3", testedNews.Content);
            Assert.AreEqual(new DateTime(2015, 1, 20).ToShortDateString(),
                testedNews.PublishDate.ToShortDateString());
        }

        [TestMethod]
        public void PostNews_WhenDataIsCorrect_ShouldReturnStatusCodeCreatedAndAddedNews()
        {
            var repo = CreateRepo();
            var controller = new NewsController(repo);
            SetupController(controller, "news");  
            var news = new NewsPostBindingModel()
            {
                Title = "News4",
                Content = "Content4",
                PublishDate = DateTime.Parse("22.01.2014")
            };

            var result = 
                controller.PostNews(news).ExecuteAsync(new CancellationToken()).Result;

            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);
            Assert.IsNotNull(result.Headers.Location);

            var resultContent = result.Content.ReadAsAsync<News.Models.News>().Result;
            Assert.AreEqual("News4", resultContent.Title);
            Assert.AreEqual("Content4", resultContent.Content);
            Assert.AreEqual(new DateTime(2014, 1, 22), resultContent.PublishDate);
            Assert.AreEqual(4, resultContent.Id);

            // Assert the repository values are correct
            Assert.AreEqual(4, repo.News.Count());
            var newsInRepo = repo.News[3];
            Assert.AreEqual("News4", newsInRepo.Title);
            Assert.AreEqual("Content4", newsInRepo.Content);
            Assert.AreEqual(new DateTime(2014, 1, 22), newsInRepo.PublishDate);
            Assert.AreEqual(4, newsInRepo.Id);
            Assert.IsTrue(repo.IsSaved);
        }

        [TestMethod]
        public void PostNews_WhenDataIsInvalid_ShouldReturnStatusCodeBadRequest()
        {
            var repo = CreateRepo();
            var controller = new NewsController(repo);
            SetupController(controller, "news");

            var news = new NewsPostBindingModel()
            {
                Content = "Content4",
                PublishDate = DateTime.Parse("22.01.2014")
            };

            var result =
                controller.PostNews(news).ExecuteAsync(new CancellationToken()).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.IsNotNull(result.Headers.Location);

            news = new NewsPostBindingModel()
            {
                Title = "News4",
                PublishDate = DateTime.Parse("22.01.2014")
            };

            result =
                controller.PostNews(news).ExecuteAsync(new CancellationToken()).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.IsNotNull(result.Headers.Location);

            news = new NewsPostBindingModel()
            {
                Title = "News4",
                Content = "Content4"
            };

            result =
                controller.PostNews(news).ExecuteAsync(new CancellationToken()).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.IsNotNull(result.Headers.Location);
        }

        private static NewsRepositoryMock CreateRepo()
        {
            var repo = new NewsRepositoryMock();

            repo.News.Add(new News.Models.News()
            {
                Id = 1,
                Title = "News1",
                Content = "Content1",
                PublishDate = DateTime.Parse("20.01.2015")
            });

            repo.News.Add(new News.Models.News()
            {
                Id = 2,
                Title = "News2",
                Content = "Content2",
                PublishDate = DateTime.Parse("21.01.2015")
            });

            repo.News.Add(new News.Models.News()
            {
                Id = 3,
                Title = "News3",
                Content = "Content3",
                PublishDate = DateTime.Parse("20.01.2015")
            });

            return repo;
        }

        private void SetupController(ApiController controller, string controllerName)
        {
            // Setup the Request object of the controller
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri("http://sample-url.com")
            };
            controller.Request = request;

            // Setup the configuration of the controller
            controller.Configuration = new HttpConfiguration();
            controller.Configuration.Routes.MapHttpRoute(
                name: "DefaultApi", routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            // Apply the routes to the controller
            controller.RequestContext.RouteData = new HttpRouteData(
                route: new HttpRoute(),
                values: new HttpRouteValueDictionary { { "controller", controllerName } });
        }
    }
}
