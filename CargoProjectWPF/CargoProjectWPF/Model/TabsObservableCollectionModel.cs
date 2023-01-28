using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CargoProjectWPF.Model;

public class TabsObservableCollectionModel
{
    public ObservableCollection<OrdersModel> OrdersInFillial { get; set; } = new();
    public ObservableCollection<OrdersModel> OrdersInShipped { get; set; } = new();
    public ObservableCollection<OrdersModel> OrdersInAbroadWarehouse { get; set; } = new();
    public ObservableCollection<OrdersModel> AllPackages { get; set; } = new();
}
