using System;

namespace SerializationTasks
{
    internal interface ISerializationType
    {
        Type type { get; set; }
        string Source { get; set; }
        void Serialize(object obj);
        object Deserialize();
    }
}