using System;
using System.Linq;

namespace StructsTasks
{
    internal struct Person
    {
        public Person(string name, string surname, int age)
            : this()
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        private string _name;
        private string _surname;
        private int _age;

        public string Name
        {
            get => _name;
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Name is null");
                if (value.Any(char.IsDigit))
                    throw new ArgumentException("Name shouldn't contain any number");
                if (!string.IsNullOrEmpty(value))
                    _name = value;
                else
                    throw new ArgumentException("Name length must be greater then 0");
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Surname is null");
                if (value.Any(char.IsDigit))
                    throw new ArgumentException("Surname shouldn't contain any number");
                if (!string.IsNullOrEmpty(value))
                    _surname = value;
                else
                    throw new ArgumentException("Surname length must be greater then 0");
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value > 0)
                    _age = value;
                else
                    throw new ArgumentException("Age must be positive number");
            }
        }

        public string OlderThan(int n)
        {
            if (n <= 0)
                throw new ArgumentException("Value must be positive number");
            return n < Age ? $"{Name} {Surname} older than {n}" : $"{Name} {Surname} younger than {n}";
        }
    }
}