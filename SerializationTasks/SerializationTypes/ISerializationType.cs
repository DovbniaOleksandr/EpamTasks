using System;
using System.Collections.Generic;
using System.Text;

namespace SerializationTasks
{
    interface ISerializationType
    {
        Type type { get; set; }
        string Source { get; set; }
        void Serialize(object obj);
        object Deserialize();
    }
}
