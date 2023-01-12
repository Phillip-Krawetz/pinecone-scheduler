using System;
using System.Diagnostics;
using Microsoft.Win32;
using PineconeScheduler.Domain.Enums;

namespace PineconeScheduler.Domain.Models
{
  public class ScheduledTask
  {
    public string Name { get; set; }
    public string Command { get; set; }
    public string Arguments { get; set; }
    public TaskType TaskType { get; set; }

    public ScheduledTask(string Name, string Command, string Arguments = "", TaskType TaskType = TaskType.SessionUnlock)
    {
      this.Name = Name;
      this.Command = Command;
      this.Arguments = Arguments;
      this.TaskType = TaskType;
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