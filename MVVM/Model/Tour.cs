using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
using System.Collections.ObjectModel;

namespace TourPlanner_Project.MVVM.Model
{
    public class Tour
    {
        public Tour(Tour value)
        {
            Tour tour = value;
            tour.Logs = Log.GetLogs(value.Id);
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
        public double Rating { get; set; }

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
                Logs = new List<Log>(),
                Rating = 8.7
            };

            return tour;
        }
        private static List<Log> GetLogs(string newTourName)
        {
            throw new NotImplementedException();
        }


    }

}
