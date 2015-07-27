using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem03_SelectEverVsSelectCertain
{
    class Program
    {
        static void Main()
        {            
            var context = new AdsEntities();
                   
            //long time = TestSlowSelect(context);
            //Console.WriteLine(time);

            long time = TestSlowSelect(context);
            Console.WriteLine(time);

            Console.ReadLine();
        }

        public static long TestSlowSelect(AdsEntities context)
        {
            context.Database.SqlQuery<string>("CHECKPOINT");
            context.Database.SqlQuery<string>("DBCC DROPCLEANBUFFERS");
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var ads = context.Ads;

            foreach (var ad in ads)
            {
                Console.WriteLine(ad.Title);
            }

            long time = stopWatch.ElapsedMilliseconds;
            return time;
        }

        public static long TestFastSelect(AdsEntities context)
        {
            context.Database.SqlQuery<string>("CHECKPOINT");
            context.Database.SqlQuery<string>("DBCC DROPCLEANBUFFERS");
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var ads = context.Ads
                .Select(a => a.Title);

            foreach (var ad in ads)
            {
                Console.WriteLine(ad);
            }

            long time = stopWatch.ElapsedMilliseconds;
            return time;
        }
    }
}
