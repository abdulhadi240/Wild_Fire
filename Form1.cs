using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Helicopter_Shooter_Game_MOO_ICT
{
    public partial class Form1 : Form
    {

        System.Timers.Timer t;
        int h, m, s;

        bool goRight, goLeft, shot, gameOver;

        int score = 0;
        int speed = 8;
        int UFOspeed = 10;




        Random rand = new Random();

        int playerSpeed = 7;
        int index = 0;
        

        public Form1()
        {
            InitializeComponent();
        }
        public Form1(string value)
        {
            InitializeComponent();
            this.Value = value;
        }



        public string Value { get; set; }



        //  public string Value { get; set; }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;

            if (goLeft == true && player.Left > 0)
            {
                player.Left -= 20;

            }

            if (goRight == true && player.Left < 800)
            {
                player.Left += 20;

            }


            ufo.Left -= UFOspeed;

            if (ufo.Left + ufo.Width < 0)
            {
                ChangeUFO();
            }

            foreach (Control x in this.Controls)
            {

                if (x is PictureBox && (string)x.Tag == "pillar")
                {
                    //x.Left -= speed;
                    //x.Left = 40;
                    if (score > 10 && score < 20)
                    {
                        x.Left = -50;
                    }
                    else if (score > 20 && score < 40)
                    {
                        x.Left = 300;
                    }
                    else if (score > 40 && score < 50)
                    {
                        x.Left = -50;
                    }
                    else if (score > 50 && score < 70)
                    {
                        x.Left = 500;
                    }
                    else if (score > 80 && score < 90)
                    {
                        x.Left = -50;
                    }
                    else if (score > 90 && score < 110)
                    {
                        x.Left = 800;
                    }
                    else if (score > 110)
                    {
                        x.Left = 300;
                    }





                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        GameOver();
                        game_end f1 = new game_end();
                        f1.Show();
                    }

                }

                if (x is PictureBox && (string)x.Tag == "bullet")
                {
                    
                    
                    x.Left += 25;

                    if (x.Left > 900)
                    {
                        
                        RemoveBullet(((PictureBox)x));
                        
                    }


                    if (ufo.Bounds.IntersectsWith(x.Bounds))
                    {
                        t.Start();
                        RemoveBullet(((PictureBox)x));
                        score += 1;
                        ChangeUFO();
                    }

                }

            }


            if (player.Bounds.IntersectsWith(ufo.Bounds))
            {
                GameOver();
            }

            if (score > 10)
            {

                UFOspeed = 18;
            }


        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }

            if (e.KeyCode == Keys.Space && shot == false)
            {
                MakeBullet();
                shot = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (shot == true)
            {
                shot = false;
            }

            if (e.KeyCode == Keys.R && gameOver == true)
            {
                RestartGame();
            }

        }

        public void RestartGame()
        {

            goRight = false;
            goLeft = false;
            shot = false;
            gameOver = false;
            score = 0;

            UFOspeed = 10;

            txtScore.Text = "Score: " + score;

            ChangeUFO();

            //player.Top = 119;
            player.Left = 40;

            //pillar1.Left = 579;
            // pillar2.Left = 253;

            GameTimer.Start();


        }

        private void GameOver()
        {
            GameTimer.Stop();
            string a=GameTimer.ToString();

            txtScore.Text = "Score: " + score;
           game_end f = new game_end();
           f.Show();
           t.Stop();
            gameOver = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            label1.Text = Value;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pillar1_Click(object sender, EventArgs e)
        {

        }

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void ufo_Click(object sender, EventArgs e)
        {

        }

        private void txtScore_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            label1.Text = Value;
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;
        }

        private void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() => {
                s += 1;
                if (s == 60)
                {
                    s = 0;
                    m += 1;
                }
                if (m == 60)
                {
                    m = 0;
                    h += 1;
                }

                label2.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));




            }));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RemoveBullet(PictureBox bullet)
        {
            this.Controls.Remove(bullet);
            bullet.Dispose();
        }

        private void MakeBullet()
        {
            PictureBox bullet = new PictureBox();
            bullet.BackColor = Color.Maroon;
            bullet.Height = 5;
            bullet.Width = 10;

            bullet.Left = player.Left + player.Width;
            bullet.Top = player.Top + player.Height / 2;

            bullet.Tag = "bullet";

            this.Controls.Add(bullet);

        }

        private void ChangeUFO()
        {


            if (index > 3)
            {
                index = 1;
            }
            else
            {
                index += 1;
            }




            ufo.Left = 1000;

            //ufo.Top = rand.Next(20, this.ClientSize.Height - ufo.Height);

        }
    }
}
