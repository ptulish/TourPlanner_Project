using System.ComponentModel;
using System.IO.Packaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TourPlanner_Project.MVVM.Model;

namespace TourPlanner_Project.MVVM.ViewModel
{
    internal class AddNewLogViewModel : INotifyPropertyChanged
    {
        #region VARIABLES/FIELDS
        private Tour _selectedTour;
        public Tour SelectedTour
        {
            get { return _selectedTour; }
            set 
            { 
                _selectedTour = new Tour(value);
                OnPropertyChanged(nameof(SelectedTour));
            }
        }
        private string _newLogName;
        public string NewLogName
        {
            get { return _newLogName; }
            set
            {
                _newLogName = "Log for Tour " + SelectedTour.Name;
                OnPropertyChanged(nameof(NewLogName));
            }
        }

        private DateTime _newLogDate;
        public DateTime NewLogDate
        {
            get { return _newLogDate; }
            set
            {
                _newLogDate = value;
                OnPropertyChanged(nameof(NewLogDate));
            }
        }

        private string _newLogDistance;
        public string NewLogDistance
        {
            get { return _newLogDistance; }
            set
            {
                _newLogDistance = value;
                OnPropertyChanged(nameof(NewLogDistance));
            }
        }

        private string _newLogTime;
        public string NewLogTime
        {
            get { return _newLogTime; }
            set
            {
                _newLogTime = value;
                OnPropertyChanged(nameof(NewLogTime));
            }
        }

        private ComboBoxItem _newLogDifficulty;
        public ComboBoxItem NewLogDifficulty
        {
            get { return _newLogDifficulty; }
            set
            {
                _newLogDifficulty = value;
                OnPropertyChanged(nameof(NewLogDifficulty));
            }
        }
        private ComboBoxItem _newLogRating;
        public ComboBoxItem NewLogRating
        {
            get { return _newLogRating; }
            set
            {
                _newLogRating = value;
                OnPropertyChanged(nameof(NewLogRating));
            }
        }
        public string _newLogComment;
        public string NewLogComment
        {
            get { return _newLogComment; }
            set
            {
                _newLogComment = value;
                OnPropertyChanged(nameof(NewLogComment));
            }
        }
        #endregion

        public AddNewLogViewModel(Tour selectedTour)
        {
            _selectedTour = selectedTour;
            _newLogDate = DateTime.Today;
        }

        private RelayCommand _addNewLog;
        public RelayCommand AddNewLog
        {
            get
            {
                return _addNewLog ?? (_addNewLog = new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    bool good = true;

                    if (NewLogDate == null)
                    {
                        SetRedBlockControll(wnd, "tour_log_date");
                        good = false;
                    }
                    else
                    {
                        SetNormalBlockControll(wnd, "tour_log_date");
                    }

                    if (NewLogDifficulty == null)
                    {
                        SetRedBlockControll(wnd, "tour_log_difficulty");
                        good = false;
                    }
                    else
                    {
                        SetNormalBlockControll(wnd, "tour_log_difficulty");
                    }

                    if (NewLogRating == null)
                    {
                        SetRedBlockControll(wnd, "tour_log_rating");
                        good = false;
                    }
                    else
                    {
                        SetNormalBlockControll(wnd, "tour_log_rating");
                    }

                    if (NewLogDistance == null)
                    {
                        SetRedBlockControll(wnd, "tour_log_distance");
                        good = false;
                    }
                    else
                    {
                        SetNormalBlockControll(wnd, "tour_log_distance");
                    }

                    if (NewLogComment == null || NewLogComment == string.Empty)
                    {
                        SetRedBlockControll(wnd, "tour_log_comment");
                        good = false;
                    }
                    else
                    {
                        SetNormalBlockControll(wnd, "tour_log_comment");
                    }

                    if (good == true)
                    {
                        Log newLog = Log.CreateLog(_selectedTour.Id, NewLogDate.ToUniversalTime(), NewLogComment, Convert.ToInt32(NewLogDifficulty.Content), Convert.ToInt32(NewLogDistance), Convert.ToInt32(NewLogTime), Convert.ToInt32(NewLogRating.Content));

                        //add the log to the tour
                        OnLogAddedSuccessfully();
                        SelectedTour.Logs.Add(newLog);
                        
                    }



                }));

            }
        }

        private void SetNormalBlockControll(Window? wnd, string blockName)
        {
            Control block = wnd.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Black;
        }

        private void SetRedBlockControll(Window wnd, string blockName)
        {
            Control block = wnd.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }
        #region EVENTS
        public event EventHandler LogAddedSuccessfully;
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnLogAddedSuccessfully()
        {
            LogAddedSuccessfully?.Invoke(this, EventArgs.Empty);
        }
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
