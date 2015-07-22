using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniEntity
{
    public static class DAO
    {
        private static SoftUniEntities context = new SoftUniEntities();

        public static void Add(Employee employee)
        {            
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public static Employee FindByKey(object key)
        {            
            return context.Employees.Find(key);
        }

        public static void Modify(Employee employee)
        {
            context.SaveChanges();         
        }

        public static void Delete(Employee employee)
        {            
            context.Employees.Remove(employee);
            context.SaveChanges();
        }
    }
}
