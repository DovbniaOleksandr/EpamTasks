using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomIoC
{
    public class SimpleIoC:IIoc
    {
        private readonly Dictionary<Type, Type> types = new Dictionary<Type, Type>();

        public void Register<T>()
        {
            types[typeof(T)] = typeof(T);
        }
        public void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            types[typeof(TInterface)] = typeof(TImplementation);
        }

        public TInterface Create<TInterface>()
        {
            return (TInterface)Create(typeof(TInterface));
        }

        private object Create(Type type)
        {
            if(!types.ContainsKey(type))
                throw new ArgumentException("Type wasn't register");
            var concreteType = types[type];
            var defaultCtor = concreteType.GetConstructors()[0];
            var defaultParams = defaultCtor.GetParameters();
            var parameters = defaultParams.Select(param => Create(param.ParameterType)).ToArray();
            return defaultCtor.Invoke(parameters);
        }
    }
}
