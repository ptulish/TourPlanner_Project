using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TourPlanner_Project.MVVM.Model
{
    public class Tour
    {
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
                EstimatedTime = 3600,
                Information = newTourInformation
            };

            return tour;
        }
    }

}
