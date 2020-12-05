using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class Game : Form
    {
        private Spaceship spaceship = null;
        private Bullet bullet = null;

        public Game()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            this.KeyDown += Game_KeyDown;

            this.BackColor = Color.Black;
            
            spaceship = new Spaceship();
            this.Controls.Add(spaceship);
            spaceship.Left = 250;
            spaceship.Top = ClientRectangle.Height - spaceship.Height;
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                FireBullet();
            }
        }

        private void FireBullet()
        {
            bullet = new Bullet();
            bullet.Left = spaceship.Left + 20;
            bullet.Top = spaceship.Top - bullet.Height;
            this.Controls.Add(bullet);
        }

    }
}
