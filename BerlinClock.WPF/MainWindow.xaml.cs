using System.Windows;

namespace BerlinClock.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BerlinClockViewModel VM = new BerlinClockViewModel();
            VM.BerlinTime.PropertyChanged += BerlinTime_PropertyChanged;
            DataContext = VM;
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Refresh();
        }

        private void Refresh()
        {
            Second.Fill = ((BerlinClockViewModel)DataContext).SecondColor;

            FiveHours1.Fill = ((BerlinClockViewModel)DataContext).FiveHoursColor1;
            FiveHours2.Fill = ((BerlinClockViewModel)DataContext).FiveHoursColor2;
            FiveHours3.Fill = ((BerlinClockViewModel)DataContext).FiveHoursColor3;
            FiveHours4.Fill = ((BerlinClockViewModel)DataContext).FiveHoursColor4;

            OneHours1.Fill = ((BerlinClockViewModel)DataContext).OneHoursColor1;
            OneHours2.Fill = ((BerlinClockViewModel)DataContext).OneHoursColor2;
            OneHours3.Fill = ((BerlinClockViewModel)DataContext).OneHoursColor3;
            OneHours4.Fill = ((BerlinClockViewModel)DataContext).OneHoursColor4;

            FiveMinutes1.Fill = ((BerlinClockViewModel)DataContext).FiveMinutesColor1;
            FiveMinutes2.Fill = ((BerlinClockViewModel)DataContext).FiveMinutesColor2;
            FiveMinutes3.Fill = ((BerlinClockViewModel)DataContext).FiveMinutesColor3;
            FiveMinutes4.Fill = ((BerlinClockViewModel)DataContext).FiveMinutesColor4;
            FiveMinutes5.Fill = ((BerlinClockViewModel)DataContext).FiveMinutesColor5;
            FiveMinutes6.Fill = ((BerlinClockViewModel)DataContext).FiveMinutesColor6;
            FiveMinutes7.Fill = ((BerlinClockViewModel)DataContext).FiveMinutesColor7;
            FiveMinutes8.Fill = ((BerlinClockViewModel)DataContext).FiveMinutesColor8;
            FiveMinutes9.Fill = ((BerlinClockViewModel)DataContext).FiveMinutesColor9;
            FiveMinutes10.Fill = ((BerlinClockViewModel)DataContext).FiveMinutesColor10;
            FiveMinutes11.Fill = ((BerlinClockViewModel)DataContext).FiveMinutesColor11;

            OneMinute1.Fill = ((BerlinClockViewModel)DataContext).OneMinuteColor1;
            OneMinute2.Fill = ((BerlinClockViewModel)DataContext).OneMinuteColor2;
            OneMinute3.Fill = ((BerlinClockViewModel)DataContext).OneMinuteColor3;
            OneMinute4.Fill = ((BerlinClockViewModel)DataContext).OneMinuteColor4;
        }

        private void BerlinTime_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Refresh();
        }
    }
}