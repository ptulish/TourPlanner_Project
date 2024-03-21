using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Converters;

namespace TourPlanner_Project.MVVM.Model
{
    public class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TourId { get; set; }
        public DateTimeOffset TourDate { get; set; }
        public string Comment {  get; set; }
        public int Difficulty { get; set; }
        public double TotalDistance { get; set; }
        public int TotalTime { get; set; }
        public int Rating {  get; set; }

        public static Log CreateLog(int tourId, DateTimeOffset date, string comment, int difficulty, double totalDistance, int totalTime, int rating)
        {
            return new Log
            {
                TourId = tourId,
                TourDate = date, 
                Comment = comment,
                Difficulty = difficulty,
                TotalDistance = totalDistance,
                TotalTime = totalTime,
                Rating = rating
            };
        }
    }
}
