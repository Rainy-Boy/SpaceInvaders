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
        private List<Enemy> enemies = new List<Enemy>();
        private Timer mainTimer = null;

        public Game()
        {
            InitializeComponent();
            InitializeGame();
            InitializeMainTimer();
        }

        private void InitializeGame()
        {
            this.KeyDown += Game_KeyDown;
            this.BackColor = Color.Black;
            AddSpaceship();
            AddEnemy(3, 8);
        }

        private void AddSpaceship()
        {
            spaceship = new Spaceship(this);
            spaceship.FireCooldown = 500;
            this.Controls.Add(spaceship);
            spaceship.Left = 250;
            spaceship.Top = ClientRectangle.Height - spaceship.Height;
        }

        private void AddEnemy(int rows, int columns)
        {
            Enemy enemy = null;

            for (int j = 0; j < rows; j++)
            {
                for (int i = 0; i < columns; i++)
                {
                    enemy = new Enemy(this);
                    enemy.Left = 60 + i * 60;
                    enemy.Top = 10 + 60 * j;
                    this.Controls.Add(enemy);
                    enemies.Add(enemy);
                }
            }
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                spaceship.Fire();
            }
            else if (e.KeyCode == Keys.A)
            {
                spaceship.MoveLeft();
            }
            else if (e.KeyCode == Keys.D)
            {
                spaceship.MoveRight();
            }
            else if (e.KeyCode == Keys.S)
            {
                spaceship.MoveStop();
            }
        }

       private void InitializeMainTimer()
       {
            mainTimer = new Timer();
            mainTimer.Interval = 10;
            mainTimer.Tick += MainTimer_Tick;
            mainTimer.Start();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            CheckBulletEnemyCollision();
        }

        private void CheckBulletEnemyCollision()
        {
            foreach (var bullet in spaceship.bullets)
            {
                foreach (var enemy in enemies)
                {
                    if (bullet.Bounds.IntersectsWith(enemy.Bounds))
                    {
                        enemy.Explode();

                        this.Controls.Remove(bullet);
                        bullet.Dispose();
                        
                        bullet.Top = 0;
                        
                    }
                }
            }
        }
        

    }
}
