using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceInvaders
{
    class Enemy : PictureBox
    {
        private Timer explosionTimer = null;
        private int imageCount = 0;
        private Game game = null;

        public Enemy(Game gameForm)
        {
            game = gameForm;
            InitializeEnemy();
            
        }

        private void InitializeEnemy()
        {
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BackColor = Color.Red;
            this.Width = 40;
            this.Height = 40;
        }

        public void Explode()
        {
            this.BackColor = Color.Transparent;
            InitializeExplosionTimer();
        }

        private void InitializeExplosionTimer()
        {
            explosionTimer = new Timer();
            explosionTimer.Interval = 50;
            explosionTimer.Tick += ExplosionTimer_Tick;
            explosionTimer.Start();
        }

        private void ExplosionTimer_Tick(object sender, EventArgs e)
        {
            Explosion();
        }

        private void Explosion()
        {
            string imageName = "exp" + imageCount.ToString("000");
            this.Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
            imageCount += 1;
            if (imageCount > 22)
            {
                imageCount = 0;
                explosionTimer.Stop();
                explosionTimer.Dispose();
                this.Top = 0;
                game.Controls.Remove(this);
                this.Dispose();
            }
        }

    }
}
