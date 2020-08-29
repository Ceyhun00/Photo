using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public struct Pixel
    {
        public Pixel(double r, double g, double b)
        {
            this.r = this.g = this.b = 0;
            this.R = r;
            this.G = g;
            this.B = b;
        }
        public static Pixel operator *(Pixel pixel,double num)
        {
            return new Pixel(
                         Pixel.Trim(pixel.R * num),
                         Pixel.Trim(pixel.G * num),
                         Pixel.Trim(pixel.B * num)
                        );
        }
        public static Pixel operator *(double num,Pixel pixel)
        {
            return pixel * num;
        }

        private double r;
        public double R
        {
            get
            { return r; }
            set
            { r = Check(value); }
        }

        private double g;
        public double G
        {
            get
            { return g; }
            set
            { g = Check(value); }
        }

        private double b;
        public double B
        {
            get
            { return b; }
            set
            { b = Check(value); }
        }

        public double Check(double value)
        {
            if (value > 1 || value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return value;
        }
        public static double Trim(double value)
        {
            if (value > 1) return 1;
            if (value < 0) return 0;
            return value;
        }
    }
}
