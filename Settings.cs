using Guna.UI.WinForms;
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
    public partial class Settings : Form
    {
        MyDelegate ChahgePlayer, ChangeWolf;
        public Settings(MyDelegate sender, MyDelegate sender1, Image image1, Image image2)
        {
            InitializeComponent();
            gunaPictureBox1.Image = image1;
            gunaPictureBox2.Image = image2;
            ChahgePlayer = sender; ChangeWolf = sender1;
        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            GetImage(gunaPictureBox1);
            ChahgePlayer(gunaPictureBox1.Image);
        }

        public void GetImage(GunaPictureBox gunaPictureBox)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    gunaPictureBox.Image= Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void gunaPictureBox2_Click(object sender, EventArgs e)
        {
            GetImage(gunaPictureBox2);
            ChangeWolf(gunaPictureBox2.Image);
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }
    }
}
