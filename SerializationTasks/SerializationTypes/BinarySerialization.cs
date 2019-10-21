using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SerializationTasks
{
    public class BinarySerialization : ISerializationType
    {
        public string Source { get; set; }
        public Type type { get; set; }

        public BinarySerialization(Type typeToSerialize, string source)
        {
            type = typeToSerialize;
            Source = source;
        }

        public object Deserialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(Source, FileMode.OpenOrCreate))
            {
                return formatter.Deserialize(fs);
            }
        }

        public void Serialize(object obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(Source, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs ,obj);
            }
        }
    }
}
