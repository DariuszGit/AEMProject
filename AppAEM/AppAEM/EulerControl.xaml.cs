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
    /// Interaction logic for EulerControl.xaml
    /// </summary>
    public partial class EulerControl : UserControl
    {
        public EulerControl()
        {
            InitializeComponent();
            Sparrow.Chart.LineSeries series = new Sparrow.Chart.LineSeries();

            for (int i = 1; i < 501; i++)
            {
                series.Points.Add(new Sparrow.Chart.DoublePoint() { Data = i, Value = countDivisors(i) });
            }

            chart.Series.Add(series);
        }

        private void SieveOfEratosthenes(int n, bool[] prime, bool[] primesquare, int[] a)
        {
            for (int i = 2; i <= n; i++)
            {
                prime[i] = true;
            }

            for (int i = 0; i < ((n * n) + 1); i++)
            {
                primesquare[i] = false;
            }

            prime[1] = false;

            for (int p = 2; p * p <= n; p++)
            {
                if (prime[p] == true)
                {

                    for (int i = p * 2; i <= n; i += p)
                    {
                        prime[i] = false;
                    }
                }
            }

            int j = 0;
            for (int p = 2; p <= n; p++)
            {
                if (prime[p])
                {

                    a[j] = p;

                    primesquare[p * p] = true;
                    j++;
                }
            }
        }

        private int countDivisors(int n)
        {

            if (n == 1)
                return 1;

            bool[] prime = new bool[n + 1];
            bool[] primesquare = new bool[(n * n) + 1];

            int[] a = new int[n];

            SieveOfEratosthenes(n, prime, primesquare, a);
 
            int ans = 1;

            for (int i = 0; ; i++)
            {

                if (a[i] * a[i] * a[i] > n)
                {
                    break;
                }

                int cnt = 1;

                while (n % a[i] == 0)
                {
                    n = n / a[i];

                    cnt = cnt + 1;
                }

                ans = ans * cnt;
            }

            if (prime[n])
            {
                ans = ans * 2;
            }
            else if (primesquare[n])
            {
                ans = ans * 3;
            }
            else if (n != 1)
            {
                ans = ans * 4;
            }

            return ans; // Total divisors 
        }
    }
}
