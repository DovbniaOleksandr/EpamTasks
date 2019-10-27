using System;
using System.IO;
using System.Xml.Serialization;

namespace SerializationTasks
{
    internal class XMLSerialization : ISerializationType
    {
        public XMLSerialization(Type typeToSerialize, string source)
        {
            type = typeToSerialize;
            Source = source;
        }

        public Type type { get; set; }
        public string Source { get; set; }

        public object Deserialize()
        {
            var serializer = new XmlSerializer(type);
            using (var fs = new FileStream(Source, FileMode.OpenOrCreate))
            {
                return serializer.Deserialize(fs);
            }
        }

        public void Serialize(object obj)
        {
            var formatter = new XmlSerializer(type);
            using (var fs = new FileStream(Source, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }
    }
}