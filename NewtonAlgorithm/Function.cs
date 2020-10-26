using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonAlgorithm
{
    class Function
    {
        private double h;
        private double Lx;
        public Function(double h, double Lx)
        {
            this.h = h;
            this.Lx = Lx;
        }
        public double f(double x)
        {
            return Math.Cos(x * Lx) / Math.Sin(x * Lx) - (x / h - h / x) / 2;
        }
        public double df(double x)
        {
            return -(Lx / (Math.Sin(x * Lx) * Math.Sin(x * Lx))) - (h / (2 * x * x)) - 1 / (2*h);
        }
        public double step()
        {
            return Math.PI/Lx; 
        }
    }
}
