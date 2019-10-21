using System;
using System.Collections.Generic;
using System.Text;
using Logger;
using Microsoft.VisualBasic.CompilerServices;
using NLog;
using UI;

namespace StructsTasks
{
    public class StructsRunner:IRunner
    {
        public ILogger _logger { get; private set; }
        public UserInterface _ui { get; private set; }

        public StructsRunner(UserInterface ui, ILogger logger)
        {
            _logger = logger;
            _ui = ui;
        }

        public void Run()
        {
            GetPersonData(out string name, out string surname, out int age);
            try
            {
                var person = new Person() {Name = name, Surname = surname, Age = age};
                _ui.Write($"Enter the age to compare with {person.Name}:");
                int.TryParse(_ui.Read(), out var comparativeAge);
                _ui.Write($"{person.OlderThan(comparativeAge)}");
            }
            catch (ArgumentException e)
            {
                _logger.Error(e.Message);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
            GetRectangleData(out double x,out double y, out double height, out double width);

            try
            {
                var rectangle = new Rectangle()
                {
                    X = x,
                    Y = y,
                    Height = height,
                    Width = width
                };

                _ui.Write($"Perimeter of rectangle: {rectangle.Perimeter()}");
            }
            catch (ArgumentException e)
            {
                _logger.Error(e.Message);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
        }

        private void GetPersonData(out string name, out string surname, out int age)
        {
            _ui.Write("Enter Name:");
            name = _ui.Read();

            _ui.Write("Enter Surname:");
            surname = _ui.Read();

            _ui.Write("Enter Age:");
            int.TryParse(_ui.Read(), out age);
        }

        private void GetRectangleData(out double x, out double y, out double height, out double width)
        {
            _ui.Write("Enter X coordinate:");
            double.TryParse(_ui.Read(), out x);

            _ui.Write("Enter Y coordinate:");
            double.TryParse(_ui.Read(), out y);

            _ui.Write("Enter Height:");
            double.TryParse(_ui.Read(), out height);

            _ui.Write("Enter Width:");
            double.TryParse(_ui.Read(), out width);
        }
    }
}
