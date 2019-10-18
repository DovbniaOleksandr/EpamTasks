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
        public string Model { get; set; }
        [DataMember]
        public double Price { get; set; }
        public Car(string model, double price)
        {
            Model = model;
            Price = price;
        }
    }
}