using System.Text;

namespace BerlinClock
{
    public sealed class StringTime :Time<string>
    {
        #region Public Properties
        public string Time
        {
            get
            {
                StringBuilder sb = new StringBuilder(24);

                sb.AppendLine(SecondMark);
                sb.AppendLine(GetString(FiveHoursMarks));
                sb.AppendLine(GetString(OneHourMarks));
                sb.AppendLine(GetString(FiveMinutesMarks));
                sb.Append(GetString(OneMinuteMark)); ;
                return sb.ToString();
            }
        }
        #endregion //Public Properties

        #region Overrides
        protected override string HourMarkInactive => "O";
        protected override string HourMarkActive => "R";
        protected override string MinuteMarkInactive => "O";
        protected override string MinuteMarkActive => "Y";
        #endregion //SettOverridesers

        #region Private Methods
        private string GetString(string[] mark)
        {
            var result = string.Empty;
            foreach (var item in mark)
                result += item;
            return result;
        }
        #endregion //Private Methods

        #region Ctors
        public StringTime(string currentTime) : base(currentTime)
        { }
        #endregion //Ctors
    }
}