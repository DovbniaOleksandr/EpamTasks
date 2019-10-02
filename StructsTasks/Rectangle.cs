using System;
using System.Collections.Generic;
using System.Text;

namespace StructsTasks
{
    struct Rectangle : ISize, ICoordinates
    {
        public double Width {
            get => Width; 
            set
            {
                if (value > 0)
                    Width = value;
                else
                    throw new ArgumentException("Width must be positive number");
            } }
        public double Height {
            get => Height;
            set
            {
                if (value > 0)
                    Width = value;
                else
                    throw new ArgumentException("Height must be positive number");
            } }
        public double X { get; set; }
        public double Y { get; set; }

        public double Perimetr() => Width * 2 + Height * 2;
    }
}
