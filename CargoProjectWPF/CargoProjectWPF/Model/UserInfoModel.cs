using CargoProjectWPF.Message.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProjectWPF.Model;

public class UserInfoModel : ISendable
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? PIN { get; set; }
    public string? IDSerialNumber { get; set; }
    public string? PhoneNumber { get; set; }

    public ObservableCollection<OrdersModel>? UserOrders { get; set; } = new();

}
