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
      if(!Repeatable)
      {
        Completed += CleanUp;
      }
    }

    protected virtual void OnCompleted(EventArgs e)
    {
      this.Completed?.Invoke(this, e);
    }
  }
}