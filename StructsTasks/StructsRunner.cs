using System;
using System.Collections.Generic;
using System.Text;
using UI;

namespace StructsTasks
{
    public class StructsRunner:IRunner
    {
        private UserInterface _ui;

        public StructsRunner(UserInterface ui)
        {
            _ui = ui;
        }

        public void Run()
        {
            _ui.Write("Enter Name:");
            string name = _ui.Read();

            _ui.Write("Enter Surname:");
            string surname = _ui.Read();

            _ui.Write("Enter Age:");
            int.TryParse(_ui.Read(), out var age);

            var person = new Person() { Name = name, Surname = surname, Age = age };

            _ui.Write($"Enter the age to compare with {person.Name}:");
            int.TryParse(_ui.Read(), out var comparativeAge);
            _ui.Write($"{person.OlderThan(comparativeAge)}");

            _ui.Write("Enter X coordinate:");
            double.TryParse(_ui.Read(), out var x);

            _ui.Write("Enter Y coordinate:");
            double.TryParse(_ui.Read(), out var y);

            _ui.Write("Enter Height:");
            double.TryParse(_ui.Read(), out var heigth);

            _ui.Write("Enter Width:");
            double.TryParse(_ui.Read(), out var width);

            var rectangle = new Rectangle()
            {
                X = x,
                Y = y,
                Height = heigth,
                Width = width
            };

            _ui.Write($"Perimeter of rectangle: {rectangle.Perimeter()}");
        }
    }
}
