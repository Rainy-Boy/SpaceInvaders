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

        public Game()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            this.KeyDown += Game_KeyDown;
            this.BackColor = Color.Black;
            AddSpaceship();
        }

        private void AddSpaceship()
        {
            spaceship = new Spaceship(this);
            spaceship.FireCooldown = 500;
            this.Controls.Add(spaceship);
            spaceship.Left = 250;
            spaceship.Top = ClientRectangle.Height - spaceship.Height;
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                spaceship.Fire();
            }
            else if (e.KeyCode == Keys.A)
            {
                spaceship.HorVelocity = -2;
            }
            else if (e.KeyCode == Keys.D)
            {
                spaceship.HorVelocity = 2;
            }
            else if (e.KeyCode == Keys.S)
            {
                spaceship.HorVelocity = 0;
            }
        }

       
    }
}
