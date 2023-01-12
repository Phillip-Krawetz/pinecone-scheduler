using PineconeScheduler.Domain.Models;

namespace PineconeScheduler.Storing.Connectors
{
  public class FileSystemConnector
  {
    private static string _configPath = Path.GetFullPath(AppContext.BaseDirectory)+"\\Options.json";
    private static string _tasksPath = Path.GetFullPath(AppContext.BaseDirectory)+"\\Tasks\\";

    public List<ScheduledTask> LoadTasks()
    {
      var allTasks = new List<ScheduledTask>();
      var dummyTask = new ScheduledTask("Test", "C:\\Program Files\\VideoLAN\\VLC\\vlc.exe");
      dummyTask.Arguments = "\"C:\\Videos\\Test.mp4\" -Idummy -f --no-osd --video-on-top vlc://quit";
      allTasks.Add(dummyTask);
      
      return allTasks;
    }
  }
}