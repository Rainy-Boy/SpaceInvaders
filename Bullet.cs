using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceInvaders
{
    class Bullet : PictureBox
    {
        private int step = 2;

        private Timer timerMove = null;

        public Bullet()
        {
            InitializeBullet();
            InitializeTimerMove();
        }

        public void InitializeBullet()
        {
            this.Height = 12;
            this.Width = 3;
            this.BackColor = Color.Yellow;
        }

        private void InitializeTimerMove()
        {
            timerMove = new Timer();
            timerMove.Interval = 10;
            timerMove.Tick += TimerMove_Tick;
            timerMove.Start();
        }

        private void TimerMove_Tick(object sender, EventArgs e)
        {
            this.Top -= step;
            DisposeIfNotVisible();
        }

        private void DisposeIfNotVisible()
        {
            if(this.Top + this.Height < 0)
            {
                this.Dispose();
            }
        }
    }
}
