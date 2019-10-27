using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializationTasks
{
    public class BinarySerialization : ISerializationType
    {
        public BinarySerialization(Type typeToSerialize, string source)
        {
            type = typeToSerialize;
            Source = source;
        }

        public string Source { get; set; }
        public Type type { get; set; }

        public object Deserialize()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(Source, FileMode.OpenOrCreate))
            {
                return formatter.Deserialize(fs);
            }
        }

        public void Serialize(object obj)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(Source, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }
    }
}