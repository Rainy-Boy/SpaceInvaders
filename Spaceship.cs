using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceInvaders
{
    class Spaceship : PictureBox
    {
        public int FireCooldown { get; set; } = 1000;
        public int HorVelocity { get; set; } = 0;

        public List<Bullet> bullets = new List<Bullet>();

        private bool canFire = true;
        private Game game = null;
        private Timer timerCooldown = null;
        private Timer timerMove = null;
        private Timer timerAnimation = null;

        private int ImageCount = 0;

        public Spaceship(Game gameForm)
        {
            game = gameForm;
            InitializeSpaceship();
            InitializeTimerMove();
            InitializeTimerAnimation();
        }

        private void InitializeSpaceship()
        {
            this.Height = 100;
            this.Width = 40;
            this.BackColor = Color.Transparent;
            this.SizeMode = PictureBoxSizeMode.StretchImage;

            
        }

        public void MoveRight()
        {
            this.HorVelocity = 2;
        }
        public void MoveLeft()
        {
            this.HorVelocity = -2;
        }
        public void MoveStop()
        {
            this.HorVelocity = 0;
        }

        public void Fire()
        {
            if (!canFire) return;

            Bullet bullet = new Bullet();
            bullet.Left = this.Left + 20;
            bullet.Top = this.Top - bullet.Height;
            game.Controls.Add(bullet);
            bullets.Add(bullet);
            canFire = false;
            InitializeTimerCooldown();


        }

        private void InitializeTimerCooldown()
        {
            timerCooldown = new Timer();
            timerCooldown.Interval = FireCooldown;
            timerCooldown.Tick += TimerCooldown_Tick;
            timerCooldown.Start();
        }

        private void TimerCooldown_Tick(object sender, EventArgs e)
        {
            canFire = true;
            timerCooldown.Stop();
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
            this.Left += this.HorVelocity;
            CheckLocation();
        }

        private void CheckLocation()
        {
            if (this.Left <= 0)
            {
                this.HorVelocity = -this.HorVelocity;
            }
            else if (this.Left + this.Width >= game.ClientRectangle.Width)
            {
                this.HorVelocity = -this.HorVelocity;
            }
        }

        private void InitializeTimerAnimation()
        {
            timerAnimation = new Timer();
            timerAnimation.Interval = 70;
            timerAnimation.Tick += TimerAnimation_Tick;
            timerAnimation.Start();
        }


        private void TimerAnimation_Tick(object sender, EventArgs e)
        {
            AnimateSpaceShipRotation();
        }

        private void AnimateSpaceShipRotation()
        {
            string imageName;
            imageName = "rocket_on_00" + ImageCount;
            this.Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
            ImageCount += 1;
            if (ImageCount > 3)
            {
                ImageCount = 0;
            }
        }

        

    }
}
