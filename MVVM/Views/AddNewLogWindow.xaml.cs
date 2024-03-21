using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TourPlanner_Project.MVVM.Model;
using TourPlanner_Project.MVVM.ViewModel;

namespace TourPlanner_Project.MVVM.Views
{
    /// <summary>
    /// Interaction logic for AddNewLogWindow.xaml
    /// </summary>
    public partial class AddNewLogWindow : Window
    {
        private AddNewLogViewModel viewModel;

        public AddNewLogWindow(Tour selectedTour)
        {
            InitializeComponent();
            viewModel = new AddNewLogViewModel(selectedTour);
            this.DataContext = viewModel;
            viewModel.LogAddedSuccessfully += (sender, e) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    this.Close();
                });
            };
        }
    }
}
