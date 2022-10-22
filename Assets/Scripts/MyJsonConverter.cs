using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

public static class MyJsonConverter
{
    // Deserialize from json string
    public static T Deserialize<T>(string body)
    {
        using (var stream = new MemoryStream())
        using (var writer = new StreamWriter(stream))
        {
            writer.Write(body);
            writer.Flush();
            stream.Position = 0;
            var serializer = new DataContractJsonSerializer(typeof(T));
            return (T)serializer.ReadObject(stream);
        }
    }

    public static string Serialize<T>(T item)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            new DataContractJsonSerializer(typeof(T)).WriteObject(ms, item);
            return Encoding.Default.GetString(ms.ToArray());
        }
    }
}
