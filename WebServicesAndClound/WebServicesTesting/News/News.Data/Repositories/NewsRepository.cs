using System.Data.Entity;
using System.Linq;
using News.Models;

public class NewsRepository : IRepository<News.Models.News>
{
    private readonly DbContext context;

    public NewsRepository(DbContext context)
    {
        this.context = context;
    }

    public News.Models.News Add(News.Models.News entity)
    {
        this.context.Set<News.Models.News>().Add(entity);
        return entity;
    }

    public IQueryable<News.Models.News> All()
    {
        return this.context.Set<News.Models.News>();
    }

    public void Delete(News.Models.News entity)
    {
        this.ChangeState(entity, EntityState.Deleted);
    }

    public void Update(News.Models.News entity)
    {
        this.ChangeState(entity, EntityState.Modified);
    }

    public void SaveChanges()
    {
        this.context.SaveChanges();
    }

    public News.Models.News Find(int id)
    {
        return this.context.Set<News.Models.News>().Find(id);
    }

    private void ChangeState(News.Models.News news, EntityState state)
    {
        var entry = this.context.Entry(news);
        if (entry.State == EntityState.Detached)
        {
            this.context.Set<News.Models.News>().Attach(news);
        }

        entry.State = state;
    }
}