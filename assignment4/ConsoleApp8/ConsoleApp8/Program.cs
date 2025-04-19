using System;
using System.Timers;

class Program
{
    public class AlarmClock
    {
        public event EventHandler Tick;
        public event EventHandler Alarm;

        private System.Timers.Timer _timer;
        private DateTime _alarmTime;
        private bool _alarmRang = false;
        public AlarmClock(DateTime alarmTime)
        {
            _alarmTime = alarmTime;
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += OnTick;
            _timer.Start();
        }
        private void OnTick(object sender, ElapsedEventArgs e)
        {
            Tick?.Invoke(this, EventArgs.Empty);

            if (!_alarmRang && DateTime.Now >= _alarmTime)
            {
                Alarm?.Invoke(this, EventArgs.Empty);
                _alarmRang = true;
            }
        }
    }

    static void Main(string[] args)
    {
        DateTime alarmTime = DateTime.Now.AddSeconds(5);
        var alarmClock = new AlarmClock(alarmTime);
        alarmClock.Tick += (sender, e) =>
        {
            Console.WriteLine("滴答...滴答...");
        };

        alarmClock.Alarm += (sender, e) =>
        {
            Console.WriteLine("闹钟响铃了！请起床！");
        };
        Console.WriteLine($"闹钟已设置，闹钟将在 {alarmTime} 时响铃.");
        Console.WriteLine("按任意键退出...");
        Console.ReadKey();
    }
}
