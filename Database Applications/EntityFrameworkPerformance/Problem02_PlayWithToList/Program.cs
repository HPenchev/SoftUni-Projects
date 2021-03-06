﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem02_PlayWithToList
{
    class Program
    {
        static void Main()
        {
            var context = new AdsEntities();
            
            long time = SlowOrder(context);
            Console.WriteLine(time);

            time = FastOrder(context);
            Console.WriteLine(time);       

            Console.ReadLine();
        }

        public static long SlowOrder(AdsEntities context)
        {
            context.Database.SqlQuery<string>("CHECKPOINT");
            context.Database.SqlQuery<string>("DBCC DROPCLEANBUFFERS");
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var sortedAds = context.Ads
                .ToList()
                .Where(a => a.AdStatus.Status == "Published")
                .Select(a => new
                             {
                                 a.Title,
                                 Category = a.Category != null ? a.Category.Name : null,
                                 Town = a.Town != null ? a.Town.Name : null,
                                 Date = a.Date
                             })
                .ToList()
                .OrderBy(a => a.Date);
            long time = stopWatch.ElapsedMilliseconds;
            return time;
        }

        public static long FastOrder(AdsEntities context)
        {
            context.Database.SqlQuery<string>("CHECKPOINT");
            context.Database.SqlQuery<string>("DBCC DROPCLEANBUFFERS");
            context.SaveChanges();
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var sortedAds = context.Ads                
                .Where(a => a.AdStatus.Status == "Published")
                .OrderBy(a => a.Date)
                .Select(a => new
                {
                    a.Title,
                    Category = a.Category != null ? a.Category.Name : null,
                    Town = a.Town != null ? a.Town.Name : null,
                    Date = a.Date
                })
                .ToList();            
            long time = stopWatch.ElapsedMilliseconds;
            return time;
        }
    }
}
