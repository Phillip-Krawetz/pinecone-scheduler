using Microsoft.Win32;
using PineconeScheduler.Domain.Models;

namespace PineconeScheduler.Domain.Handlers
{
  public class TaskHandler
  {
    public List<ScheduledTask> _tasks_SessionSwitch = new List<ScheduledTask>();
    public List<ScheduledTask> Tasks_SessionSwitch 
    { 
      get => _tasks_SessionSwitch;
    }

    private Thread? _workerThread = null;

    public TaskHandler()
    {
      SystemEvents.SessionSwitch += new SessionSwitchEventHandler(Events_SessionSwitch);

      var testTask = new ScheduledTask("Test", "C:\\Program Files\\VideoLAN\\VLC\\vlc.exe");
      testTask.Arguments = "\"C:\\Videos\\Test.mp4\" -Idummy -f --no-osd --video-on-top vlc://quit";
      _tasks_SessionSwitch.Add(testTask);
    }

    public void Events_SessionSwitch(object sender, SessionSwitchEventArgs args)
    {
      if(args.Reason == SessionSwitchReason.SessionUnlock){
        this._workerThread = new Thread(new ThreadStart(this.ExecuteTasks));
        this._workerThread.Start();
      }
    }

    private void ExecuteTasks()
    {
      foreach(var item in Tasks_SessionSwitch)
      {
        item.Execute();
      }
    }

    public void CleanUp(object? sender, object args)
    {
      SystemEvents.SessionSwitch -= new SessionSwitchEventHandler(Events_SessionSwitch);
    }
  }
}