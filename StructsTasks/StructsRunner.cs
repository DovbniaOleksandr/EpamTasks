using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using UI;

namespace StructsTasks
{
    public class StructsRunner:IRunner
    {
        public UserInterface _ui { get; private set; }
        public bool Succeed { get; private set; }
        public IList<string> Errors { get; private set; }

        public StructsRunner(UserInterface ui)
        {
            Succeed = false;
            _ui = ui;
            Errors = new List<string>();
        }

        public void Run()
        {
            Succeed = true;
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
                Errors.Add(e.Message);
                Succeed = false;
            }
            catch (Exception e)
            {
                Errors.Add(e.Message);
                Succeed = false;
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
                Errors.Add(e.Message);
                Succeed = false;
            }
            catch (Exception e)
            {
                Errors.Add(e.Message);
                Succeed = false;
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
