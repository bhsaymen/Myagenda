using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


using System.IO;

using System.Data;

namespace WpfApplication4
{
    /// <summary>
    /// Interaction logic for WpfWindow.xaml
    /// </summary>
    public partial class WpfWindow : Window
    {

        string nameFile = "c:\\calander\\task.txt";


        string rappelfile = "c:\\calander\\rappelfile.txt";

        int retarder = 0;
        public WpfWindow()
        {
            InitializeComponent();
            //rappel.Text = MainWindow.
            fill();
        }


        void fill()
        {
            string line = null;

            DataTable dt = new DataTable();



           // dt.Columns.Add("Date", typeof(String));

             dt.Columns.Add("Priority", typeof(String));
            dt.Columns.Add("Date", typeof(String));
            dt.Columns.Add("Task", typeof(string));


            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Type", typeof(string));

            //dt.Columns.Add("Rappel", typeof(string));



            using (StreamReader sr = new StreamReader(nameFile))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split('\t');
                    // string[] parts = line.Split(new string[] { delimiter }, StringSplitOptions.None);

                    var row = dt.NewRow();
                    for (int i = 0; i < parts.Length; i++)
                    {
                        row[i] = parts[i];
                    }
                    // important thing!
                    dt.Rows.Add(row);
                }
                sr.Close();
            }


            DateTime today0 = DateTime.Now;
            string today000 = today0.ToShortDateString();

            string today110 = null;

            DateTime current0 = DateTime.Now;
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                // DateTime current2 = DateTime.Now;

                DataRow dr = dt.Rows[i];
                current0 = DateTime.Parse(dt.Rows[i]["Date"].ToString());
                today110 = current0.ToShortDateString();

                if (today110 != today000)
                // if( dr["Date"] == "Joe")
                {
                    //  MessageBox.Show("bbbbbbb");
                    dt.Rows.Remove(dr);
                    // dr.Delete();

                    // dt.Rows.RemoveAt(j); 
                }

            }
            // string[] datatask  =new string [] ;
            string[] arr = new string[] { };

            DateTime today = DateTime.Now;
            string today00 = today.ToShortDateString();

            string today11 = null;

            DateTime current = DateTime.Now;
            // box1.Content ="Task: "+'\t'+"Description" +'\n'+"";

            box1.Content = "Task: " + '\n';
            int k = 0;

            for (int j = 0; j < dt.Rows.Count; j++)
            {
                // DateTime current2 = DateTime.Now;

                current = DateTime.Parse(dt.Rows[j]["Date"].ToString());
                today11 = current.ToShortDateString();

                if (today11 == today00)
                {
                    k += 1;
                    box1.Content += k.ToString() + "-" + dt.Rows[j]["Task"].ToString() + ":" + '\n' + dt.Rows[j]["Description"].ToString() + "\r\n";
                    //  retarder = int.Parse(dt.Rows[j]["Rappel"].ToString());

                }
            }
            //  retarder = MainWindow.getrappel();
            try
            {
                retarder = MainWindow.getrappel1();

            }
            catch { retarder = 5; }
            retarder = MainWindow.getrappel1() ; //  / 60
            rappel.Text = retarder.ToString();


            // dt.Columns.Remove("Date");

            // dt.Columns.Remove("Rappel");
            dt.Columns.Remove("Type");
            // dt.
            // datatask.Columns.RemoveAt("Priority");

            DataView dv = dt.DefaultView;
            dv.Sort = "Priority asc";
            //dt.Columns.Remove("Date2");
            DataTable sortedDT = dv.ToTable();

           
            datatask.ItemsSource = sortedDT.DefaultView;


            datatask.AutoGenerateColumns = true;
            datatask.CanUserAddRows = false;
            //  datatask.Columns.RemoveAt(1);
            //




        }

        private void datatask_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // MessageBox.Show("Ok it work"); 
        }

        private void datatask_MouseEnter(object sender, MouseEventArgs e)
        {


        }








        void setrappel(string vvvv)
        {

            //  if (!(File.Exists(filename))) {
            //  File.CreateText(filename);
            // }

            int retourner = 40;
            string test = null;
            DateTime today = DateTime.Today;

            string today0 = today.ToString().Remove(10);

            string[] lines = File.ReadAllLines(rappelfile);


            for (int j = 0; j < lines.Length; j++)
            {
                test = lines[j].Remove(10);

                if (test == today0)
                {

                    lines[j] = today0 + " " + vvvv;
                    //  retourner = int.Parse(lines[j].Remove(0, 10));
                }




            }

            File.WriteAllLines(rappelfile, lines);



        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
         //   setrappel(rappel.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int vv;
            bool res = int.TryParse(rappel.Text, out vv);

          //  MessageBox.Show("Aymennnnnnn");
            // bool res = int.TryParse(rappel.Text);
          //  MessageBox.Show(rappel.Text.ToString());

            if (res == true)
            {
              //  MessageBox.Show(res.ToString());

                if (show3.IsChecked == true)
                {
                    MainWindow.dispatcherTimer.Stop();
                    Close();
                }
                else
                {

                    int ra = int.Parse(rappel.Text) ;
                    setrappel(ra.ToString());

                    MainWindow.dispatcherTimer.Stop();
                    MainWindow.rappeltime1 = ra;
                    MainWindow.invoke(ra,0);
                    Close();
                }
                // }

            }


            else
            {
                MessageBox.Show("Enter a valid number");
            }
            // catch (Exception ex) { MessageBox.Show(ex+"Enter a valid number"); }

            //  MainWindow.rappeltime = int.Parse(rappel.Text);

        }

        private void show_Checked(object sender, RoutedEventArgs e)
        {

        }




    }
}
