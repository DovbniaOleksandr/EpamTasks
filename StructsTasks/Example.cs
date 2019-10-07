using System;
using System.Collections.Generic;
using System.Text;
using UI;

namespace StructsTasks
{
    public class Example
    {
        public UserInterface UI { get; set; }

        public Example(UserInterface ui)
        {
            UI = ui;
        }

        public void Run()
        {
            UI.Write("Enter Name:");
            string name = UI.Read();

            UI.Write("Enter Surname:");
            string surname = UI.Read();

            UI.Write("Enter Age:");
            int.TryParse(UI.Read(), out var age);

            var person = new Person() { Name = name, Surname = surname, Age = age };

            UI.Write($"Enter the age to compare with {person.Name}:");
            int.TryParse(UI.Read(), out var comparativeAge);
            UI.Write($"{person.OlderThan(comparativeAge)}");

            UI.Write("Enter X coordinate:");
            double.TryParse(UI.Read(), out var x);

            UI.Write("Enter Y coordinate:");
            double.TryParse(UI.Read(), out var y);

            UI.Write("Enter Height:");
            double.TryParse(UI.Read(), out var heigth);

            UI.Write("Enter Width:");
            double.TryParse(UI.Read(), out var width);

            var rectangle = new Rectangle()
            {
                X = x,
                Y = y,
                Height = heigth,
                Width = width
            };

            UI.Write($"Perimeter of rectangle: {rectangle.Perimeter()}");
        }
    }
}
