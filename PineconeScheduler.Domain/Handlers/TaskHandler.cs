using Microsoft.Win32;
using PineconeScheduler.Domain.Models;

namespace PineconeScheduler.Domain.Handlers
{
  public class TaskHandler
  {
    private static List<ScheduledTask> _tasks_SessionSwitch = new List<ScheduledTask>();
    public List<ScheduledTask> Tasks_SessionSwitch 
    { 
      get => _tasks_SessionSwitch;
    }

    private Thread? _workerThread = null;

    public TaskHandler()
    {
      SystemEvents.SessionSwitch += new SessionSwitchEventHandler(Events_SessionSwitch);
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

    public void CleanUp()
    {
      SystemEvents.SessionSwitch -= new SessionSwitchEventHandler(Events_SessionSwitch);
    }

    public void AddTasks(ScheduledTask NewTask)
    {
      _tasks_SessionSwitch.Add(NewTask);
    }

    public void AddTasks(List<ScheduledTask> NewTasks)
    {
      _tasks_SessionSwitch.AddRange(NewTasks);
    }
  }
}