using System.Diagnostics;
using PineconeScheduler.Domain.Enums;
using PineconeScheduler.Domain.Interfaces;

namespace PineconeScheduler.Domain.Models
{
  public class BaseTask : IScheduledTask
  {
    public string Name { get; set; }
    public string Command { get; set; }
    public string Arguments { get; set; }
    public TaskType TaskType { get; set; }

    public BaseTask(string Name, string Command, string Arguments = "")
    {
      this.Name = Name;
      this.Command = Command;
      this.Arguments = Arguments;
    }

    public void Execute()
    {
      Process task = new Process();
      task.StartInfo.FileName = Command;
      task.StartInfo.Arguments = Arguments;
      task.Start();
    }
  }
}