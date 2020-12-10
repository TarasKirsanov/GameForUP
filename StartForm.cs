using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rabbit__Game
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

     
        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Main f = new Main(6,6,"map6.txt");
            f.Show();
            this.Hide();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {

        }
    }
}
