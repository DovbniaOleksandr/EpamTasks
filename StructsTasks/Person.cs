using System;

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
                if (value.Length > 0)
                    _name = value;
                else
                    throw new ArgumentException();
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                if (value.Length > 0)
                    _surname = value;
                else
                    throw new ArgumentException();
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
                    throw new ArgumentException();
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
