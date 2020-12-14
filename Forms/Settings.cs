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
        string Name;
        MyDelegate Delegate;
        public Settings(string NameOfForm, MyDelegate sender = null)
        {
            Configarithion conf = new Configarithion();
            InitializeComponent();

            conf = JSONWorker.GetList();
            gunaTextBox1.Text = conf.CountOfLives.ToString();
            gunaTextBox2.Text = conf.DamageOfWolf.ToString();
            gunaTextBox3.Text = conf.DamageOfBomb.ToString();
            gunaTextBox4.Text = conf.HandicapTime.ToString();
            gunaPictureBox1.Image = Image.FromFile(conf.ImagePathPlayer);
            gunaPictureBox2.Image = Image.FromFile(conf.ImagePathWolf);
            gunaPictureBox3.Image = Image.FromFile(conf.ImagePathBomb);
            gunaPictureBox4.Image = Image.FromFile(conf.ImagePathPresent);
            gunaPictureBox1.ImageLocation = conf.ImagePathPlayer;
            gunaPictureBox2.ImageLocation = conf.ImagePathWolf;
            gunaPictureBox3.ImageLocation = conf.ImagePathBomb;
            gunaPictureBox4.ImageLocation = conf.ImagePathPresent;
            gunaTextBox5.Text = conf.MapForFirstLevel;
            gunaTextBox6.Text = conf.MapForSecondLevel;
            gunaTextBox7.Text = conf.MapForThirdLevel;
            gunaTextBox8.Text = conf.WolfInterval.ToString();
            guna2ComboBox1.Text = conf.LevelOfHardOnFirstLevel;
            guna2ComboBox2.Text = conf.LevelOfHardOnSecondLevel;
            guna2ComboBox3.Text = conf.LevelOfHardOnThirdLevel;
            Name = NameOfForm;
            Delegate = sender;
            
        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            GetImage(gunaPictureBox1);
            
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
                    gunaPictureBox.ImageLocation = openFileDialog.FileName;
                }
            }
        }

        private void gunaPictureBox2_Click(object sender, EventArgs e)
        {
            GetImage(gunaPictureBox2);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Configarithion configarithion = new Configarithion();
            configarithion.CountOfLives = int.Parse(gunaTextBox1.Text);
            configarithion.DamageOfWolf = int.Parse(gunaTextBox2.Text);
            configarithion.DamageOfBomb = int.Parse(gunaTextBox3.Text);
            configarithion.HandicapTime = int.Parse(gunaTextBox4.Text);
            configarithion.ImagePathPlayer = gunaPictureBox1.ImageLocation;
            configarithion.ImagePathWolf = gunaPictureBox2.ImageLocation;
            configarithion.ImagePathBomb = gunaPictureBox3.ImageLocation;
            configarithion.ImagePathPresent = gunaPictureBox4.ImageLocation;
            configarithion.MapForFirstLevel = gunaTextBox5.Text;
            configarithion.MapForSecondLevel = gunaTextBox6.Text;
            configarithion.MapForThirdLevel = gunaTextBox7.Text;
            configarithion.LevelOfHardOnFirstLevel = guna2ComboBox1.Text;
            configarithion.LevelOfHardOnSecondLevel = guna2ComboBox2.Text;
            configarithion.LevelOfHardOnThirdLevel = guna2ComboBox3.Text;
            configarithion.WolfInterval = int.Parse(gunaTextBox8.Text);
            JSONWorker.WriteFile(configarithion);
            MessageBox.Show("Data are update!");
            if(Name == "Main")
            {
                Delegate(configarithion);
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void gunaPictureBox4_Click(object sender, EventArgs e)
        {
            GetImage(gunaPictureBox4);
        }

        private void gunaPictureBox3_Click(object sender, EventArgs e)
        {
            GetImage(gunaPictureBox3);
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            if(Name == "Main")
            {
                this.Close();
            }
            else
            {
                var f = new StartForm();
                f.Show();
                this.Close();
            }
        }
    }
}
