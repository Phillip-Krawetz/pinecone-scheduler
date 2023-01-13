using Microsoft.Win32;

namespace PineconeScheduler.Domain.Models
{
  public class UnlockTrigger : BaseTrigger
  {
    public UnlockTrigger()
    {
      SystemEvents.SessionSwitch += new SessionSwitchEventHandler(Events_SessionSwitch);
    }

    private void Events_SessionSwitch(object sender, SessionSwitchEventArgs args)
    {
      if(args.Reason == SessionSwitchReason.SessionUnlock){
        OnCompleted(args);
      }
    }

    public override void CleanUp()
    {
      SystemEvents.SessionSwitch -= new SessionSwitchEventHandler(Events_SessionSwitch);
    }
  }
}