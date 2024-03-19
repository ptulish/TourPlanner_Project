﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using TourPlanner_Project.MVVM.Model;
using System.Windows.Media;

namespace TourPlanner_Project.MVVM.ViewModel
{
    public class AddNewTourViewModel : INotifyPropertyChanged
    {
        #region VARIABLES

        private string _newTourName;
        public string NewTourName
        {
            get { return _newTourName; }
            set
            {
                _newTourName = value;
                OnPropertyChanged("NewTourName");
            }
        }

        private string _newTourFrom;
        public string NewTourFrom
        {
            get { return _newTourFrom; }
            set
            {
                _newTourFrom = value;
                OnPropertyChanged("NewTourFrom");
            }
        }

        private string _newTourTo;
        public string NewTourTo
        {
            get { return _newTourTo; }
            set
            {
                _newTourTo = value;
                OnPropertyChanged("NewTourTo");
            }
        }

        private string _newTourTransportType;
        public string NewTourTransportType
        {
            get { return _newTourTransportType; }
            set
            {
                _newTourTransportType = value;
                OnPropertyChanged("NewTourTransportType");
            }
        }

        private string _newTourInformation;
        public string NewTourInformation
        {
            get { return _newTourInformation; }
            set
            {
                _newTourInformation = value;
                OnPropertyChanged("NewTourInformation");
            }
        }

        private string _newTourDescription;
        public string NewTourDescription
        {
            get { return _newTourDescription; }
            set
            {
                _newTourDescription = value;
                OnPropertyChanged("NewTourDescription");
            }
        }

        #endregion

        private RelayCommand addNewTour;
        public RelayCommand AddNewTour
        {
            get
            {  
                return addNewTour ?? (addNewTour = new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    SetRedBlockControll(wnd, "new_tour_name");
                    Tour newTour = Tour.CreateTour(NewTourName, NewTourFrom, NewTourTo,NewTourTransportType,NewTourInformation,NewTourDescription);
                    using (var context = new ApplicationContext())
                    {
                        context.Tours.Add(newTour);
                        context.SaveChanges();
                    }
                    OnTourAddedSuccessfully();
                    DataWorker.Tours.Add(newTour);
                }));
            }
        }
        

        private void SetRedBlockControll(Window wnd, string blockName)
        {
            Control block = wnd.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red; 
        }


        #region EVENTS

        public event EventHandler TourAddedSuccessfully;
        protected virtual void OnTourAddedSuccessfully()
        {
            TourAddedSuccessfully?.Invoke(this, EventArgs.Empty);
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
