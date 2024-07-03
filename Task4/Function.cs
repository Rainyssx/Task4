using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Function
    {
        public  Tuple<double, double>[] Answer;

        public Function(double x0,double y0, double x1 ,double x2, double h)
        {
            var x = x0;
            int number_iteration = (int)Math.Floor((x2 - x1) / h);

            var answer = getYandX(ref x, y0, h, ref number_iteration);
            Answer = MethodMilna(answer, x, h, number_iteration);
        }
        Tuple<double, double>[] getYandX(ref double x0, double y0, double h, ref int number)
        {
            /*    if (x0 == null || y0 == null) { throw new ArgumentException("Начальные условия не заданы!"); }
            */
            if (h == 0) { throw new ArgumentException("Шаг нулевой!"); }

            Tuple<double, double>[] XiandYi = new Tuple<double, double>[number + 1];
            XiandYi[0] = Tuple.Create(x0, y0);
            var n = 4;
            if (number <= 3) { n = number; }

            for (int i = 1; i < n; i++)
            {
                x0 = Math.Round(x0 + h, 3);
                var K1 = h * GetYDif(x0, y0);
                var K2 = h * GetYDif(x0 + h / 2, XiandYi[i - 1].Item2 + 1 / 2 * K1);
                var K3 = h * GetYDif(x0 + h / 2, XiandYi[i - 1].Item2 + 1 / 2 * K2);
                var K4 = h * GetYDif(x0 + h, XiandYi[i - 1].Item2 + K3);
                XiandYi[i] = Tuple.Create(x0, Math.Round(XiandYi[i - 1].Item2 + (K1 + 2 * K2 + 2 * K3 + K4) / 6, 4));
                number--;
            }

            return XiandYi;
        }

        Tuple<double, double>[] MethodMilna(Tuple<double, double>[] tuple, double x, double h, int number)
        {

            if (number <= 0) { throw new ArgumentException("Больше не надо считать!"); }
            double Yipre_i = 0;
            double Ykor_i = 0;
            for (int i = 4; i < number + 4; i++)
            {
                x = Math.Round(x + h, 3);
                Yipre_i =
                     Math.Round(tuple[i - 4].Item2 + 4 / 3 * h *
                     (2 * GetYDif(tuple[i - 3].Item1, tuple[i - 3].Item2) -
                     GetYDif(tuple[i - 2].Item1, tuple[i - 2].Item2) +
                     2 * GetYDif(tuple[i - 1].Item1, tuple[i - 1].Item2)
                     )
                     , 3)
                     ;
                Ykor_i = tuple[i - 2].Item2 + h / 3 *
                    (GetYDif(tuple[i - 2].Item1, tuple[i - 2].Item2) +
                    4 * GetYDif(tuple[i - 1].Item1, tuple[i - 1].Item2)
                    + GetYDif(x, Yipre_i)
                    );
                tuple[i] = Tuple.Create(x, Ykor_i);

            }

            return tuple;

        }

        double GetYDif(double x, double y)
        {
            return 5 + x - y;

        }
    }
}
