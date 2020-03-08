using System;
using System.ComponentModel;
using System.Windows.Media;

namespace BerlinClock.WPF
{
    public sealed class BerlinTime : Time<SolidColorBrush>, INotifyPropertyChanged
    {
        #region Public Properties
        public DateTime Time
        {
            set
            {
                SetSecond(value.Second);
                SetMinute(value.Minute);
                SetHour(value.Hour);
                OnPropertyChanged("Time");
            }
        }
        #endregion //Public Properties

        #region Overrides
        protected override SolidColorBrush HourMarkActive => new SolidColorBrush(Color.FromArgb(255, 251, 1, 2)); 
        protected override SolidColorBrush HourMarkInactive => new SolidColorBrush(Color.FromArgb(255, 55, 20, 24));
        protected override SolidColorBrush MinuteMarkInactive => new SolidColorBrush(Color.FromArgb(255, 56, 59, 2));
        protected override SolidColorBrush MinuteMarkActive => new SolidColorBrush(Color.FromArgb(255, 255, 255, 1));
        #endregion //Setters

        #region Ctors
        public BerlinTime()
        { }
        #endregion //Ctors

        #region INotifyPropertyChanged Members  
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion //INotifyPropertyChanged Members 
    }
}