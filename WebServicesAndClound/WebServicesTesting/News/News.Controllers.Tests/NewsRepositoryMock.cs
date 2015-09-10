using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Controllers.Tests
{
    internal class NewsRepositoryMock : IRepository<News.Models.News>
    {  
        public NewsRepositoryMock()
        {
            this.News = new List<News.Models.News>();
        }

        public IList<News.Models.News> News { get; set; }

        public bool IsSaved { get; set; }

        public News.Models.News Add (News.Models.News entity)
        {
            if (this.News.Count == 0)
            {
                entity.Id = 1;
            }
            else
            {
                int lastId = this.News
                    .OrderByDescending(n => n.Id)
                    .Select(n => n.Id)
                    .First();
                entity.Id = lastId + 1;
            }
            
            this.News.Add(entity);
            return entity;
        }

        public News.Models.News Find (int id)
        {
            var news = this.News.Where(n => n.Id == id).FirstOrDefault();
            return news;
        }

        public IQueryable<News.Models.News> All()
        {
            return this.News.AsQueryable<News.Models.News>();
        }

        public void Delete(News.Models.News entity)
        {
            this.News.Remove(entity);
        }

        public void Update (News.Models.News entity)
        {
            var entityInBase = this.Find(entity.Id);
            int index = this.News.IndexOf(entityInBase);
            this.News[index] = entity;
        }

        public void SaveChanges()
        {
            this.IsSaved = true;
        }
    }
}