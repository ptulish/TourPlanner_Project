using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TourPlanner_Project.MVVM.Model;
using System.ComponentModel;
using TourPlanner_Project.MVVM.Views;
using System.Diagnostics;
using System.Windows;

namespace TourPlanner_Project.MVVM.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region VARIABLES
        private List<Tour> _tours = new List<Tour>();
        public List<Tour> Tours
        {
            get { return _tours; }
            set
            {
                _tours = value;
                OnPropertyChanged("Tours");
            }
        }
        private Tour _selectedTour;
        public Tour SelectedTour
        {
            get => _selectedTour;
            set
            {
                if(value != _selectedTour)
                {
                    DataWorker.SelectedTour = value;
                    _selectedTour = value;
                    OnPropertyChanged(nameof(SelectedTour));
                }
            }
        }

        public string GeneralTourName { get; set; }

        #endregion

        public MainWindowViewModel()
        {
            Tours = DataWorker.GetTours();
            if(Tours == null)
            {
                SelectedTour.Name = "Here will be Tour";
            }
            else
            {
                SelectedTour = Tours[0];
            }
        }


        #region COMMANDS TO OPEN NEW WINDOWS
        private RelayCommand openAddNewTourWindow;
        public RelayCommand OpenAddNewTourWindow
        {
            get
            {
                return openAddNewTourWindow ?? new RelayCommand(obj =>
                {
                    AddNewTourWindow newTourWindow = new AddNewTourWindow();
                    newTourWindow.ShowDialog();
                    Tours = DataWorker.GetTours();
                });
            }
        }

        private RelayCommand openAddNewLogWindow;
        public RelayCommand OpenAddNewLogWindow
        {
            get
            {
                return openAddNewLogWindow ?? new RelayCommand(obj =>
                {
                    AddNewLogWindow newLogWindow = new AddNewLogWindow(_selectedTour);
                    newLogWindow.ShowDialog();
                });
            }
        }
        private RelayCommand deleteSelectedTourWnd;
        public RelayCommand DeleteSelectedTourWnd
        {
            get
            {
                return deleteSelectedTourWnd ?? new RelayCommand(obj =>
                {
                    MessageBoxResult result = MessageBox.Show("Уверены ли вы?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        foreach(var tour in DataWorker.Tours)
                        {
                            if (tour.Id == SelectedTour.Id)
                            {
                                DataWorker.DeleteTour(tour.Id);
                                Tours = DataWorker.GetTours();
                                break;

                            }
                        }
                    }
                });
            }
        }

        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
