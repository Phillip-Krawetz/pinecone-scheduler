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

    public List<IScheduledTask> GetTasksByType(TaskType DesiredType)
    {
      return _allTasks.Where(x => x.TaskType == DesiredType).ToList();
    }
  }
}