using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner_Project.MVVM.Model
{
    public static class DataWorker
    {   
        public static List<Tour> Tours = new List<Tour>();

        public static Tour SelectedTour { get; internal set; }

        internal static void DeleteTour(int id)
        {
            using (var context = new ApplicationContext())
            {
                // Поиск записи по ID
                var tour = context.Tours.Find(id);
                // Можно использовать FirstOrDefault вместо Find, если по какой-то причине Find недоступен:
                // var tour = context.Tours.FirstOrDefault(t => t.Id == tourIdToDelete);

                if (tour != null)
                {
                    // Удаление найденной записи из контекста
                    context.Tours.Remove(tour);

                    // Сохранение изменений в базе данных
                    context.SaveChanges();
                }
            }
        }

        internal static List<Tour> GetTours()
        {
            using (var context = new ApplicationContext())
            {
                Tours = context.Tours.ToList();
            }
            return Tours;
        }
        internal static void RefreshTours()
        {
            using (var context = new ApplicationContext())
            {
                Tours = new List<Tour>(context.Tours.ToList());
            }
        }
    }
}
