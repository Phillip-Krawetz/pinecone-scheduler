using System.Text;
using System.Timers;

namespace PineconeScheduler.Domain.Models
{
  public class TimedTrigger : BaseTrigger
  {
    public double Interval { get; set; }
    public DateTime ScheduledTime { get; set; }
    private System.Timers.Timer? _timer { get; set; }

    public void CalculateInterval()
    {
      var now = DateTime.Now;
      var timeToGo = ScheduledTime - now;
    }

    public override void CleanUp()
    {
      if(!Repeatable)
      {
        _timer?.Dispose();
      }
    }

    public override string GetIdentifyingString()
    {
      return this.GetType().ToString();
    }

    public override void BeginListening()
    {
      _timer = new System.Timers.Timer(Interval);
      _timer.Elapsed += OnCompleted;
      _timer.AutoReset = Repeatable;
      _timer.Start();
    }

    public TimedTrigger(double Interval, bool Repeatable = false)
    {
      this.Interval = Interval;
      this.Repeatable = Repeatable;
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      sb.AppendJoin(' ', "Time trigger: ", Interval, "ms;","Repeats:", Repeatable);
      return sb.ToString();
    }
  }
}