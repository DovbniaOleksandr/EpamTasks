using System;
using System.Collections.Generic;
using System.Text;
using Logger;
using NLog;
using UI;

namespace SerializationTasks
{
    public class SerializationRunner : IRunner
    {
        public ILogger _logger { get; private set; }

        public UserInterface _ui { get; private set; }
        public SerializationRunner(UserInterface ui, ILogger logger)
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

            try
            {
                JsonSerialization js = new JsonSerialization(cars.GetType(), "cars.txt");
                BinarySerialization bs = new BinarySerialization(cars.GetType(), "cars.bin");
                XMLSerialization xs = new XMLSerialization(cars.GetType(), "cars.xml");

                js.Serialize(cars);
                bs.Serialize(cars);
                xs.Serialize(cars);

                List<Car> carsFromJSON = (List<Car>)js.Deserialize();
                List<Car> carsFromXML = (List<Car>)xs.Deserialize();
                List<Car> carsFromBinary = (List<Car>)bs.Deserialize();
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
        }
    }
}
