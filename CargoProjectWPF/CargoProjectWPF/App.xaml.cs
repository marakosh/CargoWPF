using CargoProjectWPF.Services.Interfaces;
using CargoProjectWPF.View;
using CargoProjectWPF.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using SimpleInjector;
using System.Windows;
using CargoProjectWPF.Services.Classes;

namespace CargoProjectWPF;
public partial class App : Application
{
    public static Container? Container { get; internal set; }
    protected override void OnStartup(StartupEventArgs e)
    {
        Register();

        MainStartup();

        base.OnStartup(e);
    }

    private void Register()
    {
        Container = new();

        Container.RegisterSingleton<IMessenger, Messenger>();
        Container.RegisterSingleton<INavigationService, NavigationService>();

        Container.RegisterSingleton<MainViewModel>();
        Container.RegisterSingleton<SignInView>();
        Container.RegisterSingleton<SignUpViewModel>();
        Container.RegisterSingleton<UserMenuViewModel>();
        Container.RegisterSingleton<AdminViewModel>();

        Container.Verify();
    }

    private void MainStartup()
    {
        Window mainView = new MainView();

        mainView.DataContext = Container?.GetInstance<MainViewModel>();

        mainView.ShowDialog();
    }
}
