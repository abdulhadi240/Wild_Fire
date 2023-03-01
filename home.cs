using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helicopter_Shooter_Game_MOO_ICT
{
    public partial class home : Form
    {
        public int i;

        public home()
        {
            InitializeComponent();

        }

      

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (pictureBox1.Visible == true)
            {

                pictureBox2.Visible = true;
                pictureBox1.Visible = false;
                i = 0;

            }
            else if (pictureBox2.Visible == true)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                i = 1;


            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();

            Form1 f1 = new Form1(textBox1.Text);

            if (i == 0)
            {
                f1.player.Image = Image.FromFile(@"D:\C# client\Helicopter Shooter Game MOO ICT\Resources\blue_avatar1.png");
                f1.pictureBox1.Image = Image.FromFile(@"D:\C# client\Helicopter Shooter Game MOO ICT\Resources\small blue.png");
            }
            else
            {
                f1.player.Image = Image.FromFile(@"D:\C# client\Helicopter Shooter Game MOO ICT\Resources\red_avatar1.png");
                f1.pictureBox1.Image = Image.FromFile(@"D:\C# client\Helicopter Shooter Game MOO ICT\Resources\small red.png");
            }

            f1.Show();
        }

       
    }
}
