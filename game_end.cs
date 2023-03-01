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
    public partial class game_end : Form
    {
        public game_end()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EXIT f1 = new EXIT();
            game_end f2 = new game_end();
            f1.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            home f = new home();
            f.Show();
            this.Hide();

        }

        
    }
}
