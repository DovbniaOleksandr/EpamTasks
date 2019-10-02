using System;
using System.Collections.Generic;
using System.Text;

namespace StructsTasks
{
    struct Person
    {
        public string Name {
            get => Name;
            set
            {
                if (value.Length > 0)
                    Name = value;
                else
                    throw new ArgumentException();
            }
        }
        public string Surname {
            get => Surname;
            set
            {
                if (value.Length > 0)
                    Name = value;
                else
                    throw new ArgumentException();
            }
        }
        public int Age {
            get => Age;
            set 
            {
                if (value > 0)
                    Age = value;
                else
                    throw new ArgumentException();
            }
        }
        public Person(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
        public string OlderThan(int n)
        {
            if (n <= 0)
                throw new ArgumentException("Value must be positive number");
            if (n > Age)
                return "{Name} {Surname} older than {n}";
            else
                return "{Name} {Surname} younger than {n}";
        }
    }
}
