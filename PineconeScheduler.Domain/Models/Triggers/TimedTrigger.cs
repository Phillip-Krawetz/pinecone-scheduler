using PineconeScheduler.Domain.Interfaces;

namespace PineconeScheduler.Domain.Models
{
  public class TimedTrigger : BaseTrigger
  {
    public double Interval { get; set; }
    public DateTime ScheduledTime { get; set; }

    public void CalculateInterval()
    {
      var now = DateTime.Now;
      var timeToGo = ScheduledTime - now;
    }

    public override void CleanUp()
    {
      throw new NotImplementedException();
    }

    public TimedTrigger(double Interval)
    {
      this.Interval = Interval;
      Completed += (s,e) => {};
    }

    public TimedTrigger(DateTime ScheduledTime)
    {
      this.ScheduledTime = ScheduledTime;
      Completed += (s,e) => {};
    }
  }
}