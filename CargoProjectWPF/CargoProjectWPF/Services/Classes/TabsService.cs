using CargoProjectWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProjectWPF.Services.Classes;

static public class TabsService
{
    static public TabsObservableCollectionModel SortByTabs(UserInfoModel? user, TabsObservableCollectionModel? listOfTabs)
    {
        if (user != null)
        {
            foreach (var item in user?.UserOrders!)
            {
                if (!listOfTabs!.OrdersInFillial.Contains(item) && item!.Status!.InFillial!)
                {
                    listOfTabs.OrdersInFillial.Add(item);
                }
                else if (!listOfTabs.OrdersInShipped.Contains(item) && item!.Status!.Shipped!)
                {
                    listOfTabs.OrdersInShipped.Add(item);
                }
                else if (!listOfTabs.OrdersInAbroadWarehouse.Contains(item) && item!.Status!.InAbroadwarehouse!)
                {
                    listOfTabs.OrdersInAbroadWarehouse.Add(item);
                }
                if (!listOfTabs.AllPackages.Contains(item))
                {
                    listOfTabs.AllPackages.Add(item);
                }
            }
        }
        return listOfTabs!;
    }
}
