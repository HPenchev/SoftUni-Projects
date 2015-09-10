using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EntityFramework.Extensions;
using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using News.Services;
using Owin;
using News.Data;
using System.Globalization;

namespace News.IntegrationTests
{
    [TestClass]
    public class NewsIntegrationTests
    {
        private TestServer httpTestServer;
        private HttpClient httpClient;

        [TestInitialize]
        public void TestInit()
        {
            this.httpTestServer = TestServer.Create(appBuilder =>
            {
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);
                appBuilder.UseWebApi(config);
            });

            this.httpClient = httpTestServer.HttpClient;

            var context = new NewsEntities();
            context.Database.CreateIfNotExists();

            this.SeedDatabase();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.httpTestServer.Dispose();
        }

        [TestMethod]
        public void GetAllNews_ShouldReturnListOfNews()
        {
            var httpResponse = httpClient.GetAsync("/api/news").Result;
            var newsFromService = httpResponse
                .Content.ReadAsAsync<List<News.Models.News>>()
                .Result
                .OrderBy(n => n.Title)
                .ToList();

            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.AreEqual(httpResponse.Content.Headers.ContentType.MediaType, "application/json");
            Assert.AreEqual(3, newsFromService.Count);

            var context = new NewsEntities();
            var newsFromDatabase = context.News.OrderBy(n => n.Title).ToList();

            Assert.AreEqual(3, newsFromDatabase.Count);

            for (int i = 0; i < newsFromDatabase.Count; i++)
            {
                Assert.AreEqual(newsFromDatabase[i].Id, newsFromService[i].Id);
                Assert.AreEqual(newsFromDatabase[i].Title, newsFromService[i].Title);
                Assert.AreEqual(newsFromDatabase[i].Content, newsFromService[i].Content);
                Assert.AreEqual(newsFromDatabase[i].PublishDate, newsFromService[i].PublishDate);
            }
        }

        [TestMethod]
        public void PostNews_WhenDataIsValid_ShouldReturnStatusCodeCreatedAndNewsCreated()
        {
            var content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("title", "Test Title"),
                new KeyValuePair<string, string>("content", "Test content"),
                new KeyValuePair<string, string>("publishDate", "2015-08-30T00:00:00.0000000+00:00")
            });

            var httpResponse = httpClient.PostAsync("/api/news", content).Result;
            var newsFromService = httpResponse.Content.ReadAsAsync<News.Models.News>().Result;

            Assert.AreEqual(HttpStatusCode.Created, httpResponse.StatusCode);
            Assert.IsNotNull(httpResponse.Headers.Location);
            Assert.IsTrue(newsFromService.Id != 0);
            Assert.AreEqual(newsFromService.Title, "Test Title");
            Assert.AreEqual(newsFromService.Content, "Test content");
            Assert.AreEqual(newsFromService.PublishDate, 
                DateTime.Parse("2015-08-30T00:00:00.0000000+00:00"));

            var context = new NewsEntities();
            Assert.AreEqual(4, context.News.Count());
        }

        [TestMethod]
        public void PostNews_WhenDataIsInvalid_ShouldReturnStatusCodeBadRequest()
        {
            var content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("title", "Test Title"),
                new KeyValuePair<string, string>("publishDate", "2015-08-30T00:00:00.0000000+00:00")
            });

            var httpResponse = httpClient.PostAsync("/api/news", content).Result;
            var newsFromService = httpResponse.Content.ReadAsAsync<News.Models.News>().Result;

            var context = new NewsEntities();

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
            Assert.AreEqual(3, context.News.Count());

            content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("content", "Test content"),
                new KeyValuePair<string, string>("publishDate", "2015-08-30T00:00:00.0000000+00:00")
            });

            httpResponse = httpClient.PostAsync("/api/news", content).Result;
            newsFromService = httpResponse.Content.ReadAsAsync<News.Models.News>().Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
            Assert.AreEqual(3, context.News.Count());

            content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("title", "Test Title"),
                new KeyValuePair<string, string>("content", "Test content")
            });

            httpResponse = httpClient.PostAsync("/api/news", content).Result;
            newsFromService = httpResponse.Content.ReadAsAsync<News.Models.News>().Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
            Assert.AreEqual(3, context.News.Count());

            var addedNews = context.News.FirstOrDefault(n => n.Title == "TestTitle");
            Assert.IsNull(addedNews);
        }

        [TestMethod]
        public void UpdateNews_WhenDataIsValid_ShouldReturnStatusCodeOkAndUpdateNews()
        {
            var context = new NewsEntities();
            var newsToUpdate = context.News.FirstOrDefault(n => n.Title == "News1");
            
            var content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("title", "Updated Title"),
                new KeyValuePair<string, string>("content", "Updated content"),
                new KeyValuePair<string, string>("publishDate", 
                    newsToUpdate.PublishDate.ToString(CultureInfo.InvariantCulture))
            });

            var httpResponse = httpClient.PutAsync("/api/news/" + newsToUpdate.Id, content).Result;
            var newsFromService = httpResponse.Content.ReadAsAsync<News.Models.News>().Result;

            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);

            context = new NewsEntities();
            var newsFromDatabase = context.News.Find(newsToUpdate.Id);

            Assert.IsNotNull(newsFromDatabase);
            Assert.AreEqual("Updated Title",newsFromDatabase.Title);
            Assert.AreEqual("Updated content", newsFromDatabase.Content);
            Assert.AreEqual(new DateTime(2015, 12, 20, 12, 0, 0), newsFromDatabase.PublishDate);

            Assert.AreEqual(3, context.News.Count());
        }

        [TestMethod]
        public void UpdateNews_WhenDataIsInvalid_ShouldReturnStatusCodeBadRequestAndKeepOldData()
        {
            var context = new NewsEntities();
            var newsToUpdate = context.News.FirstOrDefault(n => n.Title == "News1");

            var content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("title", "Test Title"),
                new KeyValuePair<string, string>("publishDate", "2015-08-30T00:00:00.0000000+00:00")
            });

            string webServiceLink = "/api/news/" + newsToUpdate.Id;

            var httpResponse = httpClient.PutAsync(webServiceLink, content).Result;
            var newsFromService = httpResponse.Content.ReadAsAsync<News.Models.News>().Result;
            
            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);            

            content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("content", "Test content"),
                new KeyValuePair<string, string>("publishDate", "2015-08-30T00:00:00.0000000+00:00")
            });

            httpResponse = httpClient.PutAsync(webServiceLink, content).Result;
            newsFromService = httpResponse.Content.ReadAsAsync<News.Models.News>().Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
            
            content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("title", "Test Title"),
                new KeyValuePair<string, string>("content", "Test content")
            });

            httpResponse = httpClient.PutAsync(webServiceLink, content).Result;
            newsFromService = httpResponse.Content.ReadAsAsync<News.Models.News>().Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);

            context = new NewsEntities();
            var newsFromDatabase = context.News.Find(newsToUpdate.Id);

            Assert.IsNotNull(newsFromDatabase);
            Assert.AreEqual(newsToUpdate.Id, newsFromDatabase.Id);
            Assert.AreEqual(newsToUpdate.Title, newsFromDatabase.Title);
            Assert.AreEqual(newsToUpdate.Content, newsFromDatabase.Content);
            Assert.AreEqual(newsToUpdate.PublishDate, newsFromDatabase.PublishDate);
        }

        [TestMethod]
        public void DeleteNews_WhenDataIsValid_ShouldReturnStatusCodeOkAndDeleteNews()
        {
            var context = new NewsEntities();
            var newsToDeleteId = context.News
                .Where(n => n.Title == "News1")                
                .Select(n => n.Id)
                .FirstOrDefault();

            string webServiceLink = "/api/news/" + newsToDeleteId;

            var httpResponse = httpClient.DeleteAsync(webServiceLink).Result;
            var newsFromService = httpResponse.Content.ReadAsAsync<News.Models.News>().Result;

            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);

            context = new NewsEntities();
            Assert.AreEqual(2, context.News.Count());

            var deletedNews = context.News.FirstOrDefault(n => n.Title == "News1");
            Assert.IsNull(deletedNews);
        }

        [TestMethod]
        public void DeleteNews_WhenDataIsInvalid_ShouldReturnStatusCodeBadRequestAndNotDeleteNews()
        {
            var context = new NewsEntities();
            int invalidId = context.News
                .OrderByDescending(n => n.Id)
                .Select(n => n.Id)
                .FirstOrDefault() + 1;
            
            string webServiceLink = "/api/news/" + invalidId;

            var httpResponse = httpClient.DeleteAsync(webServiceLink).Result;
            var newsFromService = httpResponse.Content.ReadAsAsync<News.Models.News>().Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);

            context = new NewsEntities();
            Assert.AreEqual(3, context.News.Count());
        }

        private void SeedDatabase()
        {
            NewsEntities context = new NewsEntities();
            context.News.Delete();

            context.News.Add(new News.Models.News()
                {
                    Title = "News1",
                    Content = "Content1",
                    PublishDate = new DateTime(2015, 12, 20, 12, 0, 0)
                });

            context.News.Add(new News.Models.News()
            {
                Title = "News2",
                Content = "Content2",
                PublishDate = DateTime.Parse("21.01.2015")
            });

            context.News.Add(new News.Models.News()
            {
                Title = "News3",
                Content = "Content3",
                PublishDate = DateTime.Parse("20.01.2015")
            });

            context.SaveChanges();
        }
    }
}
