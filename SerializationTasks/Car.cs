using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SerializationTasks
{
    [DataContract]
    [Serializable]
    public class Car
    {
        public Car(string model, double price)
        {
            Model = model;
            Price = price;
        }

        public Car()
        {
            Model = string.Empty;
            Price = 0;
        }

        [DataMember] [XmlElement] public string Model { get; set; }

        [DataMember] [XmlElement] public double Price { get; set; }
    }
}