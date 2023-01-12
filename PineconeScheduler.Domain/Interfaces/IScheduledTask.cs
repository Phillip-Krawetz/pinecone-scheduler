using PineconeScheduler.Domain.Enums;

namespace PineconeScheduler.Domain.Interfaces
{
  public interface IScheduledTask
  {
    public string Name { get; set; }
    public TaskType TaskType { get; set; }
    void Execute();
  }
}