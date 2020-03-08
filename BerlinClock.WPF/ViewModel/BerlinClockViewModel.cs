using System;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Threading;

namespace BerlinClock.WPF
{
    class BerlinClockViewModel
    {
        #region Private Fields
        private readonly DispatcherTimer timer = new DispatcherTimer();
        #endregion //Private Fields

        #region Public Properties
        public BerlinTime BerlinTime { get; } = new BerlinTime();

        public SolidColorBrush SecondColor => BerlinTime.SecondMark;
        public SolidColorBrush FiveHoursColor1 => BerlinTime.FiveHoursMarks[0];
        public SolidColorBrush FiveHoursColor2 => BerlinTime.FiveHoursMarks[1];
        public SolidColorBrush FiveHoursColor3 => BerlinTime.FiveHoursMarks[2];
        public SolidColorBrush FiveHoursColor4 => BerlinTime.FiveHoursMarks[3];

        public SolidColorBrush OneHoursColor1 => BerlinTime.OneHourMarks[0];
        public SolidColorBrush OneHoursColor2 => BerlinTime.OneHourMarks[1];
        public SolidColorBrush OneHoursColor3 => BerlinTime.OneHourMarks[2];
        public SolidColorBrush OneHoursColor4 => BerlinTime.OneHourMarks[3];

        public SolidColorBrush FiveMinutesColor1 => BerlinTime.FiveMinutesMarks[0];
        public SolidColorBrush FiveMinutesColor2 => BerlinTime.FiveMinutesMarks[1];
        public SolidColorBrush FiveMinutesColor3 => BerlinTime.FiveMinutesMarks[2];
        public SolidColorBrush FiveMinutesColor4 => BerlinTime.FiveMinutesMarks[3];
        public SolidColorBrush FiveMinutesColor5 => BerlinTime.FiveMinutesMarks[4];
        public SolidColorBrush FiveMinutesColor6 => BerlinTime.FiveMinutesMarks[5];
        public SolidColorBrush FiveMinutesColor7 => BerlinTime.FiveMinutesMarks[6];
        public SolidColorBrush FiveMinutesColor8 => BerlinTime.FiveMinutesMarks[7];
        public SolidColorBrush FiveMinutesColor9 => BerlinTime.FiveMinutesMarks[8];
        public SolidColorBrush FiveMinutesColor10 => BerlinTime.FiveMinutesMarks[9];
        public SolidColorBrush FiveMinutesColor11 => BerlinTime.FiveMinutesMarks[10];

        public SolidColorBrush OneMinuteColor1 => BerlinTime.OneMinuteMark[0];
        public SolidColorBrush OneMinuteColor2 => BerlinTime.OneMinuteMark[1];
        public SolidColorBrush OneMinuteColor3 => BerlinTime.OneMinuteMark[2];
        public SolidColorBrush OneMinuteColor4 => BerlinTime.OneMinuteMark[3];
        #endregion //Public Properties

        #region Ctors
        public BerlinClockViewModel()
        {
            BerlinTime.Time = DateTime.Now;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        #endregion //Ctors

        #region Private Methods
        private void Timer_Tick(object sender, EventArgs e)
        {
            BerlinTime.Time = DateTime.Now;
        }
        #endregion //Private Methods
    }
}