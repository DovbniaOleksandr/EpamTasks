using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SerializationTasks
{
    public class JsonSerialization : ISerializationType
    {
        public Type type { get; set; }
        public string Source { get; set; }

        public JsonSerialization(Type typeToSerialize, string source)
        {
            type = typeToSerialize;
            Source = source;
        }

        public object Deserialize()
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader sr = new StreamReader(Source))
            {
                return serializer.Deserialize(sr, type);
            }
        }

        public void Serialize(object obj)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(Source))
            {
                serializer.Serialize(sw, obj);
            }
        }
    }
}
