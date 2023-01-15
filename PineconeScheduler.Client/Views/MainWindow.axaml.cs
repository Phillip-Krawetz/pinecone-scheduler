using System;
using Avalonia;
using Avalonia.Controls;
using PineconeScheduler.Client.ViewModels;

namespace PineconeScheduler.Client.Views;

public partial class MainWindow : Window
{
  public MainWindow()
  {
    InitializeComponent();
    Closing += (s, e) =>
    {
      Hide();
      e.Cancel = true;
    };

    var button = this.FindControl<TextBlock>("AddTaskButton");
    button.PointerReleased += CreateTask;
  }

  private void CreateTask(object? sender, EventArgs args)
  {
    var dummyTask = new Domain.Models.CmdTask("TimedTask1", new Domain.Models.TimedTrigger(5000), "\"C:\\Program Files (x86)\\Winamp\\winamp.exe\"");
    // var dummyTask = new Domain.Models.CmdTask("Test2", new Domain.Models.UnlockTrigger(), "C:\\Program Files\\VideoLAN\\VLC\\vlc.exe");
    dummyTask.Arguments = "\"C:\\Audio\\06. escape.flac\"";
    (this.DataContext as MainWindowViewModel)?.AddTask(dummyTask);
  }
}