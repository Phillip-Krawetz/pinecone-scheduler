using System.Diagnostics;
using PineconeScheduler.Domain.Interfaces;

namespace PineconeScheduler.Domain.Models
{
  public class CmdTask : BaseTask
  {
    public string Command { get; set; }
    public string Arguments { get; set; }
    public CmdTask(string Name, string Command, ITrigger Trigger, string Arguments = "") : base(Name, Trigger)
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
  }
}