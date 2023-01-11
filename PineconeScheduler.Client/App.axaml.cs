using System;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using PineconeScheduler.Client.ViewModels;
using PineconeScheduler.Client.Views;

namespace PineconeScheduler.Client;

public partial class App : Application
{
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

    var exitIcon = new NativeMenuItem();
    exitIcon.Header = "Exit";
    exitIcon.Click += ExitCommand;

    icon.Menu.Items.Add(exitIcon);

    icons.Add(icon);
  }

  public void ExitCommand(object? sender, object args)
  {
    (App.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.Shutdown();
  }
}