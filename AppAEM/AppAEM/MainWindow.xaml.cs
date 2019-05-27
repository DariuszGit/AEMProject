using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppAEM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Sparrow.Chart.LineSeries series = new Sparrow.Chart.LineSeries();
            //series.Points.Add(new Sparrow.Chart.DoublePoint() { Data = 4.5, Value = 3.5 });
            //series.Points.Add(new Sparrow.Chart.DoublePoint() { Data = 6, Value = 5 });
            //chart.Series.Add(series);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            contentGrid.Children.Clear();
            contentGrid.Children.Add(new MobiusControl());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            contentGrid.Children.Clear();
            contentGrid.Children.Add(new EulerControl());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            contentGrid.Children.Clear();
            contentGrid.Children.Add(new DiffieHellmanControl());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            contentGrid.Children.Clear();
            contentGrid.Children.Add(new RSAControl());
        }
    }
}
