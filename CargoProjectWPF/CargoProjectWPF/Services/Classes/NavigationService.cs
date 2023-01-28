using CargoProjectWPF.Message.Classes;
using CargoProjectWPF.Services.Interfaces;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;


namespace CargoProjectWPF.Services.Classes;

public class NavigationService : INavigationService
{
    private readonly IMessenger _messenger;
    public NavigationService(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void NavigateTo<T>(ParameterMessage? message) where T : ViewModelBase
    {
        _messenger.Send(message);
        _messenger.Send(new NavigationMessage() { ViewModelType = typeof(T) });
    }
}
