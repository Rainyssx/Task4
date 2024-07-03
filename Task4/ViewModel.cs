using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    using OxyPlot;
    using OxyPlot.Series;
    using System.ComponentModel;

    public class ViewModel
    { 
        public PlotModel MyModel { get; private set; }

        public ViewModel(Function ans,Analitic_Fuction analitic_ans)
        {

            MyModel = new PlotModel { Title = "Methon Milna" };
            var lineSeries = new LineSeries
            {
                Title = "Y",
                MarkerType = MarkerType.Circle
            };
            foreach(var item in ans.Answer)
            {
                lineSeries.Points.Add(new DataPoint(item.Item1,item.Item2));
            }
            var lineSeries2 = new LineSeries { Title = "Аналитическое решение", StrokeThickness = 2, Color = OxyColors.Aqua };
            foreach (var item in analitic_ans.Answer)
            {
                if (item != null)
                {
                    lineSeries2.Points.Add(new DataPoint(item.Item1, item.Item2));
                }
            }
            

            // Добавляем графики в модель
       
            MyModel.Series.Add(lineSeries2);
            MyModel.Series.Add(lineSeries);
        }

            
    
    }
}
