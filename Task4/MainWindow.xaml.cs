using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    using OxyPlot;
    using OxyPlot.Series;
    using static System.Net.Mime.MediaTypeNames;

    public partial class MainWindow : Window
    {
        public double x0;
        public double y0;
        public double h;
        public double start;
        public double finish;
        public MainWindow()
        
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string text1 = X0.Text;
            text1 = text1.Replace(',', '.');
            if (double.TryParse(text1, out double number1) ){ x0 = number1; }
            else { throw new ArgumentException("Ввели в поле не число1");}
            string text2 = Y0.Text;
            text2 = text2.Replace(',', '.');
            if (double.TryParse(text2, out double number2)) { y0 = number2; }
            else { throw new ArgumentException("Ввели в поле не число2"); }
            string text3 = Start.Text;
            text3 = text3.Replace(',', '.');
            if (double.TryParse(text3, out double number3)) { start = number3; }
            else { throw new ArgumentException("Ввели в поле не число3"); }
            string text4 = Finish.Text;
            text4 = text4.Replace(',', '.');
            if (double.TryParse(text4, out double number4)) { finish = number4; }
            else { throw new ArgumentException("Ввели в поле не число4"); }
            string text5 = H.Text;
            text5 = text5.Replace('.', ',');
            if (double.TryParse(text5, out double number5)) { h = number5; }
            else { throw new ArgumentException("Ввели в поле не число5"); }

            Function ans = new Function(number1, number2, number3, number4, number5);
            Analitic_Fuction analitic_answer = new Analitic_Fuction(number1, number2, number3, number4, number5);
            DataContext = new ViewModel(ans, analitic_answer);
        }

        private void X0_GotFocus(object sender, RoutedEventArgs e)
        {
            X0.Text = "";
        }

        private void Y0_GotFocus(object sender, RoutedEventArgs e)
        {
            Y0.Text = "";
        }

        private void Start_GotFocus(object sender, RoutedEventArgs e)
        {
            Start.Text = "";
        }

        private void Finish_GotFocus(object sender, RoutedEventArgs e)
        {
            Finish.Text = "";
        }

        private void H_GotFocus(object sender, RoutedEventArgs e)
        {
            H.Text = "";
        }
    }
}