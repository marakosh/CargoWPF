using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using CargoProjectWPF.Message;
using CargoProjectWPF.Services.Interfaces;
using System.Collections.Generic;
using CargoProjectWPF.Model;
using System.Windows;
using System.Windows.Controls;
using CargoProjectWPF.Services.Classes;
using CargoProjectWPF.Message.Classes;
using CargoProjectWPF.ViewModel;

namespace CargoProjectWPF.ViewModel;
public class RegistrationViewModel : ViewModelBase
{
    public UserInfoModel? user { get; set; }
    public string? ConfirmPassword { get; set; }
    private readonly INavigationService? _navigationService;
    public RegistrationViewModel(INavigationService navigationService)
    {
        user = new();
        _navigationService = navigationService;
        var json = FileService.ReadData("Marat.json");
        if (json != null) UsersStorageModel.Info = SerializationService<Dictionary<string, UserInfoModel>>.Deserialization(json);
    }
    public RelayCommand<PasswordBox> Registration
    {
        get => new(param =>
        {
            user.Password = param.Password;
            var a = CheckingRegistrationService.CheckUser(user, ConfirmPassword);
            if (a == null)
            {
                _navigationService?.NavigateTo<LoginViewModel>(new ParameterMessage() { Message = user });
                user = new();
            }
            else MessageBox.Show(a);
        });
    }
    public RelayCommand BackToLoginCommand
    {
        get => new(() =>
        {
            _navigationService?.NavigateTo<LoginViewModel>();
        });
    }
}
