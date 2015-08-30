using System;
using System.Data.Entity;
using System.Linq;
using EntityFramework.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using News.Data;
using News.Models;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace News.Repositories.Tests
{
    [TestClass]
    public class NewsRepositoryTests
    {
        private NewsEntities context;

        [AssemblyInitialize]
        public static void InitializeDatabase(TestContext testContext)
        {
            var context = new NewsEntities();
            context.Database.CreateIfNotExists();
        }

        [TestInitialize]
        public void SeedDatabase()
        {
            var context = new NewsEntities();
            context.News.Delete();

            context.News.Add(new News.Models.News()
                {
                    Title = "News1",
                    Content = "Content1",
                    PublishDate = DateTime.Parse("20.01.2015")
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

        [TestMethod]
        public void ListAllItems_WhenListedCorrectly_ShouldReturnAllItems()
        {
            var repo = new NewsRepository(new NewsEntities());
            var news = repo.All();

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
        public void InsertNews_WhenInsertedCorrectly_ShouldReturnNews()
        {
            var repo = new NewsRepository(new NewsEntities());
            var news = new News.Models.News()
            {
                Title = "TestNews",
                Content = "TestNewsContent",
                PublishDate = new DateTime(2015, 05, 10)
            };

            repo.Add(news);
            repo.SaveChanges();

            var newsFromDb = repo.Find(news.Id);

            Assert.AreEqual(4, repo.All().Count());
            Assert.AreEqual(news.Title, newsFromDb.Title);
            Assert.AreEqual(news.Content, newsFromDb.Content);
            Assert.AreEqual(news.PublishDate.ToShortDateString(),
                newsFromDb.PublishDate.ToShortDateString());
            Assert.AreNotEqual(0, newsFromDb.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void AddNews_WhenNewsIsInvalid_ShouldThrowException()
        {
            var repo = new NewsRepository(new NewsEntities());
            var news = new News.Models.News()
            {
                Content = "TestNewsContent",
                PublishDate = new DateTime(2015, 05, 10)
            };

            repo.Add(news);
            repo.SaveChanges();
        }

        [TestMethod]
        public void UpdateNews_WhenNewsIsValid_ShouldUpdateNews()
        {
            var repo = new NewsRepository(new NewsEntities());
            var news = repo.All().Where(n => n.Title == "News1").FirstOrDefault();

            news.Title = "Azis e...folkpevets";
            repo.Update(news);
            repo.SaveChanges();

            var newsFromRepo = repo.Find(news.Id);

            Assert.AreEqual(newsFromRepo.Title, "Azis e...folkpevets");
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void UpdateNews_WhenNewsIsInvalid_ShouldThrowException()
        {
            var repo = new NewsRepository(new NewsEntities());
            var news = repo.All().Where(n => n.Title == "News1").FirstOrDefault();

            news.Content = null;
            repo.Update(news);
            repo.SaveChanges();
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateConcurrencyException))]
        public void UpdateNews_WhenNewsIsNonExisting_ShouldThrowException()
        {
            var repo = new NewsRepository(new NewsEntities());
            var news = new News.Models.News
            {
                Title = "title",
                Content = "content",
                PublishDate = DateTime.Now
            };

            repo.Update(news);
            repo.SaveChanges();
        }

        [TestMethod]
        public void DeleteNews_WhenNewsIsValid_ShouldDeleteNews()
        {
            var repo = new NewsRepository(new NewsEntities());
            var news = repo.All().Where(n => n.Title == "News1").FirstOrDefault();

            repo.Delete(news);
            repo.SaveChanges();

            var newsFromRepo = repo.Find(news.Id);

            Assert.AreEqual(null, newsFromRepo);
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateConcurrencyException))]
        public void DeleteNews_WhenNewsIsNonExisting_ShouldThrowException()
        {
            var repo = new NewsRepository(new NewsEntities());
            var news = new News.Models.News
            {
                Title = "title",
                Content = "content",
                PublishDate = DateTime.Now
            };

            repo.Delete(news);
            repo.SaveChanges();
        }
    }
}