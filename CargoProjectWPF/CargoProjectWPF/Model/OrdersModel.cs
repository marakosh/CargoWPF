using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProjectWPF.Model;

public class OrdersModel
{
    public string Stock { get; set; } = string.Empty;
    public int Number { get; set; }
    public string SiteLink { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Price { get; set; } = string.Empty;
    public int Currency { get; set; }
    public string Note { get; set; } = string.Empty;
    public int Amount { get; set; }
    public OrderStatusModel? Status { get; set; } = new();
}
