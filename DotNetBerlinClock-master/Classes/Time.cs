﻿using System;
using System.Text.RegularExpressions;

namespace BerlinClock
{
    public class Time
    {
        #region Private Fields
        private readonly int _seccond;
        private readonly int _minute;
        private readonly int _hour;
        #endregion //Private Fields

        #region Private Properties
        private bool Seccond
        {
            get
            {
                return IsOdd(_seccond);
            }
        }
        private bool[] FiveHours
        {
            get
            {
                return GetBerlinTime(GetFloor(_hour), new bool[4]);
            }
        }
        private bool[] OneHour
        {
            get
            {
                return GetBerlinTime(GetRemnant(_hour), new bool[4]);
            }
        }
        private bool[] FiveMinutes
        {
            get
            {
                return GetBerlinTime(GetFloor(_minute), new bool[11]);
            }
        }
        private bool[] OneMinute
        {
            get
            {
                return GetBerlinTime(GetRemnant(_minute), new bool[4]);
            }
        }
        #endregion //Private Properties

        #region Public Properties
        public string SeccondLine
        {
            get
            {
                return Seccond ? "O" : "Y";
            }
        }
        public string FiveHoursLine
        {
            get
            {
                return GetStringLine(FiveHours, "R");
            }
        }
        public string OneHourLine
        {
            get 
            {
                return GetStringLine(OneHour, "R");
            }
        }
        public string FiveMinutesLine
        {
            get 
            {
                string result = string.Empty;
                var index = 1;
                foreach (bool item in FiveMinutes)
                {
                    if (item)
                    {
                        if(index == 3 
                            || index == 6 
                            || index == 9)
                            result += "R";
                        else
                            result += "Y";
                    }
                    else
                        result += "O";
                    index++;
                }
                return result;
            }
        }
        public string OneMinuteLine
        {   
            get
            {
                return GetStringLine(OneMinute, "Y");
            }
        }
        #endregion //Public Properties

        #region Ctors
        public Time(string currentTime)
        {
           if(IsValidTime(currentTime))
           {
                string[] time = 
                    currentTime.Split(new[] { ":" }, 
                    StringSplitOptions.None);
                _hour = int.Parse(time[0]);
                _minute = int.Parse(time[1]);
                _seccond = int.Parse(time[2]);
           }
           else
           {
                throw new Exception($"The time privided: {currentTime} is incorrect");
           }
        }
        #endregion //Ctors

        #region Private Methods
        public bool IsValidTime(string time)
        {
            Regex checktime = 
                new Regex(@"^([0-1]?[0-9]|2[0-4]):[0-5][0-9]:[0-5][0-9]$");

            return checktime.IsMatch(time);
        }
        private string GetStringLine(bool[] values, string timeMark)
        {
            string result = string.Empty;
            foreach (bool item in values)
            {
                if (item)
                    result += timeMark;
                else
                    result += "O";
            }
            return result;
        }
        private bool[] GetBerlinTime(double time, bool[] result)
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
        private double GetRemnant(int value)
        {
            long lastDigit = value % (10);
            return lastDigit > 4 ? lastDigit  - 5 : lastDigit;
        }
        private bool IsOdd(int value)
        {
            return value % 2 != 0;
        }
        #endregion //Private Methods
    }
}