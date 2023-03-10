namespace PineconeScheduler.Domain.Interfaces
{
  public interface ITrigger
  {
    public event EventHandler? Completed;
    public bool Repeatable { get; set; }
    public bool Active { get; set; }
    public void CleanUp();
    public string GetIdentifyingString();
    public void BeginListening();
  }
}