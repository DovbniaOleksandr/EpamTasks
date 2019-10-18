using System;
using System.Collections.Generic;
using System.Text;

namespace SerializationTasks
{
    interface ISerializationType
    {
        Type type { get; set; }
        public string Source { get; set; }
        void Serialize(object obj);
        object Deserialize();
    }
}
