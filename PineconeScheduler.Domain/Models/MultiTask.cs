using System.Text;
using PineconeScheduler.Domain.Interfaces;

namespace PineconeScheduler.Domain.Models
{
  public class MultiTask : BaseTask
  {
    public IScheduledTask InitialTask { get; set; }
    public IScheduledTask SecondaryTask { get; set; }
    public bool ForceStart { get; set; }

    public MultiTask(string Name, ITrigger Trigger, IScheduledTask InitialTask,
                       IScheduledTask SecondaryTask, bool ForceStart = false) : base(Name, Trigger)
    {
      this.Name = Name;
      this.InitialTask = InitialTask;
      this.SecondaryTask = SecondaryTask;
      this.ForceStart = ForceStart;
      InitialTask.Trigger.Completed += StartSecondTask;
    }

    private void StartSecondTask(object? sender, EventArgs args)
    {
      Trigger.Active = true;
      Trigger.BeginListening();
      Trigger.Completed += Execute;
    }

    public override void Execute(object? sender, EventArgs args)
    {
      SecondaryTask.Execute(this, new EventArgs());
    }

    public override string GetIdentifyingString()
    {
      var sb = new StringBuilder();
      sb.AppendJoin(null, Name, InitialTask.GetIdentifyingString(), SecondaryTask.GetIdentifyingString(), Trigger?.GetIdentifyingString());
      return sb.ToString();
    }
  }
}