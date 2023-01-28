using CargoProjectWPF.Message.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoProjectWPF.Message.Classes;

public class ParameterMessage
{
    public ISendable? Message { get; set; }
}
