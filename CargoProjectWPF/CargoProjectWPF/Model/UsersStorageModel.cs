using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProjectWPF.Model;

public class UsersStorageModel
{
    public static Dictionary<string, UserInfoModel>? Info { get; set; } = new();
}
