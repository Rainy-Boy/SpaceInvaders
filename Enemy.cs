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
        public Enemy()
        {
            InitializeEnemy(); 
        }

        private void InitializeEnemy()
        {
            this.BackColor = Color.Red;
            this.Width = 40;
            this.Height = 40;
        }

    }
}
