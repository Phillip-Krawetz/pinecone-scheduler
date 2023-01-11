using Avalonia.Controls;
using PineconeScheduler.Domain.Handlers;

namespace PineconeScheduler.Client.Views;

public partial class MainWindow : Window
{
  public MainWindow()
  {
    InitializeComponent();
    var taskHandler = new TaskHandler();
    Closing += taskHandler.CleanUp;
  }
}