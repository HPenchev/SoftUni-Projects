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
            var stwatch = new Stopwatch();
            stwatch.Start();
            var context = new AdsEntities();
            long sum = 0L;
            long[] performanceMeasures = new long[10];

            for (int i = 0; i < 10; i++)
            {
                long time = TestSlowSelect(context);
                performanceMeasures[i] = time;
                sum += time;
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(performanceMeasures[i]);
            }

            Console.WriteLine("Average fast:" + (double)sum / 10);

            for (int i = 0; i < 100000; i++)
            {
                Console.WriteLine("Azis e pederas");
            }

            Console.WriteLine(stwatch.Elapsed);

            Console.ReadLine();
        }

        public static long TestSlowSelect(AdsEntities context)
        {
            context.Database.SqlQuery<string>("CHECKPOINT");
            context.Database.SqlQuery<string>("DBCC DROPCLEANBUFFERS");
            var stopWatch = new Stopwatch();

            var ads = context.Ads;

            foreach (var ad in ads)
            {
                Console.WriteLine(ad.Title);
            }

            long time = stopWatch.ElapsedMilliseconds;
            return time;
        }

    }
}
