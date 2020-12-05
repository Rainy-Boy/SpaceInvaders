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
        public Spaceship()
        {
            InitializeSpaceship();
        }

        public void InitializeSpaceship()
        {
            this.Height = 140;
            this.Width = 40;
            this.BackColor = Color.SteelBlue;
        }

    }
}
