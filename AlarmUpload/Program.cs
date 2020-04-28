
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;


using AlarmUpload.DataAccess;

using AlarmUpload.Model;

namespace AlarmUpload
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            

            

            var FlatAlarms = ProcessFlatAlarms("PQF_RptAlarmCatalog_ver30.csv");



            // NewAlarms son aquellas cuyo idAlarm esta en 0 o vacio

           // var queryNewAlarms = FlatAlarms.Where(fa => fa.IdAlarm <= 0).ToList();

            foreach (var fa in FlatAlarms.Where(fa => fa!= null))
            {
                Console.WriteLine($"alarma para procesar {fa.IdAlarm}  {fa.Description}");

            }

            var queryNonNewAlarms = FlatAlarms.Where(a=> a.IdAlarm > 0);
            

            


            /* Console.ReadLine();

            
                       foreach (var fa in FlatAlarms.Where(fa => fa.IdAlarm > 0 ))
                       {

                           Console.WriteLine($"idAlarm {fa.IdAlarm} Severity {fa.SeverityCode: A20}  Description {fa.Description} Severity {fa.SeverityCode}");

                       } */
            
        }



        private static List<FlatAlarm> ProcessFlatAlarms(string FilePath)
        {
        
           return  File.ReadAllLines(FilePath).
            Skip(1).
            Where(Line => Line.Length > 1).
            Select(FlatAlarm.ParseFromCsv).ToList();
        }
    }
}
