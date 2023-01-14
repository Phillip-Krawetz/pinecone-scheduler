using System;
using Avalonia;
using Avalonia.Controls;

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

    this.PropertyChanged += SetScrollBar;
  }

  private void SetScrollBar(object? sender, AvaloniaPropertyChangedEventArgs args)
  {}

  private void CreateTask(object? sender, EventArgs args)
  {
    var dummyTask = new Domain.Models.CmdTask("Test", new Domain.Models.UnlockTrigger(), "C:\\Program Files\\VideoLAN\\VLC\\vlc.exe");
      dummyTask.Arguments = "\"C:\\Videos\\Test.mp4\" -Idummy -f --no-osd --video-on-top vlc://quit";
    var app = Application.Current as App;
    app?.TaskRepo.AddTask(dummyTask);
  }
}