using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

public static class Utils
{
    public static T FromJSON<T>(string jsonFilePath) => 
        JsonSerializer.Create()
            .Deserialize<T>(
                new JsonTextReader(
                    new StringReader(
                        File.ReadAllText(jsonFilePath))));
}