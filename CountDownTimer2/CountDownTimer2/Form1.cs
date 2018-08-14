using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace CountDownTimer2
{
    public partial class Form1 : Form
    {
        System.Timers.Timer t;
        public int h, m, s;

        public Form1()
        {            
            InitializeComponent();
        }

       

        public void Form1_Load(object sender, EventArgs e)
        {
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += onTimeEvent;
            t.Start();
        }

        public void onTimeEvent(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
           {
               s -= 1;
               if (s < 0) {

                   s = 59;
                   m -= 1;
                   if (m < 0) {

                       m = 0;
                   }
               }

               if (s == 0)
               {
                   if (m > 0)
                   {

                       s = 59;
                       m -= 1;
                   } 
                       
               }

               if (m == 0 && s == 0)
               {

                   //m = 0;
                   // h += 1;
                   
                       t.Stop();
                       Application.Exit();
                   

               }
               

               label1.Text = string.Format("{0}:{1}", m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0') );
           }));
        }
    }
}
