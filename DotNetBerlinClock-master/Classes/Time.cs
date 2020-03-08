using System;
using System.Text.RegularExpressions;

namespace BerlinClock
{
    public abstract class Time<T>
    {
        #region Private Fields
        private int second;
        private int minute;
        private int hour;
        #endregion //Private Fields

        #region Private Properties
        private bool Second
        {
            get
            {
                int firstDigit = (int)(second / Math.Pow(10, (int)Math.Floor(Math.Log10(second))));
                var lastDigit = GetLastDigit(second);
                var result = firstDigit % 2 == 0;

                if (lastDigit == 2 ||
                   lastDigit == 3 ||
                   lastDigit == 6 ||
                   lastDigit == 7)
                    result = !result;

                return result;
            }
        }
        private bool[] FiveHours => GetBerlinTime(GetFloor(hour), new bool[4]);
        private bool[] OneHour => GetBerlinTime(GetRemnant(hour), new bool[4]);
        private bool[] FiveMinutes => GetBerlinTime(GetFloor(minute), new bool[11]);
        private bool[] OneMinute => GetBerlinTime(GetRemnant(minute), new bool[4]);
        #endregion //Private Properties

        #region Protected Properties
        protected abstract T HourMarkInactive { get; }
        protected abstract T HourMarkActive { get; }
        protected abstract T MinuteMarkInactive { get; }
        protected abstract T MinuteMarkActive { get; }
        #endregion //Protected Properties

        #region Public Properties
        public T SecondMark => Second ? MinuteMarkActive : MinuteMarkInactive;
        public T[] FiveHoursMarks => GetValue(FiveHours, HourMarkActive, HourMarkInactive);
        public T[] OneHourMarks => GetValue(OneHour, HourMarkActive, HourMarkInactive);
        public T[] FiveMinutesMarks => GetFiveMinutesValue(FiveMinutes, HourMarkActive, HourMarkInactive, MinuteMarkActive, MinuteMarkInactive);
        public T[] OneMinuteMark => GetValue(OneMinute, MinuteMarkActive, MinuteMarkInactive);
        #endregion //Public Properties

        #region Setters
        protected void SetSecond(int second) => this.second = second;
        protected void SetMinute(int minute) => this.minute = minute;
        protected void SetHour(int hour) => this.hour = hour;
        #endregion //Setters

        #region Ctors
        public Time(string currentTime)
        {
           if(IsValidTime(currentTime))
           {
                string[] time = 
                    currentTime.Split(new[] { ":" }, 
                    StringSplitOptions.None);
                hour = int.Parse(time[0]);
                minute = int.Parse(time[1]);
                second = int.Parse(time[2]);
           }
           else
           {
                throw new Exception($"Time provided: {currentTime} is incorrect.");
           }
        }
        public Time()
        { }
        #endregion //Ctors

        #region Private Methods
        private bool IsValidTime(string time)
        {
            Regex checktime = 
                new Regex(@"^([0-1]?[0-9]|2[0-4]):[0-5][0-9]:[0-5][0-9]$");

            return checktime.IsMatch(time);
        }
        private bool[] GetBerlinTime(int time, bool[] result)
        {
            for (int i = 0; i < time; i++)
            {
                result[i] = true;
            }
            return result;
        }
        private int GetFloor(int value)
        {
            return value / 5;
        }
        private int GetRemnant(int value)
        {
            int lastDigit = GetLastDigit(value);
            return lastDigit > 4 ? lastDigit  - 5 : lastDigit;
        }
        private int GetLastDigit(int value)
        {
            return value % (10);
        }
        private T[] GetValue(bool[] values, T timeMarkActive, T timeMarkInactive)
        {
            T[] result = new T[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                bool item = values[i];
                result[i] = item ? timeMarkActive : timeMarkInactive;
            }
            return result;
        }
        private T[] GetFiveMinutesValue(bool[] values, T hourMarkActive, T hourMarkInactive, T minuteMarkActive, T minuteMarkInactive)
        {
            T[] result = new T[values.Length];
            var quarterIndex = 1;
            for (int i = 0; i < FiveMinutes.Length; i++)
            {
                var isQuarter = quarterIndex == 3 ||
                                quarterIndex == 6 ||
                                quarterIndex == 9;
                result[i] = FiveMinutes[i]
                    ? isQuarter
                        ? hourMarkActive
                        : minuteMarkActive
                    : isQuarter
                       ? hourMarkInactive
                       : minuteMarkInactive;
                quarterIndex++;
            }
            return result;
        }
        #endregion //Private Methods
    }
}