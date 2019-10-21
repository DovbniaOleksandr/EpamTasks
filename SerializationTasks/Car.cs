using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
namespace SerializationTasks
{
    [DataContract]
    [Serializable]
    public class Car
    {
        [DataMember]
        [XmlElement]
        public string Model { get; set; }
        [DataMember]
        [XmlElement]
        public double Price { get; set; }
        public Car(string model, double price)
        {
            Model = model;
            Price = price;
        }

        public Car()
        {
            Model = String.Empty;
            Price = 0;
        }
    }
}