using Avalonia.Controls;
using PineconeScheduler.Domain.Handlers;

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
  }
}