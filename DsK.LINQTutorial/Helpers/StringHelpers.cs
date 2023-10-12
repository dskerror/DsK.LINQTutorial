using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsK.LINQTutorial.Helpers
{
    public static class StringHelpers
    {
        public static Stopwatch stopwatch = new Stopwatch();
        
        public static void StartSection(this string sectionName)
        {
            stopwatch.Start();
            Console.WriteLine($"---START {sectionName}---");
        }

        public static void EndSection(this string sectionName)
        {
            stopwatch.Stop();
            var elapsed_time = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"---END {sectionName} : Time(ms) {elapsed_time}---");
            Console.WriteLine(Environment.NewLine);
            stopwatch.Reset();
        }

        public static void ShowQuery(this string query)
        {
            
            Console.WriteLine($"\t-START QUERY-");
            using (StringReader reader = new StringReader(query))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine($"\t{line}");
                }
            }
            
            Console.WriteLine($"\t-END QUERY-");
            Console.WriteLine(Environment.NewLine);
            stopwatch.Reset();
            stopwatch.Start();
        }
    }
}
