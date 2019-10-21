using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace SerializationTasks
{
    class XMLSerialization : ISerializationType
    {
        public Type type { get; set; }
        public string Source { get; set; }

        public XMLSerialization(Type typeToSerialize, string source)
        {
            type = typeToSerialize;
            Source = source;
        }
        public object Deserialize()
        {
            XmlSerializer serializer = new XmlSerializer(type);
            using (FileStream fs = new FileStream(Source, FileMode.OpenOrCreate))
            {
                return serializer.Deserialize(fs);
            }
        }

        public void Serialize(object obj)
        {
            XmlSerializer formatter = new XmlSerializer(type);
            using (FileStream fs = new FileStream(Source, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }
    }
}
