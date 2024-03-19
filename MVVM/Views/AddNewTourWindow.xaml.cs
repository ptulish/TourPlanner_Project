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
using TourPlanner_Project.MVVM.ViewModel;

namespace TourPlanner_Project.MVVM.Views
{
    /// <summary>
    /// Interaction logic for AddNewTourWindow.xaml
    /// </summary>
    public partial class AddNewTourWindow : Window
    {
        private AddNewTourViewModel viewModel = new AddNewTourViewModel();
        public AddNewTourWindow()
        {
            InitializeComponent();
            this.DataContext = viewModel;
            viewModel.TourAddedSuccessfully += (sender, e) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    this.Close();
                });
            };
        }
       

    }
}
