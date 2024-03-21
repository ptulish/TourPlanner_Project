using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace TourPlanner_Project.MVVM.Model
{
    public class Tour
    {
        public Tour(Tour value)
        {
            Tour tour = value;
            using (ApplicationContext context = new ApplicationContext())
            {
                bool exists = context.Logs.Any(log => log.TourId == tour.Id);

                var logs = context.Logs.Where(log => log.TourId == tour.Id).ToList();

                
                if (logs.Count > 0)
                {
                    foreach (var log in logs)
                    {
                        tour.Logs.Add(log);
                    }
                } 
                else
                {
                    tour.Logs = new List<Log>();
                }
            }
        }
        public Tour()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string TransportType { get; set; }
        public double Distance { get; set; }
        public long EstimatedTime { get; set; }
        public string Information {  get; set; }
        public List<Log> Logs { get; set; }    

        internal static Tour CreateTour(string newTourName, string newTourFrom, string newTourTo, string newTourTransportType, string newTourInformation, string newTourDescription)
        {
            var tour = new Tour
            {
                Name = newTourName,
                Description = newTourDescription,
                From = newTourFrom,
                To = newTourTo,
                TransportType = newTourTransportType,
                Distance = 100,
                EstimatedTime = 3600 / 60,
                Information = newTourInformation,
                Logs = new List<Log>()
            };

            return tour;
        }
        private static List<Log> GetLogs(string newTourName)
        {
            throw new NotImplementedException();
        }


    }

}
