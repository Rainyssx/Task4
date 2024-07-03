using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Analitic_Fuction
    {
        public Tuple<double, double>[] Answer;
        double c;
        public Analitic_Fuction(double x0, double y0, double x1, double x2, double h)
        {
            int number_iteration = (int)Math.Floor((x2 - x1) / h);
            c = GetC(x0, y0);
            Answer = new Tuple<double, double>[number_iteration + 1];
            Answer[0] = Tuple.Create(x0, y0);
            for (int i=1;i< number_iteration; i++)
            {
                x0 = x0 + h;
                Answer[i] = Tuple.Create(x0, GetY(x0));
            }

        }

        double GetC(double x0, double y0)
        {
            return (y0 - x0 - 4) * Math.Exp(x0);
        }
        double GetY(double x)
        {
            return c*1/Math.Exp(x) + x + 4;

        }
    }
}
