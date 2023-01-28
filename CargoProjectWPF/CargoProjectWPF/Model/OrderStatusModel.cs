using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProjectWPF.Model;

public class OrderStatusModel
{
    public bool InAbroadwarehouse { get; set; }
    public bool Shipped { get; set; }
    public bool InFillial { get; set; }
}
