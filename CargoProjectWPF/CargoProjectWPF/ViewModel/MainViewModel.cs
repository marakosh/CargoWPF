using CargoProjectWPF.Message.Classes;
using CargoProjectWPF.Services.Classes;
using CargoProjectWPF;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.Windows;
using CargoProjectWPF.Message;
using CargoProjectWPF.Model;
using CargoProjectWPF.ViewModel;

namespace CargoProjectWPF.ViewModel;
public class MainViewModel : ViewModelBase
{
    public ViewModelBase? CurrentViewModel { get; set; }
    private readonly IMessenger _messenger;
    public MainViewModel(IMessenger messenger)
    {
        CurrentViewModel = App.Container?.GetInstance<SignIn>();

        _messenger = messenger;

        _messenger.Register<NavigationMessage?>(this, message =>
        {
            var viewModel = App.Container?.GetInstance(message!.ViewModelType!) as ViewModelBase;
            CurrentViewModel = viewModel;
        });
    }
    public RelayCommand ExitCommand
    {
        get => new(() =>
        {
            var json = SerializationService<Dictionary<string, UserInfoModel>>.Serialization(UsersStorageModel.Info!);
            FileService.SaveData(json, "Marat.json");
            App.Current.Shutdown();
        });
    }
    public WindowState State { get; set; }
    public RelayCommand MinimalizeCommand
    {
        get => new(() =>
        {
            State = WindowState.Minimized;
        });
    }
}