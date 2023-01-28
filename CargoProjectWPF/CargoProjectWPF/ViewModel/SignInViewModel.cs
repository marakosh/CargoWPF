using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Windows;
using CargoProjectWPF.Services.Interfaces;
using CargoProjectWPF.Model;
using GalaSoft.MvvmLight.Messaging;
using CargoProjectWPF.Message;
using System.Windows.Controls;
using CargoProjectWPF.Services.Classes;
using CargoProjectWPF.Message.Classes;
namespace CargoProjectWPF.ViewModel;
public class LoginViewModel : ViewModelBase
{
    public Dictionary<string, string> LoginDict { get; set; } = new Dictionary<string, string>();
    public string? user_info { get; set; } = "";
    private readonly INavigationService? _navigationService;
    private readonly IMessenger? _messenger;


    public LoginViewModel(INavigationService navigationService, IMessenger messenger)
    {
        var json = FileService.ReadData("Marat.json");
        if (json != null) UsersStorageModel.Info = SerializationService<Dictionary<string, UserInfoModel>>.Deserialization(json);

        _navigationService = navigationService;
        _messenger = messenger;

        _messenger.Register<ParameterMessage>(this, param =>
        {
            var User = param?.Message as UserInfoModel;
            user_info = User?.UserName;
        });

    }
    public RelayCommand RegistrationCommand
    {
        get => new(() =>
        {
            _navigationService?.NavigateTo<SignUpViewModel>();
        });
    }
    public RelayCommand<PasswordBox> LoginCommand
    {
        get => new((pass) =>
        {
            if (UsersStorageModel.Info!.ContainsKey(user_info!))
            {
                if (UsersStorageModel.Info[user_info!].Password == pass.Password)
                {
                    _navigationService?.NavigateTo<UserMenuViewModel>(new ParameterMessage { Message = UsersStorageModel.Info[user_info!] });
                }
                else MessageBox.Show("Incorrect password!");
            }
            else if (user_info == "admin" && pass.Password == "admin")
            {
                _navigationService?.NavigateTo<AdminViewModel>();
            }
            else MessageBox.Show("You aren\'t a user!");
        });
    }
}
