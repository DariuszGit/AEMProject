using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
    /// Interaction logic for DiffieHellmanControl.xaml
    /// </summary>
    public partial class DiffieHellmanControl : UserControl
    {
        public DiffieHellmanControl()
        {
            InitializeComponent(); 
        }

        private void GenerateChart(int g, int p)
        {
            tableGrid.Children.Clear();
            tableGrid.RowDefinitions.Clear();
            tableGrid.ColumnDefinitions.Clear();

            TextBlock[,] results = new TextBlock[g + 1, g + 1];

            for (int i = 0; i <= g; i++)
            {
                tableGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(30, GridUnitType.Pixel) });
                tableGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(30, GridUnitType.Pixel) });

                if (i > 0)
                {
                    TextBlock tb = new TextBlock() { Background = new SolidColorBrush(Colors.LightBlue), Text = i.ToString(), HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch, TextAlignment = TextAlignment.Center };
                    Grid.SetColumn(tb, 0);
                    Grid.SetRow(tb, i);
                    tableGrid.Children.Add(tb);

                    tb = new TextBlock() { Background = new SolidColorBrush(Colors.LightBlue), Text = i.ToString(), HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch, TextAlignment = TextAlignment.Center };
                    Grid.SetColumn(tb, i);
                    Grid.SetRow(tb, 0);
                    tableGrid.Children.Add(tb);
                }



            }

            for (int i = 1; i <= g; i++)
            {
                for (int j = 1; j <= g; j++)
                {
                    BigInteger potega = System.Numerics.BigInteger.Pow(i, j) % p;// < -to jest to najwazniejsze


                    TextBlock tb = new TextBlock() { Background = new SolidColorBrush(Colors.Yellow), Text = potega.ToString(), HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch, TextAlignment = TextAlignment.Center };
                    Grid.SetColumn(tb, i);
                    Grid.SetRow(tb, j);
                    tableGrid.Children.Add(tb);
                    results[i, j] = tb;
                }
            }

            //Colors
            for (int x = 1; x <= g; x++)
            {
                bool noOnes = true;

                for (int y = 1; y <= g; y++)
                {
                    if (results[x, y].Text == "1")
                    {
                        results[x, y].Background = new SolidColorBrush(Colors.Red);
                        noOnes = false;
                    }                    
                }

                if (noOnes)
                {
                    for (int y = 1; y <= g; y++)
                    {
                       results[x, y].Background = new SolidColorBrush(Colors.LightGreen);
                    }
                }
            }
        }

        private ulong DiffHell(int i, int j, int p)
        {
            return (ulong)(Math.Pow(j, i) % p);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GenerateChart(Convert.ToInt32(gTextBox.Text), Convert.ToInt32(pTextBox.Text));
        }
    }
}
