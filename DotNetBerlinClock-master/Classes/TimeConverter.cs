using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            Time time = new Time(aTime);
            StringBuilder sb = new StringBuilder(24);

            sb.AppendLine(time.SeccondLine);
            sb.AppendLine(time.FiveHoursLine);
            sb.AppendLine(time.OneHourLine);
            sb.AppendLine(time.FiveMinutesLine);
            sb.Append(time.OneMinuteLine);;
            return sb.ToString();
        }
    }
}