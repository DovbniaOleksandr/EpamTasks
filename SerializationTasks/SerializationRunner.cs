using System;
using System.Collections.Generic;
using NLog;
using UI;

namespace SerializationTasks
{
    public class SerializationRunner : IRunner
    {
        public SerializationRunner(UserInterface ui, ILogger logger)
        {
            _logger = logger;
            _ui = ui;
        }

        public ILogger _logger { get; }

        public UserInterface _ui { get; }

        public void Run()
        {
            var cars = new List<Car>();
            cars.Add(new Car("Audi", 100000));
            cars.Add(new Car("BMW", 200000));
            cars.Add(new Car("Opel", 50000));

            try
            {
                var js = new JsonSerialization(cars.GetType(), "cars.txt");
                var bs = new BinarySerialization(cars.GetType(), "cars.bin");
                var xs = new XMLSerialization(cars.GetType(), "cars.xml");

                js.Serialize(cars);
                bs.Serialize(cars);
                xs.Serialize(cars);

                var carsFromJSON = (List<Car>) js.Deserialize();
                var carsFromXML = (List<Car>) xs.Deserialize();
                var carsFromBinary = (List<Car>) bs.Deserialize();
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
        }
    }
}