using System;
using System.IO;
using Newtonsoft.Json;

namespace SerializationTasks
{
    public class JsonSerialization : ISerializationType
    {
        public JsonSerialization(Type typeToSerialize, string source)
        {
            type = typeToSerialize;
            Source = source;
        }

        public Type type { get; set; }
        public string Source { get; set; }

        public object Deserialize()
        {
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader(Source))
            {
                return serializer.Deserialize(sr, type);
            }
        }

        public void Serialize(object obj)
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter(Source))
            {
                serializer.Serialize(sw, obj);
            }
        }
    }
}