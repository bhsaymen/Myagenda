using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.IO;


namespace WpfApplication4
{
    /// <summary>
    /// Interaction logic for color.xaml
    /// </summary>
    public partial class color : Window
    {

        static string colorFile = "c:\\calander\\colorFile.txt";
        public color()
        {
            InitializeComponent();
            // MessageBox.Show(Mytasks.index.ToString());
            //  fill(Mytasks.index);
        }

        private void Window_Loaded_000(object sender, RoutedEventArgs e)
        {

        }

        private void colorList_SelectionChanged00(object sender, SelectionChangedEventArgs e)
        {
            Brush selectedColor = (Brush)(e.AddedItems[0] as PropertyInfo).GetValue(null, null);
            rtlfill.Fill = selectedColor;
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void colorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Brush selectedColor = (Brush)(e.AddedItems[0] as PropertyInfo).GetValue(null, null);
            rtlfill.Fill = selectedColor;
            fill(Mytasks.index);
            // MessageBox.Show(selectedColor.ToString());
        }
        public void fill(int index)
        {

            // if (new FileInfo(colorFile).Length != 0){


            string[] lines = System.IO.File.ReadAllLines(colorFile);
            // MessageBox.Show(lines[0]);
            lines[index] = rtlfill.Fill.ToString();
            // MessageBox.Show(lines[0]);
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(colorFile))
            {
                foreach (string line in lines)
                {
                    // If the line doesn't contain the word 'Second', write the line to the file.

                    file.WriteLine(line);

                }
            }
            // string[] readText = File.ReadAllLines(path);

            //TextWriter sw = new StreamWriter(colorFile);


            // sw.WriteLine(allLines);



            // sw.Close();
            //}



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Mytasks my = new Mytasks();
            this.Close();

            my.ShowDialog();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            this.colorList.ItemsSource = typeof(Brushes).GetProperties();
        }
    }
}

