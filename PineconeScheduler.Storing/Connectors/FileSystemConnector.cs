using Newtonsoft.Json;
using PineconeScheduler.Domain.Interfaces;
using PineconeScheduler.Domain.Models;

namespace PineconeScheduler.Storing.Connectors
{
  public class FileSystemConnector
  {
    private static string _configPath = Path.GetFullPath(AppContext.BaseDirectory)+"Options.json";
    private static string _tasksPath = Path.GetFullPath(AppContext.BaseDirectory)+"Tasks\\";

    public FileSystemConnector()
    {
      EnsureCreated();
    }

    public bool EnsureCreated()
    {
      if(!Directory.Exists(_tasksPath))
      {
        Directory.CreateDirectory(_tasksPath);
        return false;
      }
      return true;
    }

    public List<IScheduledTask> LoadTasks()
    {
      var allTasks = new List<IScheduledTask>();

      var test = Directory.GetFiles(_tasksPath);

      var settings = new JsonSerializerSettings(){TypeNameHandling = TypeNameHandling.All};

      string jsonString = "";

      foreach(var task in Directory.GetFiles(_tasksPath))
      {
        using(StreamReader sr = new StreamReader(task))
        {
          jsonString = sr.ReadToEnd();
        }
        var CurrentTask = JsonConvert.DeserializeObject<IScheduledTask>(jsonString, settings);
        if(CurrentTask != null)
        {
          CurrentTask.Trigger?.BeginListening();
          allTasks.Add(CurrentTask);
          System.Console.WriteLine("Added task " + CurrentTask.Name);
        }
      }

      return allTasks;
    }

    public void SaveTask(IScheduledTask NewTask)
    {
      var settings = new JsonSerializerSettings(){TypeNameHandling = TypeNameHandling.All};
      using(StreamWriter sw = new StreamWriter(_tasksPath + NewTask.Name + ".json"))
      {
        sw.WriteLine(JsonConvert.SerializeObject(NewTask, settings));
      }
    }
  }
}