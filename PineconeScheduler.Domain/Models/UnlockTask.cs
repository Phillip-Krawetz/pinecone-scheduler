using PineconeScheduler.Domain.Enums;
using PineconeScheduler.Domain.Interfaces;

namespace PineconeScheduler.Domain.Models
{
  public class UnlockTask : BaseTask
  {
    public UnlockTask(string Name, string Command, string Arguments = "") : base(Name, Command, Arguments)
    {
      this.TaskType = TaskType.SessionUnlock;
    }
  }
}