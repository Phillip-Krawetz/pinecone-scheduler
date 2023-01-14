using System.ComponentModel;
using System.Diagnostics;
using PineconeScheduler.Domain.Enums;
using PineconeScheduler.Domain.Interfaces;

namespace PineconeScheduler.Domain.Models
{
  public abstract class BaseTask : IScheduledTask
  {
    public string Name { get; set; }
    public ITrigger? Trigger { get; set; }

    public BaseTask(string Name, ITrigger Trigger)
    {
      this.Name = Name;
      this.Trigger = Trigger;
      this.Trigger.Completed += (s, e) =>
      {
        var bw = new BackgroundWorker();
        bw.DoWork += Execute;
        bw.RunWorkerAsync();
      };
    }

    public abstract void Execute(object? sender, EventArgs args);

    public abstract string GetIdentifyingString();
  }
}