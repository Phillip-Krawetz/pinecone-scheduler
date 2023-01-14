using System.Diagnostics;
using PineconeScheduler.Domain.Interfaces;

namespace PineconeScheduler.Domain.Models
{
  public class CmdTask : BaseTask
  {
    public string Command { get; set; }
    public string Arguments { get; set; }
    public CmdTask(string Name, ITrigger Trigger, string Command, string Arguments = "") : base(Name, Trigger)
    {
      this.Command = Command;
      this.Arguments = Arguments;
    }

    public override void Execute(object? sender, EventArgs args)
    {
      Process task = new Process();
      task.StartInfo.FileName = Command;
      task.StartInfo.Arguments = Arguments;
      task.Start();
    }

    public override string GetIdentifyingString()
    {
      return Name + Command + Arguments + Trigger?.GetIdentifyingString();
    }
  }
}