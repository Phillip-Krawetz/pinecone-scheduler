using System;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using PineconeScheduler.Client.ViewModels;
using PineconeScheduler.Client.Views;
using PineconeScheduler.Domain.Handlers;
using PineconeScheduler.Storing.Repositories;

namespace PineconeScheduler.Client;

public partial class App : Application
{
  private TaskHandler _taskHandler = new TaskHandler();
  public override void Initialize()
  {
    AvaloniaXamlLoader.Load(this);
  }

  public override void OnFrameworkInitializationCompleted()
  {
    if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
    {
      desktop.MainWindow = new MainWindow
      {
        DataContext = new MainWindowViewModel(),
      };
    }

    InitializeTray();
    InitializeRepository();

    base.OnFrameworkInitializationCompleted();
  }

  private void InitializeTray()
  {
    var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
    var icons = new TrayIcons();
    var icon = new TrayIcon();
    icon.Menu = new NativeMenu();
    icon.ToolTipText = "Pinecone";
    icon.Icon = new WindowIcon(assets?.Open(
        new Uri("avares://PineconeScheduler.Client/Assets/avalonia-logo.ico")));

    var openItem = new NativeMenuItem();
    openItem.Header = "Open";
    openItem.Click += OpenCommand;

    var exitItem = new NativeMenuItem();
    exitItem.Header = "Exit";
    exitItem.Click += ExitCommand;

    icon.Menu.Items.Add(openItem);
    icon.Menu.Items.Add(exitItem);

    icon.Clicked += OpenCommand;

    icons.Add(icon);
  }

  private void InitializeRepository()
  {
    var repo = new TaskRepository();
    _taskHandler.AddTasks(repo.AllTasks);
  }

  public void ExitCommand(object? sender, object args)
  {
    _taskHandler.CleanUp();
    (App.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.Shutdown();
  }

  public void OpenCommand(object? sender, object args)
  {
    if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
    {
      desktop.MainWindow.Show();
    }
  }
}