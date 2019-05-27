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
    /// Interaction logic for MobiusControl.xaml
    /// </summary>
    public partial class MobiusControl : UserControl
    {
        public MobiusControl()
        {
            InitializeComponent();
            Sparrow.Chart.LineSeries series = new Sparrow.Chart.LineSeries();

            for(int i = 0; i < 51; i++)
            {
                series.Points.Add(new Sparrow.Chart.DoublePoint() { Data = i, Value = Mobius(i)});
            }

            chart.Series.Add(series);
        }

        private int Mobius(int n)
        {
            if (n == 1) return 1;
            else if (n == 2) return -1;

            int p = 0;

            if (n % 2 == 0)
            {
                n = n / 2;
                p++;

                if (n % 2 == 0)
                    return 0;
            }

            for (int i = 3; i <= Math.Sqrt(n); i = i + 2)
            {
                if (n % i == 0)
                {
                    n = n / i;
                    p++;

                    if (n % i == 0)
                        return 0;
                }
            }

            return (p % 2 == 0) ? -1 : 1;
        }
    }
}
