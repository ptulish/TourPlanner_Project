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
    public class Logs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTimeOffset TourDate { get; set; }
        public string Comment {  get; set; }
        public int Difficulty { get; set; }
        public double TotalDistance { get; set; }
        public int TotalTime { get; set; }
        public int rating {  get; set; }
    }
}
