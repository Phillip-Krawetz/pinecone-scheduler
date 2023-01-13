using PineconeScheduler.Domain.Interfaces;
using PineconeScheduler.Domain.Models;

namespace PineconeScheduler.Storing.Connectors
{
  public class FileSystemConnector
  {
    private static string _configPath = Path.GetFullPath(AppContext.BaseDirectory)+"\\Options.json";
    private static string _tasksPath = Path.GetFullPath(AppContext.BaseDirectory)+"\\Tasks\\";

    public List<IScheduledTask> LoadTasks()
    {
      var allTasks = new List<IScheduledTask>();
      var dummyTask = new CmdTask("Test", "C:\\Program Files\\VideoLAN\\VLC\\vlc.exe", new UnlockTrigger());
      dummyTask.Arguments = "\"C:\\Videos\\Test.mp4\" -Idummy -f --no-osd --video-on-top vlc://quit";
      allTasks.Add(dummyTask);

      return allTasks;
    }
  }
}