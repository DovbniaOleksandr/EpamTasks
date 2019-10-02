using System;
using System.Collections.Generic;
using System.Text;

namespace StructsTasks
{
    public enum Colors
    {
        Green = 1,
        Blue = 10,
        Red = 20,
        Purple = 30,
        White = 0,
        Black = 100
    }
    public static class Extensions
    {
        public static void ShowAllColors(this Colors colors)
        {
            var ColorsValues = Enum.GetValues(colors.GetType());
            Array.Sort(ColorsValues);
            foreach(var color in ColorsValues)
                Console.WriteLine((Colors)color);
        }
    }
}
