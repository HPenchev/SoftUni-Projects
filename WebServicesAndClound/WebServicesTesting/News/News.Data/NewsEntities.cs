using System;
using System.Data.Entity;
using System.Linq;

namespace News.Data
{
    public class NewsEntities : DbContext
    {
        public NewsEntities()
            : base("name=NewsEntities")
        {
            var migrationStrategy =
                new MigrateDatabaseToLatestVersion<NewsEntities, Configuration>();
            Database.SetInitializer(migrationStrategy);
        }

        public IDbSet<News.Models.News> News { get; set; }
    }
}