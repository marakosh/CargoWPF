using CargoProjectWPF.Message.Classes;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProjectWPF.Services.Interfaces;

public interface INavigationService
{
    public void NavigateTo<T>(ParameterMessage message = null) where T : ViewModelBase;
}
