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

namespace Lottery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        static Random simple = new Random(); // setup a new random
        static int f() //static int with new random in range of 1 to 50.
        {
            return simple.Next(1, 50); 
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            var combobox = sender as ComboBox; //get data from Comobobox
            int values = (int)comboBox.SelectedItem; //upcast data to 
            convert(values);
        }
        private void convert(int i)
        {
            List<int> listy = new List<int>();
            int t = 0;
            while (t < i)
            {
                int a = f();
                if (listy.Contains(a))
                {
                    a = f();
                    listy.Add(a);
                }
                else
                {
                    listy.Add(a);
                }
                t++;
            }
            StringBuilder builder = new StringBuilder();
            foreach (int list in listy)
            {
                builder.Append(list).Append(" ");
            }
            string result = builder.ToString();
            label.Content = result;
        }
        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<int> data = new List<int>();
            data.Add(1);
            data.Add(2);
            data.Add(3);
            data.Add(4);
            data.Add(5);

            var combobox = sender as ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 0;
        }
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combobox = sender as ComboBox;
            int values = (int)comboBox.SelectedItem;
            convert(values);

        }
    }
}
