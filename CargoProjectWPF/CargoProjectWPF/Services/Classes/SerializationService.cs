using System.Text.Json;
namespace CargoProjectWPF.Services.Classes;

public static class SerializationService<T> where T : class
{
    public static string Serialization(T item)
    {

        var json = JsonSerializer.Serialize<T>(item);

        return json;
    }
    public static T? Deserialization(string? item)
    {
        if (item != null)
        {
            return JsonSerializer.Deserialize<T>(item);
        }
        else return null;
    }
}