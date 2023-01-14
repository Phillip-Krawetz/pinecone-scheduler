using PineconeScheduler.Domain.Interfaces;

namespace PineconeScheduler.Domain.Models
{
  public class AudioTask : BaseTask
  {
    public AudioTask(string Name, ITrigger Trigger) : base(Name, Trigger)
    {
    }

    public override void Execute(object? sender, EventArgs args)
    {
      throw new NotImplementedException();
    }

    public override string GetIdentifyingString()
    {
      throw new NotImplementedException();
    }
  }
}