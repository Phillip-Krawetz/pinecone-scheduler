using PineconeScheduler.Domain.Enums;

namespace PineconeScheduler.Domain.Interfaces
{
  public interface IScheduledTask
  {
    public string Name { get; set; }
    public ITrigger? Trigger { get; set; }
    void Execute(object? sender, EventArgs args);
    string GetIdentifyingString();
  }
}