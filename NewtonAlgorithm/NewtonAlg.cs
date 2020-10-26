using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonAlgorithm
{
    delegate double func1(double x);
    delegate double func2(double x);
    class NewtonAlg
    {
        func1 f; func2 df;
        private double eps;
        private double step;
        private int count;
        public List<double> ans = new List<double>(); //n решений уравнений
        public double ans1; //решение уравнения с конкретным начальным приближением
        public NewtonAlg(func1 f, func2 df, double eps, int count)
        {
            this.f = f; this.df = df;
            this.eps = eps;
            this.count = count;
        }
        public void setStep(double step)
        {
            this.step = step;
        }
        public double calculateSingle(double x)
        {
            double x0, x1;
            x0 = x;
            x1 = x0 - f(x0) / df(x0);
            while (Math.Abs(f(x1)) > eps)
            {
                x0 = x1;
                x1 = x0 - f(x0) / df(x0);
            }
            ans1 = x1;
            return x1;
        }
        public void calculateAll()
        {
            ans.Add(calculateSingle(step/2));
            for(int i = 0; i < count; i++)
            {
                ans.Add(calculateSingle(ans1 + step));
            }
        }
    }
}
