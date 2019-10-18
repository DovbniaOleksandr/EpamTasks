using System;
using System.Collections.Generic;
using System.Text;
using Logger;
using UI;

namespace SerializationTasks
{
    public class SerializationRunner : IRunner
    {
        public ILoggerHelper _logger { get; private set; }

        public UserInterface _ui { get; private set; }
        public SerializationRunner(UserInterface ui, ILoggerHelper logger)
        {
            _logger = logger;
            _ui = ui;
        }

        public void Run()
        {
            List<Car> cars = new List<Car>();
            cars.Add(new Car("Audi", 100000));
            cars.Add(new Car("BMW", 200000));
            cars.Add(new Car("Opel", 50000));

            BinarySerialization bs = new BinarySerialization();
            bs.type = cars.GetType();
            bs.Source = "cars.dat";
            bs.Serialize(cars);

            List<Car> dcars = (List<Car>)bs.Deserialize();
            foreach (var dca in dcars)
            {
                _ui.Write(dca.Model);
            }
        }
    }
}
