using System.IO;
using Newtonsoft.Json;

public static class Utils
{
    public static T FromJSON<T>(string jsonFilePath) => 
        JsonSerializer.Create()
            .Deserialize<T>(
                new JsonTextReader(
                    new StringReader(
                        File.ReadAllText(jsonFilePath))));
}