using PineconeScheduler.Domain.Models;
using PineconeScheduler.Storing.Connectors;

namespace PineconeScheduler.Storing.Repositories
{
  public class TaskRepository
  {
    private List<ScheduledTask> _allTasks { get; set; }
    public List<ScheduledTask> AllTasks 
    { 
      get => _allTasks; 
    }
    private FileSystemConnector _converter = new FileSystemConnector();

    public TaskRepository()
    {
      _allTasks = _converter.LoadTasks();
    }
  }
}