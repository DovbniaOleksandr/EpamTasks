using System;

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
            var colorsValues = Enum.GetValues(colors.GetType());
            Array.Sort(colorsValues);
            foreach (var color in colorsValues)
                Console.WriteLine((Colors) color);
        }
    }
}