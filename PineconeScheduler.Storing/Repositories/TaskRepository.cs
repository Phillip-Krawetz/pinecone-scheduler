using PineconeScheduler.Domain.Enums;
using PineconeScheduler.Domain.Interfaces;
using PineconeScheduler.Domain.Models;
using PineconeScheduler.Storing.Connectors;

namespace PineconeScheduler.Storing.Repositories
{
  public class TaskRepository
  {
    private List<IScheduledTask> _allTasks { get; set; }
    public List<IScheduledTask> AllTasks 
    { 
      get => _allTasks; 
    }
    private FileSystemConnector _converter = new FileSystemConnector();

    public TaskRepository()
    {
      _allTasks = _converter.LoadTasks();
    }

    public void CleanAll()
    {
      foreach(var task in _allTasks)
      {
        if(task.Trigger != null)
        {
          task.Trigger.CleanUp();
          System.Console.WriteLine("Cleaned up " + task.Name);
        }
      }
    }

    public bool AddTask(IScheduledTask NewTask)
    {
      if(_allTasks.Any(x => x.GetIdentifyingString() == NewTask.GetIdentifyingString()))
      {
        return false;
      }
      NewTask.Trigger?.BeginListening();
      _converter.SaveTask(NewTask);
      _allTasks.Add(NewTask);
      return true;
    }
  }
}