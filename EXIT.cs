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
    public partial class EXIT : Form
    {
        public EXIT()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            home f = new home();
            f.Show();
            this.Hide();
            Form1 f1 = new Form1();
            f1.Close();
        }

        
    }
}
