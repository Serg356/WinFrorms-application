using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Kursach
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {

            InitializeComponent();

 
        }
        private void smoothlyShow()
        {
            double sep = 1;
            smoothTimer = new System.Windows.Forms.Timer();
            smoothTimer.Tick += new EventHandler((s, e1) =>
            {
                if (this.Opacity < 1)
                {
                    this.Opacity *= Math.Exp(sep);
                }
            
            }
            );
            smoothTimer.Interval = 100;
            this.Opacity = Math.Exp(-8);
            smoothTimer.Start();

            //Opacity = 0;
            //double sep = 0.05;
            //smoothTimer = new System.Windows.Forms.Timer();
            //smoothTimer.Tick += new EventHandler((s, e1) =>
            //    {
            //        if (this.Opacity < 1)
            //        {
            //            this.Opacity += sep;
            //        }

            //    }
            //);
            //smoothTimer.Interval = 100;
            //smoothTimer.Start();
        }
        private void SplashScreen_Load(object sender, EventArgs e)
        {
            timer = new System.Windows.Forms.Timer();
            //timer.Interval = 2060;
            timer.Interval = 1500;
            Opacity = 0;
            Show();
            timer.Tick += new EventHandler((s, ev) =>
            {
                Hide();
                timer.Dispose();
                smoothTimer.Dispose();
                Opacity += 1;
                mainForm = new MainForm();
                mainForm.Show();


            });
            smoothlyShow();
            timer.Start();
        }
        private Timer timer;
        private Timer smoothTimer;
        private MainForm mainForm;
        private void SplashScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }
    }
}
