using System.Text;
using Microsoft.Win32;

namespace PineconeScheduler.Domain.Models
{
  public class UnlockTrigger : BaseTrigger
  {
    public UnlockTrigger(bool Repeatable = false, bool Active = true)
    {
      this.Repeatable = Repeatable;
      this.Active = Active;
    }

    private void Events_SessionSwitch(object sender, SessionSwitchEventArgs args)
    {
      if(args.Reason == SessionSwitchReason.SessionUnlock){
        OnCompleted(sender, args);
      }
    }

    public override void CleanUp()
    {
      SystemEvents.SessionSwitch -= new SessionSwitchEventHandler(Events_SessionSwitch);
    }

    public override string GetIdentifyingString()
    {
      return this.GetType().ToString();
    }

    protected override void BeginListeningTempl()
    {
      SystemEvents.SessionSwitch += new SessionSwitchEventHandler(Events_SessionSwitch);
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      sb.AppendJoin(' ', "Session unlock trigger;", "Repeats:", Repeatable);
      return sb.ToString();
    }
  }
}