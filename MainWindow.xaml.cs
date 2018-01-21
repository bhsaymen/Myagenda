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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
//using System.Windows.Forms ;

using System.Windows.Threading;

using System.Threading.Tasks;
using System.Globalization;
using System.Threading;



namespace WpfApplication4
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        int hours;
        int minutes;
        int seconds;
        
        //static Label testt=testtt;
        static int intervalle;
        static int retourner;
        public static int rappeltime1;



        public static int rappeltime10;
        public static int rappeltime20;
        public static int rappeltime2;

        static System.Timers.Timer timer;

        static sbyte s123 = 0;

        public static System.Windows.Threading.DispatcherTimer dispatcherTimer;

        public static System.Windows.Threading.DispatcherTimer dispatcherTimer1;

        public static System.Windows.Threading.DispatcherTimer dispatcherTimer3;

        static string targetPath = "c:\\calander";
        static string recoverPath = "c:\\calander\\recover";
        static string dailyFile = "c:\\calander\\dailyFile.txt";

        static string recovertaskfile = "c:\\calander\\recover\\Recover.txt";
        static string recoverrappelfile = "c:\\calander\\recover\\Recoverrappel.txt";
        static string df = "c:\\calander\\df.txt";

        String delimiter0 = "test for aymen ben haj salama";
        char delimiter = '\t';
        static string nameFile = "c:\\calander\\task.txt";

        static string colorFile = "c:\\calander\\colorFile.txt";

        static string rappelfile = "c:\\calander\\rappelfile.txt";
        static DateTime start = DateTime.Now;


        DateTime today = DateTime.Now;
        int diff = 0;
        static string path1 = Environment.CurrentDirectory;
        String yourString = null;



        static string folderPath = path1 + "\\STAT\\" + start.Year;
        int count = 0;


        // Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fr-FR");
        //  Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr-FR"); 

        public MainWindow()
        {
                InitializeComponent();


            
            calendarback();
            makefile();
            //  AddSelectedDates();

            rappeltime1 = 0;
          
            rappeltime10 = 5;

            rappeltime2 = 0;
            rappeltime20 = 2;

           // rappeltime20 = 3;

            dater.Text = calendar1.SelectedDate.ToString();



            //minutes.Text = "40";
           // Priority.Text = "1";
            prty.Text = "5";

             calendar1.SelectedDate = DateTime.Now;
            //calendar1.SelectedDate = ;


            Open.Content = start;
            Close.Content = DateTime.Now;

           // DateTime dt=
            //Aymennnnn
            TimeSpan span = DateTime.Now - start;
            yourString = string.Format("{0} days, {1} hours, {2} minues, {3} seconds",
    span.Days, span.Hours, span.Minutes, span.Seconds);

            Elapsed.Content = yourString; ;

            int n = 1;


            TimeSpan time = DateTime.Now - start;
            if (verif())
            {

               // invoke(rappeltime1, rappeltime10);

                invoke(0, rappeltime10);//10   4
            }
            // else { }

           // invoke2(rappeltime2, rappeltime20); //0   6
            invoke2(0, rappeltime20); 
           
            try
            {
                rappeltime1 = getrappel1();
            }
            catch { rappeltime1 = 5; }


            try
            {
                rappeltime2= Alerte.getdailytime();
            }
            catch { rappeltime2 = 15; }

           


            timmme();
           invoke3(hours,minutes,seconds);

          //  invoke2(rappeltime2);
           // invoke2(Alerte.getdailytime());

        


        DispatcherTimer timer = new DispatcherTimer();  //  using System.Windows.Threading;
            timer.Interval = TimeSpan.FromSeconds(1);
                        timer.Tick += timer_Tick;
                        timer.Start();
                }

    void timer_Tick(object sender, EventArgs e)
    {
            // string datetest = (DateTime.Now - start).ToString("HH:mm:ss");
            // Elapsed.Content = (DateTime.Now-start).ToLongTimeString();
            //string test0= DateTime.Now.ToLongTimeString()-start.DateTime.Now.ToLongTimeString();;

            var datetimediff = new DateTime((DateTime.Now - start).Ticks);
            var TimeTook = datetimediff.ToString("HH:mm:ss");
            //string datetest =Convert.ToString(DateTime.Now - start);
          //  string datetest2 = datetest.ToString("HH:mm:ss");

            //Elapsed.Content = TimeTook;
        }



        public static void invoke(int rappeltime100, int rappeltime1000)
        {
           // rappeltime = rappeltime ;

            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, rappeltime100, rappeltime1000);
            dispatcherTimer.Start();

        }
        // MessageBox.Show(rappeltime.ToString());



        public static void dispatcherTimer_Tick(object sender, EventArgs e)
        {

            WpfWindow my = new WpfWindow();


            my.ShowDialog();



            // lblSeconds.Content = DateTime.Now.Second;


            CommandManager.InvalidateRequerySuggested();
        }



        public static void invoke2(int rappeltime200, int rappeltime2000)
        {
            //rappeltime = rappeltime ;

            
          dispatcherTimer1 = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer1.Tick += new EventHandler(dispatcherTimer1_Tick);

             dispatcherTimer1.Interval = new TimeSpan(0,  rappeltime200,rappeltime2000);
           // dispatcherTimer1.Interval = new TimeSpan(0, rappeltime200, rappeltime2000);
            dispatcherTimer1.Start();

        }
        public static void dispatcherTimer1_Tick(object sender, EventArgs e)
        {

            Alerte my = new Alerte();
          //  MessageBox.Show("min  " + rappeltime2 + "sec  " + rappeltime20);
            my.ShowDialog();

            CommandManager.InvalidateRequerySuggested();

        }










        public static void invoke3(int hours,int minutes,int seconds)
        {
            //rappeltime = rappeltime ;

            dispatcherTimer3 = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer3.Tick += new EventHandler(dispatcherTimer3_Tick);
            dispatcherTimer3.Interval = new TimeSpan(hours, minutes, seconds);
            dispatcherTimer3.Start();

        }
        public static void dispatcherTimer3_Tick(object sender, EventArgs e)
        {

            //Application.Restart();
           // MainWindow my = new MainWindow();
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
           // my.ShowDialog();
           // this

            CommandManager.InvalidateRequerySuggested();

        }





        private void button1_Click(object sender, RoutedEventArgs e)
        {


            if (MessageBox.Show("Close ?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning)
                == MessageBoxResult.Yes)
            {




                TimeSpan span = DateTime.Now - start;
                yourString = string.Format("{0} days, {1} hours, {2} minues, {3} seconds",
        span.Days, span.Hours, span.Minutes, span.Seconds);

                Elapsed.Content = yourString; ;


                System.Diagnostics.Process.Start("shutdown", "/s /f /t 5 /c  See");
            }



        }

        private void Open_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TimeSpan span = DateTime.Now - start;
            yourString = string.Format("{0} days, {1} hours, {2} minues, {3} seconds",
    span.Days, span.Hours, span.Minutes, span.Seconds);

            Elapsed.Content = yourString; ;

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
             int vv;
            bool res = int.TryParse(prty.Text, out vv);

            if (res == true)
            {


                string type = null;
                string dater = calendar1.SelectedDate.ToString();
                dater = dater.Remove(9);



                if (radioButton1.IsChecked == true)
                { type = "Entertainment"; }
                if (radioButton2.IsChecked == true)
                { type = "Business"; }
                if (radioButton3.IsChecked == true)
                { type = "Other"; }



                TextWriter writer = new StreamWriter(nameFile, true);
                TextWriter writer0 = new StreamWriter(rappelfile, true);
                // description.SelectAll();
                // string myText = description.Selection.Text;
                //  String myText = GetString(description);
                // aymen
                // String delimiter = "test for aymen ben haj salama";
                //  writer.Write(Task.Text + delimiter + Priority.Text + delimiter + calendar1.SelectedDate.ToString() + delimiter + type + delimiter + descriptionText.Text + delimiter + minutes.Text);



                if (descriptionText.Text == "")
                { descriptionText.Text = " "; }



                if (Task.Text == "")
                { Task.Text = " "; }


                writer.Write(prty.Text + delimiter + calendar1.SelectedDate.ToString().Remove(10) + delimiter + Task.Text + delimiter + descriptionText.Text + delimiter + type);



                writer.Write("\r\n");

                writer.Close();
                int rappel0;

                try
                {
                    //rappel0 = int.Parse(rappeltime);
                }

                catch { }


                // int ra00 = int.Parse(rappeltime1.ToString())  ;// 60
                writer0.Write(calendar1.SelectedDate.ToString().Remove(10) + " " + "45" + "\r\n");
                // writer0.Write();


                writer0.Close();

                Task.Text = "";
                //Priority.Text = "1";
                //minutes.Text = "30";
                descriptionText.Text = "";
                //System.Diagnostics.Process.Start("C:\\calander\\task.txt");
                MessageBox.Show(" Save ok ");
            }
            else { MessageBox.Show(" Invalid priority number"); }


        }

        private void Priority_TouchEnter(object sender, TouchEventArgs e)
        {

        }
        string GetString(RichTextBox rtb)
        {
            var textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            return textRange.Text;
        }

        private void Priority_KeyDown(object sender, KeyEventArgs e)
        {

            if (Keyboard.IsKeyDown(Key.Enter))
            {
                Add_Click(this, new RoutedEventArgs());
            }
        }

        private void show_Click(object sender, RoutedEventArgs e)
        {

            Mytasks my = new Mytasks();

            my.ShowDialog();

        }

        private void calendar1_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            string datee = calendar1.SelectedDate.ToString();
            dater.Text = datee.Remove(10);
            // calendarback();


        }






        void test()
        {
            // Timer timer = new Timer(1000);
        }

        private static Task HandleTimer()
        {
            Console.WriteLine("\nHandler not implemented...");
            throw new NotImplementedException();
        }



        /* static void timer_Elapsed(object sender, ElapsedEventArgs e)
         {
             MessageBox.Show("Timer Elapsed success");
         
         }*/


        private static void start_timer()
        {
            timer.Start();

        }


        internal static int getrappel1()
        {
            retourner = 40;
            string test = null;
            DateTime today = DateTime.Today;

            string today0 = today.ToString().Remove(10);

            string[] lines = File.ReadAllLines(rappelfile);


            for (int j = 0; j < lines.Length; j++)
            {
                test = lines[j].Remove(10);

                if (test == today0)
                {


                    retourner = int.Parse(lines[j].Remove(0, 10));
                }




            }
            return retourner;

            //string[] allLines = System.IO.File.ReadAllLines("C:\\calander\\task.txt");

        }

        public void makefile()
        {

            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }



            if (!System.IO.Directory.Exists(recoverPath))
            {
                System.IO.Directory.CreateDirectory(recoverPath);
            }


            if (!(File.Exists(nameFile)))
            {
                File.CreateText(nameFile);
            }

            if (!(File.Exists(rappelfile)))
            {
                File.CreateText(rappelfile);
            }

            if (!(File.Exists(colorFile)))
            {
                File.CreateText(colorFile);
            }


            if (!(File.Exists(dailyFile)))
            {
                File.CreateText(dailyFile);
            }

            if (!(File.Exists(df)))
            {
                File.CreateText(df);
            }
          
           // else { }


            if (new FileInfo(dailyFile).Length <= 3)
            {
                TextWriter sw2 = new StreamWriter(dailyFile);
                sw2.WriteLine("DEFAULT DAILY NEW TEXT" + '\n' + "15" + '\n' + "0" + '\n' + "0" + '\n' + "15"); //text to view , time to view in ,sound cheked ,random file or not ,Timer time
                sw2.Close();

            }


            if (new FileInfo(colorFile).Length == 0)
            {
                string color0 = Colors.Orange.ToString();
                string color1 = Colors.OrangeRed.ToString();
                string color2 = Colors.PaleGreen.ToString();
                string color3 = Colors.White.ToString();


                //  string[] allLines = System.IO.File.ReadAllLines(colorFile);


                TextWriter sw = new StreamWriter(colorFile, true);

                // allLines[index] = rtlfill.Fill.ToString();
                sw.WriteLine(color0);
                sw.WriteLine(color1);
                sw.WriteLine(color2);
                sw.WriteLine(color3);



                sw.Close();
            }

            string tasktxt = nameFile;
            string rappeltxt = rappelfile;

            string recoverRappel = System.IO.Path.Combine(recoverPath, "Recoverrappel.txt");



            string recoverTask = System.IO.Path.Combine(recoverPath, "Recovertask.txt");


            long myf = new FileInfo(nameFile).Length;

            long myf2 = new FileInfo(rappelfile).Length;

            // overwrite the destination file if it already exists.
            if (myf > 2)
            {
                System.IO.File.Copy(nameFile, recoverRappel, true);
            }

            if (myf2 > 2)
            {
                System.IO.File.Copy(rappelfile, recoverRappel, true);
            }
        }
        public static void recover()
        {
            System.IO.File.Copy(recoverrappelfile, rappelfile, true);
            System.IO.File.Copy(recovertaskfile, nameFile, true);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            color my = new color();

            my.ShowDialog();
            // recover();
        }




        public void calendarback()
        {
           // string cc = calendar1.SelectedDate.ToString();
          //  DateTime vv = DateTime.Parse(cc);

            //  MessageBox.Show(vv.Month.ToString());
            string c1;
            string c2;
            string c3;
            string c4;
             if ((today.Month == 6) || (today.Month == 7) || (today.Month == 8))
          //  if ((vv.Month == 6) || (vv.Month == 7) || (vv.Month == 8))
            {
                c1 = "#FFE4EAF0";
                c2 = "#FFECF0F4";
                c3 = "#FFFCFCFD";
                c4 = "#FFF7F724";

                fillcalendr(c1, c2, c3, c4);


            }

             if ((today.Month == 9) || (today.Month == 10) || (today.Month == 11))
          //  if ((vv.Month == 9) || (vv.Month == 10) || (vv.Month == 11))
            {


                c1 = "#FFE4EAF0";
                c2 = "#FFECF0F4";
                c3 = "#FFFCFCFD";
                c4 = "#FFF37F1D";
                fillcalendr(c1, c2, c3, c4);


            }



             if ((today.Month == 12) || (today.Month == 1) || (today.Month == 2))
           // if ((vv.Month == 12) || (vv.Month == 1) || (vv.Month == 2))
            {
                c1 = "#FFE4EAF0";
                c2 = "#FFE4EAF0";
                c3 = "#FFECF0F4";
                c4 = "#FF7BD6E6";
                fillcalendr(c1, c2, c3, c4);


            }



             if ((today.Month == 3) || (today.Month == 4) || (today.Month == 5))
           // if ((vv.Month == 3) || (vv.Month == 4) || (vv.Month == 5))
            {

                c1 = "#FFE4EAF0";
                c2 = "#FFECF0F4";
                c3 = "#FFFCFCFD";
                c4 = "#FF3DF115";
                fillcalendr(c1, c2, c3, c4);


            }



        }


        public void fillcalendr(string c1, string c2, string c3, string c4)
        {
            var color00 = (Color)ColorConverter.ConvertFromString(c1);
            var brush = new SolidColorBrush(color00);



            // Create a linear gradient brush with five stops 
            LinearGradientBrush fiveColorLGB = new LinearGradientBrush();
            fiveColorLGB.StartPoint = new Point(0.5, 0);
            fiveColorLGB.EndPoint = new Point(0.5, 1);


            
            // Create and add Gradient stops
            GradientStop blueGS = new GradientStop();
            blueGS.Color = (Color)ColorConverter.ConvertFromString(c2); ;
            blueGS.Offset = 0;
            fiveColorLGB.GradientStops.Add(blueGS);

            GradientStop blueGS2 = new GradientStop();
            blueGS.Color = (Color)ColorConverter.ConvertFromString(c2); ;
            blueGS.Offset = 0.16;
            fiveColorLGB.GradientStops.Add(blueGS2);


            GradientStop orangeGS = new GradientStop();
            orangeGS.Color = (Color)ColorConverter.ConvertFromString(c3); ;
            orangeGS.Offset = 0.16;
            fiveColorLGB.GradientStops.Add(orangeGS);

            GradientStop yellowGS = new GradientStop();
            yellowGS.Color = (Color)ColorConverter.ConvertFromString(c4); ;
            yellowGS.Offset = 1;
            fiveColorLGB.GradientStops.Add(yellowGS);



            calendar1.Background = fiveColorLGB;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Recover (Some data can be lost) ?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning)
                == MessageBoxResult.Yes)
            {

                MainWindow.recover();

                Mytasks my = new Mytasks();

                this.Close();



            }

        }


        public Boolean verif()
        {

          
            Boolean tester = false;

          
            string test = null;
            DateTime today = DateTime.Today;

            string today0 = today.ToString().Remove(10);

            string[] lines = File.ReadAllLines(rappelfile);


            for (int j = 0; j < lines.Length; j++)
            {
                test = lines[j].Remove(10);

                if (test == today0)
                {

                    tester = true;
                }




            }

            return tester;



        }


        public void timmme()
        {
            string timeminuit = start.AddDays(1).ToShortDateString() + " 00:00";
            string dateString, format;
            DateTime result;
            CultureInfo provider = CultureInfo.InvariantCulture;


            format = "g";
            TimeSpan span0;
            provider = new CultureInfo("fr-FR");
            try
            {

                result = DateTime.ParseExact(timeminuit, format, provider);
                span0 = result - today;
                // result = DateTime.ParseExact(timeminuit,dateString,provider);
               // MessageBox.Show(timeminuit + "   " + span0.Hours + "  " + span0.Minutes + "   " + span0.Seconds);
                //Math.Round(span0.TotalSeconds)+5);
                hours = span0.Hours;
                minutes = span0.Minutes;
                seconds = span0.Seconds;

            }
            catch (FormatException)
            {
                MessageBox.Show("{0} is not in the correct format.", timeminuit);
            }
        }



       

    }
}
