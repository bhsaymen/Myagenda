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

//using System.Windows.
using System.Data;

using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Navigation;
using System.ComponentModel;
using System.Threading;
//using System.dr
using System.Globalization;

//using System.cu





namespace WpfApplication4
{
    /// <summary>
    /// Logique d'interaction pour Mytasks.xaml
    /// </summary>
    public partial class Mytasks : Window
    {
        public static int index = 0;

        static string colorFile = "c:\\calander\\colorFile.txt";
        static string dailyFile = "c:\\calander\\dailyFile.txt";

        string color0 = Colors.Orange.ToString();
        string color1 = Colors.OrangeRed.ToString();
        string color2 = Colors.PaleGreen.ToString();
        string color3 = Colors.White.ToString();
        String delimiter0 = "test for aymen ben haj salama";
        char delimiter = '\t';

        string nameFile = "c:\\calander\\task.txt";
        DateTime today = DateTime.Now;
        int diff = 0;
        public Mytasks()
        {

            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();

            culture.DateTimeFormat.DateSeparator = "/";
            culture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";

            //dekadikoi arithmoi
            culture.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR");
            // Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr-FR");
            InitializeComponent();
            string ch =Alerte.getdailysound();
            string randomyes = "0";


            try {  randomyes = Alerte.getrandom(); }
            catch { randomyes = "0"; }

            if (ch=="1")
            { //sound.IsChecked = true;
            sounder.IsChecked = true;
            }

            dailyText.IsEnabled = true;
            if (randomyes == "1")
            { //sound.IsChecked = true;
                Randomtex.IsChecked = true;
            }
            

            int vv = Alerte.getdailytime()   ; //   / 60
         //   MessageBox.Show("vv"+vv);
         
            dailyText.Text = Alerte.getdailytext();

           // Alerte.
            Time.Text = vv.ToString();
            
            if (Alerte.testcheck==true){
                Time.Text = "";
            }


            timerr.Text = Alerte.gettimertext();
            color0 = readcolor(0);
            color1 = readcolor(1);
            color2 = readcolor(2);
            color3 = readcolor(3);

            var color00 = (Color)ColorConverter.ConvertFromString(color0);
            var brush = new SolidColorBrush(color00);
            r0.Fill = brush;


            var color11 = (Color)ColorConverter.ConvertFromString(color1);
            var brush11 = new SolidColorBrush(color11);
            r1.Fill = brush11;

            var color22 = (Color)ColorConverter.ConvertFromString(color2);

            var brush22 = new SolidColorBrush(color22);
            r2.Fill = brush22;


            var color33 = (Color)ColorConverter.ConvertFromString(color3);
            var brush33 = new SolidColorBrush(color33);
            r3.Fill = brush33;


          
            try
            {

                fill();
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            //string[] allLines = System.IO.File.ReadAllLines("C:\\calander\\task.txt");
            //display all lines or create some other type of collection here...
            //   gridTask.ItemsSource = allLines;

        }

        public string readcolor(int index0)
        {
            string[] lines = System.IO.File.ReadAllLines(colorFile);
            return lines[index0];
        }

        bool datebetween(DateTime dToCheck)
        {
            // string dat = "24/6/2017";
            //dToCheck = DateTime.Parse(dat);
            // int day = ((int)answer.DayOfWeek == 0) ? 7 : (int)answer.DayOfWeek;
            int numberday = ((int)today.DayOfWeek == 0) ? 7 : (int)today.DayOfWeek;
            diff = 7 - numberday;
            DateTime answer = today.AddDays(diff);
            if (dToCheck >= today && dToCheck <= answer)
            {
                // MessageBox.Show("The Date is in between the Date From and Date To");
                return true;
            }
            else
            {
                // MessageBox.Show(dToCheck +" not in "+ " "+today +"  "+answer);
                return false;
            }



        }

        void fill()
        {
            string line = null;

            DataTable dt = new DataTable();
            dt.Columns.Add("Priority", typeof(String));


            dt.Columns.Add("Date", typeof(string));

            // dt.Columns["Date"] = System.DateTime.Now.ToString("MM/dd/yyyy hh:mm tt", CultureInfo.InvariantCulture);
            //  dt.Columns

            dt.Columns.Add("Task", typeof(string));

            // dt.Columns.Add("Priority", typeof(String));



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

            dt.Columns.Add("Time", typeof(String)); //5


            

            dt.Columns.Add("Delete", typeof(Boolean));//6





            for (int i = 0; i < dt.Rows.Count; i++)   //important don t save chekbox
            {

                // dt[i][6]="2222" 

                //  dt.Rows.
                // ( dataTask.Items[i] as DataRowView).Row.ItemArray[6]="1000" ;

                // DateTime datecheck = DateTime.Parse((dataTask.Items[i] as DataRowView).Row.ItemArray[3].ToString());

                DateTime datecheck = DateTime.Parse(dt.Rows[i]["Date"].ToString());


                string date1 = datecheck.ToShortDateString();
                string date2 = today.ToShortDateString();

                // if ((datebetween(datecheck)==true)||(date1 == date2))
                if (datebetween(datecheck) == true)
                {

                    dt.Rows[i][5] = "This week";
                }

                else if (date1 == date2) { dt.Rows[i]["Time"] = "Today"; }


                else if (today > datecheck)
                { dt.Rows[i]["Time"] = "Past"; }

                else { dt.Rows[i]["Time"] = "Ealier"; }

            }

            for (int i = 0; i < dt.Rows.Count; i++)   //important don t save chekbox
            {
                //test = dt.Rows[i]["Date"].ToString(("dd/M/yyyy", CultureInfo.InvariantCulture);
                dt.Rows[i]["Delete"] = false;


            }
            dt.Columns.Add("Date2", typeof(String));


            String test = "";
            String test2 = "";
            for (int i = 0; i < dt.Rows.Count; i++)   //important don t save chekbox
            {
                //test = dt.Rows[i]["Date"].ToString(("dd/M/yyyy", CultureInfo.InvariantCulture);
                test = dt.Rows[i]["Date"].ToString();

                // test = test.Remove(11);
                test2 = test.Substring(6, 4) + test.Substring(3, 2) + test.Substring(0, 2);
                dt.Rows[i]["Date2"] = test2;
            }

            DataView dv = dt.DefaultView;
            dv.Sort = "Date2 desc";
            dt.Columns.Remove("Date2");
            DataTable sortedDT = dv.ToTable();

           
            dataTask.ItemsSource = sortedDT.DefaultView;

           
            dataTask.AutoGenerateColumns = true;
            dataTask.CanUserAddRows = false;

           


        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            TextWriter sw = new StreamWriter(nameFile);

            string text = null;
            int rowcount = dataTask.Items.Count;


            //  String delimiter = "test for aymen ben haj salama";
            string vv = "";

            for (int i = 0; i < dataTask.Items.Count; i++)   //important don t save chekbox
            {
                text = "";

                //  v v = Boolean.Parse((dataTask.Items[i] as DataRowView).Row.ItemArray[dataTask.Columns.Count-1].ToString());
                // MessageBox.Show(i.ToString()+" "+vv.ToString());
                vv = (dataTask.Items[i] as DataRowView).Row.ItemArray[dataTask.Columns.Count - 1].ToString();
                //  MessageBox.Show(vv);
                if (vv != "True")
                {
                    for (int j = 0; j < dataTask.Columns.Count - 2; j++)   //important don t save  2 last column chekbox
                    {



                        if (j == dataTask.Columns.Count - 3)
                        {
                            text = text + (dataTask.Items[i] as DataRowView).Row.ItemArray[j].ToString();
                        }
                        else
                        {

                            // aymen
                            text = text + (dataTask.Items[i] as DataRowView).Row.ItemArray[j].ToString() + delimiter;
                        }

                    }
                    sw.WriteLine(text);
                }

            }

            sw.Close();


            


            if (Time.Text == "") {
                Time.Text = "45";
            }

           //  *60


            string ch ="0";
            string rand = "0";
              //  Alerte.getdailysound();
            if (sounder.IsChecked==true)
            { ch = "1"; }
           // if ( ch=="1") {}

            if (Randomtex.IsChecked == true)
            { rand = "1"; }


            int vvv;
            bool res = int.TryParse(timerr.Text.ToString(), out vvv);

            //try

           // { }
           // catch
            if (res == false)
            { MessageBox.Show("Timer is not valid !!"); }

            bool res2 = int.TryParse(Time.Text, out vvv);



            if (res2 == false)
            { MessageBox.Show("Time is not valid !!"); }

            if ((res==true) & (res2==true)) {
                TextWriter sw2 = new StreamWriter(dailyFile, false);
                int ra = int.Parse(Time.Text);

            sw2.WriteLine(dailyText.Text + '\n' + ra + '\n' + ch + '\n' + rand + '\n' + timerr.Text.ToString()); //text to view , time to view in ,sound cheked ,random file or not ,Timer time
            sw2.Close();

            MainWindow.dispatcherTimer1.Stop();
            // MainWindow.dispatcherTimer.Stop

          //  MainWindow.rappeltime2 = ra;
            MainWindow.invoke2(ra,0);

           

            Mytasks my = new Mytasks();
            //this.Close();
            this.Close();
           // my.ShowDialog();




           // MessageBox.Show("Text file was updated.");
        }

        }
        private void dataTask_LoadingRow(object sender, DataGridRowEventArgs e)
        {


            DataRowView item = e.Row.Item as DataRowView;
            if (item != null)
            {
                DataRow row = item.Row;

                // Access cell values values if needed...
                //var colValue = row["Priority"];
                var colValue0 = row["Date"];
                //MessageBox.Show(colValue0.ToString());
                DateTime datecheck = DateTime.Parse(colValue0.ToString());

                string date1 = datecheck.ToShortDateString();
                string date2 = today.ToShortDateString();
                // Set the background color of the DataGrid row based on whatever data you like from 
                // the row.



                // if ((datebetween(datecheck)==true)||(date1 == date2))
                if ((datebetween(datecheck) == true))
                {
                    //  e.Row.Background = new SolidColorBrush(Colors.Orange);

                    var color00 = (Color)ColorConverter.ConvertFromString(color0);
                    var brush = new SolidColorBrush(color00);

                    e.Row.Background = brush;


                }

                else if (date1 == date2)
                {
                    var color00 = (Color)ColorConverter.ConvertFromString(color1);
                    var brush = new SolidColorBrush(color00);

                    e.Row.Background = brush;
                }

                else if (today > datecheck)
                {
                    var color00 = (Color)ColorConverter.ConvertFromString(color2);
                    var brush = new SolidColorBrush(color00);

                    e.Row.Background = brush;
                }
                else
                {
                    var color00 = (Color)ColorConverter.ConvertFromString(color3);
                    var brush = new SolidColorBrush(color00);

                    e.Row.Background = brush;
                }


            }
        }

        private int Int16(string p)
        {
            throw new NotImplementedException();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Recover (Some data can be lost) ?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning)
                == MessageBoxResult.Yes)
            {

                MainWindow.recover();

                Mytasks my = new Mytasks();
                
                this.Close();
         


            }


        }


        private void color(object sender, EventArgs e)
        {


            WriteableBitmap writeableBitmap = new WriteableBitmap(256, 256, 96, 96, PixelFormats.Bgr32, null);
            // ima   ColorPalette2 

            Image ColorPalette2 = new Image();

            // ColorPalette2.Source = writeableBitmap;
            // SearchColor(initialColor);

        }

        private void colorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Brush selectedColor = (Brush)(e.AddedItems[0] as PropertyInfo).GetValue(null, null);
            // rtlfill.Fill = selectedColor;
        }

        private void task_Loaded(object sender, RoutedEventArgs e)
        {
//
            //this.colorList.ItemsSource = typeof(Brushes).GetProperties();
        }

        private void r0_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void r0_MouseDown(object sender, MouseButtonEventArgs e)
        {
            index = 0;
            color my = new color();
            this.Close();

            my.ShowDialog();

            // MessageBox.Show("click");
        }

        private void r1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            index = 1;
            color my = new color();
            this.Close();

            my.ShowDialog();

        }

        private void r2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            index = 2;
            color my = new color();
            this.Close();
            my.ShowDialog();

        }

        private void r3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            index = 3;
            color my = new color();
            this.Close();

            my.ShowDialog();
        }

        private void Random_Checked(object sender, RoutedEventArgs e)
        {
            //if (dailyText.IsEnabled==true)
            dailyText.IsEnabled = false;
           // else dailyText.IsEnabled = true;
        }
       // fonction special


        public static string getrandomtext(string dailyrandom)
        {
            string[] lines = System.IO.File.ReadAllLines(dailyrandom);
            string cc = "";
            // string[] lines = System.IO.File.ReadAllLines(dailyFile);
            // return lines[1];
            int i=0;
            //i = Random.Range(0,50);
            
            try
            {
                cc = (lines[i]);
                // sw2.Close();
                // dailyFile.
            }

            catch
            {
                MessageBox.Show(" ERREUR MYTASCK +DAILY  RANDOM+ 549" + "  " + lines[0]);
            }
            return cc;
            //return lines[0];
        }

        private void Randomtex_Unchecked(object sender, RoutedEventArgs e)
        {
            dailyText.IsEnabled = true;
        }


    }
}
