using System.Collections.ObjectModel;
using PineconeScheduler.Domain.Interfaces;
using PineconeScheduler.Storing.Repositories;
using ReactiveUI;

namespace PineconeScheduler.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
  public TaskRepository TaskRepo = new TaskRepository();

  public ObservableCollection<IScheduledTask> _allTasks;

  public ObservableCollection<IScheduledTask> AllTasks
  { 
    get => _allTasks;
    set => this.RaiseAndSetIfChanged(ref _allTasks, value);
  }

  public MainWindowViewModel()
  {
    _allTasks = new ObservableCollection<IScheduledTask>(TaskRepo.AllTasks);
  }

  public void CleanAll()
  {
    TaskRepo.CleanAll();
  }
}
