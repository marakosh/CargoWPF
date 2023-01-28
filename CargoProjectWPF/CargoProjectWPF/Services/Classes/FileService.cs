using System.IO;
namespace CargoProjectWPF.Services.Classes;


public class FileService
{
    public static void SaveData(string ToSave, string Where)
    {
        using (FileStream fs = new(Where, FileMode.Create))
        using (StreamWriter sw = new StreamWriter(fs))
        {
            sw.Write(ToSave);
        }
    }
    public static string? ReadData(string Where)
    {
        using (FileStream fs = new(Where, FileMode.OpenOrCreate))
        using (StreamReader sw = new StreamReader(fs))
        {
            return sw.ReadLine();
        }
    }
}
