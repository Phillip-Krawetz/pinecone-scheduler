using PineconeScheduler.Domain.Interfaces;

namespace PineconeScheduler.Domain.Models
{
  public abstract class BaseTrigger : ITrigger
  {
    public bool Repeatable { get; set; }

    public event EventHandler? Completed;

    public abstract void CleanUp();

    private void CleanUp(object? sender, EventArgs args)
    {
      CleanUp();
    }

    public BaseTrigger()
    {
      Completed += delegate
      {
        if(!Repeatable)
        {
          CleanUp();
        }
      };
    }

    protected virtual void OnCompleted(object? sender, EventArgs e)
    {
      System.Console.WriteLine("Trigger invoked");
      this.Completed?.Invoke(this, e);
    }

    public abstract string GetIdentifyingString();

    public abstract void BeginListening();
  }
}