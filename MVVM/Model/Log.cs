using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Converters;
using System.Collections.ObjectModel;

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
            Log newLog = new Log
            {
                TourId = tourId,
                TourDate = date, 
                Comment = comment,
                Difficulty = difficulty,
                TotalDistance = totalDistance,
                TotalTime = totalTime,
                Rating = rating
            };
            using (var context = new ApplicationContext())
            {
                context.Logs.Add(newLog);
                context.SaveChanges();
            }
            return newLog;
        }
        public static List<Log> GetLogs(int tourId)
        {
            List<Log> Logs = new List<Log>();
            using (ApplicationContext context = new ApplicationContext())
            {
                bool exists = context.Logs.Any(log => log.TourId == tourId);

                var logs = context.Logs.Where(log => log.TourId == tourId).ToList();


                if (logs.Count > 0)
                {
                    foreach (var log in logs)
                    {
                        Logs.Add(log);
                    }
                }
                else
                {
                    Logs = new List<Log>();
                }
            }
            return Logs;
        }
    }
}
