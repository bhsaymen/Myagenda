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
//using System.Windows.Threading.DispatcherTimer;
  /*using System.Media.SystemSounds.Beep.Play();
   using  System.Media.SystemSounds.Asterisk.Play();
    using System.Media.SystemSounds.Exclamation.Play();
    using System.Media.SystemSounds.Question.Play();
   using  System.Media.SystemSounds.Hand.Play();*/
//using System.Speech.Synthesis;

namespace WpfApplication4
{
    /// <summary>
    /// Interaction logic for Alerte.xaml
    /// </summary>
    public partial class Alerte : Window
    {


        static string dailyFile = "c:\\calander\\dailyFile.txt";

        static string df = "c:\\calander\\df.txt";
        public  static Boolean testcheck ;
        public static DateTime today;
        public static int  todayy ;
        public static int v;
        public static int ttimer;
        public Alerte()
        {
            InitializeComponent();
           // wind.Height =
            string randomyes = Alerte.getrandom();
            if (randomyes == "0") // not random 0
            {
                wind.Width = 50 + getdailytext().Length * 22;


                mytext.Width = getdailytext().Length * 28;
                not.Width = 100 + getdailytext().Length * 28;
                //alertew.Width = 150 + getdailytext().Length * 12;
                mytext.Content = getdailytext();

            }
            else

            {
                wind.Width = 50 + getrandomline(df).Length * 22;


                mytext.Width = getrandomline(df).Length * 28;
                not.Width = 100 + getrandomline(df).Length * 28;
                //alertew.Width = 150 + getdailytext().Length * 12;
                mytext.Content = getrandomline(df);

            }

            SomePlaceInYourCode();
            todayy = today.Second;

            string ch = Alerte.getdailysound();
            if (ch=="0")
            {
            music();
            }

            // rappeltime ;
                           System.Windows.Threading.DispatcherTimer dispatcherTimer10;

            dispatcherTimer10 = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer10.Tick += new EventHandler(dispatcherTimer10_Tick);
            dispatcherTimer10.Interval = new TimeSpan(0, 0, 0);
            dispatcherTimer10.Start();



            v = 0;
            // MessageBox.Show(getdailytext().Length.ToString());
            testcheck = false;

            time.Content = getdailytime() +" Mn";  // 60

        
            try
            {
                ttimer = int.Parse(gettimertext());
            }
            catch { ttimer = 8; }


            System.Windows.Threading.DispatcherTimer dispatcherTimer100;

            dispatcherTimer100 = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer100.Tick += new EventHandler(dispatcherTimer100_Tick);
            dispatcherTimer100.Interval = new TimeSpan(0, 0, ttimer);
            dispatcherTimer100.Start();


             MainWindow.dispatcherTimer1.Stop();

            // MainWindow.rappeltime2 = getdailytime();



            MainWindow.invoke2(getdailytime(), 0);
           
          
           

        }

        private DateTime TimerStart { get; set; }

        private void SomePlaceInYourCode()
        {
            this.TimerStart = DateTime.Now;
            // Create and start the DispatcherTimer
        } 


        // var currentValue = DateTime.Now - this.TimerStart;

    //this.seconds.Text = currentValue.Seconds.ToString();








        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          //  MainWindow.dispatcherTimer1.Stop();
            if (show2.IsChecked==true)

            {
                MainWindow.dispatcherTimer1.Stop();
                testcheck = true;
                v = 1;

               // TextWriter sw2 = new StreamWriter(dailyFile, false);
             //   int ra = 2000; //  *60
              //  sw2.WriteLine(getdailytext() + '\n' + ra);
               // sw2.Close();

              //  MainWindow.rappeltime2 = getdailytime();
                Close();
            }
            else
            {

                MainWindow.dispatcherTimer1.Stop();
               // MessageBox.Show(getdailytime().ToString());
                MainWindow.rappeltime2 = getdailytime();

                MainWindow.invoke2(getdailytime(),0 );
                Close();
            }
        }

        public static string getdailytext()
        {
            string[] lines = System.IO.File.ReadAllLines(dailyFile);
            string cc = "DEFAULT TEXT";
            // string[] lines = System.IO.File.ReadAllLines(dailyFile);
            // return lines[1];
            try
            {
                cc = (lines[0]);
               // sw2.Close();
               // dailyFile.
            }

            catch
            {
                MessageBox.Show(" ERREUR AL get daily text" + "  187" );
            }
            return cc;
            //return lines[0];
        }


        public static int getdailytime()
        {
            int cc = 10;
            string[] lines = System.IO.File.ReadAllLines(dailyFile);
            // return lines[1];
            try
            {
                cc = int.Parse(lines[1]);
            }

            catch
            {
                MessageBox.Show(" ERREUR" + "  " + lines[1]);
            }
            return cc;
        }

        private void force_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.dispatcherTimer1.Stop();
          // MainWindow.dispatcherTimer1 = null;
           // MainWindow.dispatcherTimer1.Tick.
            Close();
        }
        private void music()
        {
            // Console.beep()
            // Console.Beep(523, 400); //re
            // Console.Beep(523, 200); //re
            // Console.Beep(659, 900); //mi
            // Console.Beep(659, 300); //mi
            Console.Beep(659, 125);
            Console.Beep(659, 125);
            Console.Beep(784, 125);
            //Console.Beep(659, 125); 

            /* Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167);
             Console.Beep(523, 125); Console.Beep(659, 125); Thread.Sleep(125);
             Console.Beep(784, 125); Thread.Sleep(375); Console.Beep(392, 125);
             Thread.Sleep(375); Console.Beep(523, 125); Thread.Sleep(250); 
             Console.Beep(392, 125); Thread.Sleep(250); Console.Beep(330, 125);
             Thread.Sleep(250); Console.Beep(440, 125); Thread.Sleep(125);
             Console.Beep(494, 125); Thread.Sleep(125); Console.Beep(466, 125); Thread.Sleep(42);
             Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(392, 125); Thread.Sleep(125);
             Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(125);
             Console.Beep(880, 125); Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(784, 125);
             Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(523, 125); 
             Thread.Sleep(125); Console.Beep(587, 125); Console.Beep(494, 125); Thread.Sleep(125); 
             Console.Beep(523, 125); Thread.Sleep(250); Console.Beep(392, 125); Thread.Sleep(250);
             Console.Beep(330, 125); Thread.Sleep(250); Console.Beep(440, 125); Thread.Sleep(125);
             Console.Beep(494, 125); Thread.Sleep(125); Console.Beep(466, 125); Thread.Sleep(42); 
             Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(392, 125); Thread.Sleep(125);
             Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(125);
             Console.Beep(880, 125); Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(784, 125);
             Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(523, 125); Thread.Sleep(125);
             Console.Beep(587, 125); Console.Beep(494, 125); Thread.Sleep(375); Console.Beep(784, 125); Console.Beep(740, 125);
             Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125);
             Thread.Sleep(167); Console.Beep(415, 125); Console.Beep(440, 125); Console.Beep(523, 125); Thread.Sleep(125);
             Console.Beep(440, 125); Console.Beep(523, 125); Console.Beep(587, 125); Thread.Sleep(250);
             Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); 
             Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(698, 125); Thread.Sleep(125); 
             Console.Beep(698, 125); Console.Beep(698, 125); Thread.Sleep(625); Console.Beep(784, 125); Console.Beep(740, 125); 
             Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); 
             Thread.Sleep(167); Console.Beep(415, 125); Console.Beep(440, 125); Console.Beep(523, 125); Thread.Sleep(125);
             Console.Beep(440, 125); Console.Beep(523, 125); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(622, 125);
             Thread.Sleep(250); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(523, 125); Thread.Sleep(1125);
             Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125);
             Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(415, 125); Console.Beep(440, 125);
             Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(440, 125); Console.Beep(523, 125); Console.Beep(587, 125);
             Thread.Sleep(250); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); 
             Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(698, 125);
             Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(698, 125); Thread.Sleep(625); Console.Beep(784, 125); 
             Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125);
             Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(415, 125); Console.Beep(440, 125); Console.Beep(523, 125); 
             Thread.Sleep(125); Console.Beep(440, 125); Console.Beep(523, 125); Console.Beep(587, 125); Thread.Sleep(250); 
             Console.Beep(622, 125); Thread.Sleep(250);
             Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(523, 125);*/

        }
              public static void invoke(int rappeltime100, int rappeltime1000)
        {
           // rappeltime =
        }
        // MessageBox.Show(rappeltime.ToString());



       private void dispatcherTimer10_Tick(object sender, EventArgs e)
        {


            var currentValue = DateTime.Now - this.TimerStart;

              lblSeconds.Content =       ttimer -currentValue.Seconds;

            // Forcing the CommandManager to raise the RequerySuggested event
            CommandManager.InvalidateRequerySuggested();
      
          


         //  CommandManager.InvalidateRequerySuggested();
        }


       private void dispatcherTimer100_Tick(object sender, EventArgs e)
       {


           // currentValue = DateTime.Now - this.TimerStart;

          // lblSeconds.Content = 8 - currentValue.Seconds;

           // Forcing the CommandManager to raise the RequerySuggested event
           //CommandManager.InvalidateRequerySuggested();
           
          // Close();
           // MessageBox.Show(getdailytime().ToString());

          // MainWindow.dispatcherTimer1.Stop();
           
          // MainWindow.rappeltime2 = getdailytime();
          if (show2.IsChecked==true)
           {
           MainWindow.dispatcherTimer1.Stop();
           testcheck = true;
           v = 1;
           }

           // TextWriter sw2 = new StreamWriter(dailyFile, false);
           //   int ra = 2000; //  *60
           //  sw2.WriteLine(getdailytext() + '\n' + ra);
           // sw2.Close();

           //  MainWindow.rappeltime2 = getdailytime();
         //  Close();

  
          // MainWindow.invoke2(getdailytime(), 0);
           //dispatcherTimer100.Stop();
           // this.sto

           Close();
           //  CommandManager.InvalidateRequerySuggested();
       }

       public static string getdailysound()
       {
           string[] lines = System.IO.File.ReadAllLines(dailyFile);
           string cc = "0";
           // string[] lines = System.IO.File.ReadAllLines(dailyFile);
           // return lines[1];
           try
           {
               cc = (lines[2]);
               // sw2.Close();
               // dailyFile.
           }

           catch
           {
               MessageBox.Show(" ERREUR alerte 313 getdaily sound" + "  " + lines[0]);
           }
           return cc;
           //return lines[0];
       }



       public static string getrandom()
       {
           string[] lines = System.IO.File.ReadAllLines(dailyFile);
           string cc = "0";
           Random rnd = new Random();
         //  int indice = rnd.Next(0,lines.Length-1);
           // string[] lines = System.IO.File.ReadAllLines(dailyFile);
           // return lines[1];
           try
           {
               cc = (lines[3]); //random text yes or no
               // sw2.Close();
               // dailyFile.
           }

           catch
           {
               MessageBox.Show(" ERREUR AL 369 getrandom " );
           }
         //  MessageBox.Show(cc);
           return cc;
           //return lines[0];
       }


       public static string gettimertext()
       {
           string[] lines = System.IO.File.ReadAllLines(dailyFile);
           string cc = "15";
           // string[] lines = System.IO.File.ReadAllLines(dailyFile);
           // return lines[1];
           try
           {
               cc = (lines[4]);
               // sw2.Close();
               // dailyFile.
           }

           catch
           {
               MessageBox.Show(" ERREUR  AL 403" + "  " );
           }
           return cc;
           //return lines[0];
       }



       public static string getrandomline(string df)
       {
           string[] lines = System.IO.File.ReadAllLines(df);
           string cc = "";
           Random rnd = new Random();
            int indice = rnd.Next(0,lines.Length-1);
           // string[] lines = System.IO.File.ReadAllLines(dailyFile);
           // return lines[1];
           try
           {
               cc = (lines[indice]); //random text yes or no
               // sw2.Close();
               // dailyFile.
           }

           catch
           {
               MessageBox.Show(" ERREUR AL 417 getrandomline wisd");
           }
           //  MessageBox.Show(cc);
           return cc;
           //return lines[0];
       }

    }
}
