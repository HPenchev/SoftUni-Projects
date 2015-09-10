using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTracker.Data.Models;
using BugTracker.Data.Repositories;

namespace BugTracker.Data
{
    public class BugTrackerData : IBugTrackerData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories = new Dictionary<Type, object>();

        public BugTrackerData(DbContext context)
        {
            this.context = context;
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Bug> Bugs
        {
            get
            {
                return this.GetRepository<Bug>();
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }
        
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        //public int SaveChangesAsync()
        //{
        //    return this.context.SaveChangesAsync();
        //}

        private IRepository<T> GetRepository<T>()
            where T : class
        {
            var type = typeof(T);

            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);
                var repository = Activator.CreateInstance(typeOfRepository, this.context);

                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}