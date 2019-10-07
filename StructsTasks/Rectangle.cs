using System;
using System.Collections.Generic;
using System.Text;

namespace StructsTasks
{
    internal struct Rectangle : ISize, ICoordinates
    {
        private double _width;
        private double _height;

        public double Width
        {
            get => _width;
            set
            {
                if (value > 0)
                    _width = value;
                else
                    throw new ArgumentException("Width must be positive number");
            }
        }

        public double Height
        {
            get => _height;
            set
            {
                if (value > 0)
                   _height = value;
                else
                    throw new ArgumentException("Height must be positive number");
            }
        }

        public double X { get; set; }
        public double Y { get; set; }

        public double Perimetr => Width * 2 + Height * 2;
    }
}
