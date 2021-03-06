﻿using System;
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

    public partial class Main : Form
    {
        Grid grid;
        Rabbit player;
        Wolf wolf;
        PictureBox playerImage, WolfImage, bombImage, PresentImage;
        Timer TimerForPlayer, TimerForFirstMoveEnemy, TimerStepEnemy, TimerForSecondMoveEnemy,TimerForBomb,TimeBefoorBoom,TimeBoom,TimerForPresent;
        List<PictureBox> walls = new List<PictureBox>();
        int StepX = 0, StepY = 0;
        int StepEnemyX = 0, StepEnemyY = 0;
        Configarithion conf;
        PictureBox[] PointsOfHealth;
        int CountOfHealthNow;
        string complex;
        Bomb bomb;
        Present present;
        int WhatTypeOfEnemyMove;

        public Main(int RowCount, int ColumnCount, string path, string complexity)
        {
            InitializeComponent();
            conf = JSONWorker.GetList();
            //grid = new Grid(this.Size.Height, this.Size.Width, 10, 10, "map.txt");
            grid = new Grid(720, 720, RowCount, ColumnCount, path);
            player = new Rabbit(0, 0, conf.CountOfLives,conf.ImagePathPlayer);
            wolf = new Wolf(RowCount - 1, ColumnCount - 1, conf.ImagePathWolf);
            playerImage = new PictureBox();
            WolfImage = new PictureBox();
            bombImage = new PictureBox();
            PresentImage = new PictureBox();

            WolfImage.Location = new Point(wolf.GetPosition().X * grid.WidthOfCell, wolf.GetPosition().Y * grid.HeightOfCell);
            WolfImage.Height = grid.HeightOfCell;
            WolfImage.Width = grid.WidthOfCell;
            WolfImage.Image = Image.FromFile(wolf.ImagePath);
            WolfImage.Visible = true;
            WolfImage.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(WolfImage);

            playerImage.Location = new Point(player.GetPosition().X * grid.WidthOfCell, player.GetPosition().Y * grid.HeightOfCell);
            playerImage.Height = grid.HeightOfCell;
            playerImage.Width = grid.WidthOfCell;
            playerImage.Image = Image.FromFile(player.ImagePath);
            playerImage.Visible = true;
            playerImage.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(playerImage);

            present = new Present(grid,player.GetPosition(),wolf.GetPosition());
            PresentImage.Location = new Point(present.GetPosition().X * grid.WidthOfCell, present.GetPosition().Y * grid.HeightOfCell);
            PresentImage.Height = grid.HeightOfCell;
            PresentImage.Width = grid.WidthOfCell;
            PresentImage.Image = Image.FromFile(conf.ImagePathPresent);
            PresentImage.Visible = true;
            PresentImage.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(PresentImage);


            TimerForPlayer = new Timer();
            TimerForPlayer.Interval = 10;
            TimerForPlayer.Tick += Step;

            for (int i = 0; i < grid.countOfRows; ++i)
            {
                for (int j = 0; j < grid.countOfColumns; j++)
                {
                    if (!grid.IsFree(i, j))
                    {
                        walls.Add(new PictureBox());

                        walls[walls.Count-1].Height = grid.HeightOfCell;
                        walls[walls.Count - 1].Width = grid.WidthOfCell;
                        walls[walls.Count - 1].Image = Image.FromFile("wall.jpg");
                        walls[walls.Count - 1].Visible = true;
                        walls[walls.Count - 1].SizeMode = PictureBoxSizeMode.StretchImage;

                        walls[walls.Count - 1].Location = new Point(i * grid.WidthOfCell, j * grid.HeightOfCell);
                        this.Controls.Add(walls[walls.Count - 1]);
                    }
                }
            }

            PointsOfHealth = new PictureBox[conf.CountOfLives];
            int start = 180;
            CountOfHealthNow = conf.CountOfLives;
            for (int i = 0; i < conf.CountOfLives; i++)
            {
                PointsOfHealth[i] = new PictureBox();
                PointsOfHealth[i].Image = Image.FromFile("broken-heart.png");
                panel1.Controls.Add(PointsOfHealth[i]);
                PointsOfHealth[i].Location = new Point(15,start);
                start += 30;
                PointsOfHealth[i].Width = 30;
                PointsOfHealth[i].Height = 30;
                PointsOfHealth[i].SizeMode = PictureBoxSizeMode.StretchImage;
            }

            
            complex = complexity;
            if(complexity == "Light")
                StupitMoveEnemy();
            if (complexity == "Middle")
                StupitMoveEnemy1();
            if(complexity == "Hard")
                WaveMove();
            BombAppeard();

            TimerForPresent = new Timer();
            TimerForPresent.Interval = conf.HandicapTime*1000;
            TimerForPresent.Tick += TickForHandicate;
            
        }

        private void BombAppeard()
        {
            TimerForBomb = new Timer();
            TimerForBomb.Interval = 5000;
            TimerForBomb.Tick += TickForBomb;
            TimerForBomb.Enabled = true;

            TimeBefoorBoom = new Timer();
            TimeBefoorBoom.Interval = 3000;
            TimeBefoorBoom.Tick += TickBeforeBoom;

            TimeBoom = new Timer();
            TimeBoom.Interval = 1000;
            TimeBoom.Tick += TickBoom;
        }

        private void StupitMoveEnemy()
        {
            WhatTypeOfEnemyMove = 1;
            TimerForFirstMoveEnemy = new Timer();
            TimerForFirstMoveEnemy.Interval = conf.WolfInterval*1000;
            TimerForFirstMoveEnemy.Tick += StepEveryOneSecond;

            TimerStepEnemy = new Timer();
            TimerStepEnemy.Interval = 10;
            TimerStepEnemy.Tick += Step_of_wolf;
            TimerForFirstMoveEnemy.Enabled = true;

        }

        private void StupitMoveEnemy1()
        {
            WhatTypeOfEnemyMove = 2;
            TimerForSecondMoveEnemy = new Timer();
            TimerForSecondMoveEnemy.Interval = conf.WolfInterval * 1000;
            TimerForSecondMoveEnemy.Tick += StepEveryOneSecond1;

            TimerStepEnemy = new Timer();
            TimerStepEnemy.Interval = 10;
            TimerStepEnemy.Tick += Step_of_wolf;
            TimerForSecondMoveEnemy.Enabled = true;
        }

        private void WaveMove()
        {
            WhatTypeOfEnemyMove = 2;
            TimerForSecondMoveEnemy = new Timer();
            TimerForSecondMoveEnemy.Interval = conf.WolfInterval * 1000;
            TimerForSecondMoveEnemy.Tick += WaveAlgorithmTick;

            TimerStepEnemy = new Timer();
            TimerStepEnemy.Interval = 10;
            TimerStepEnemy.Tick += Step_of_wolf;
            TimerForSecondMoveEnemy.Enabled = true;
        }

        public void ChoseStep(int x, int y, Timer timer)
        {
            if (grid.IsFree(player.GetPosition().X + x, player.GetPosition().Y + y))
            {
                player.UpdatePosition(x, y);
                player.IsGoing = true;
                StepX = 2 * x; StepY = 2 * y;
                timer.Enabled = true;
            }
        }

        public void ChoseStepForEnemy(int x, int y, Timer timer)
        {
            if (grid.IsFree(wolf.GetPosition().X + x, wolf.GetPosition().Y + y))
            {
                wolf.UpdatePosition(x, y);
                StepEnemyX = 2 * x; StepEnemyY = 2 * y;
                timer.Enabled = true;
                Choosing = false;
            }
            else
            {
                GoWall = false;
            }
        }

        public void Step(object sender, EventArgs e)
        {
            playerImage.Location = new Point(playerImage.Location.X + StepX, playerImage.Location.Y + StepY);
            if (playerImage.Location.X == player.GetPosition().X * grid.WidthOfCell && playerImage.Location.Y == player.GetPosition().Y * grid.HeightOfCell)
            {
                TimerForPlayer.Enabled = false;
                player.IsGoing = false;
                if (wolf.GetPosition().X == player.GetPosition().X && wolf.GetPosition().Y == player.GetPosition().Y)
                    QuolityOfLifesCheck();
                if(present.GetPosition().X == player.GetPosition().X && present.GetPosition().Y == player.GetPosition().Y)
                {
                    
                    if (complex == "Light")
                        TimerForFirstMoveEnemy.Enabled = false;
                    else
                        TimerForSecondMoveEnemy.Enabled = false;
                    this.Controls.Remove(PresentImage);
                    TimerForPresent.Enabled = true;
                }
                if (player.GetPosition().X == player.GetPosition().Y && player.GetPosition().X == 5 && grid.countOfColumns == 6)
                {
                    DialogResult result = MessageBox.Show(
                         "Вы прошли 1 уровень!! \n" +
                         "Желаете продолжить?",
                         "Сообщение",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    if (result.ToString() == "Yes")
                    {
                        grid = new Grid(720, 720, 8, 8, conf.MapForSecondLevel);
                        player = new Rabbit(0, 0, 3, conf.ImagePathPlayer);
                        wolf = new Wolf(7, 7, conf.ImagePathWolf);
                        Main f = new Main(8, 8, conf.MapForSecondLevel,conf.LevelOfHardOnSecondLevel);
                        
                        f.Show();
                        this.Close();
                    }
                    else
                    {
                        StartForm form = new StartForm();
                        form.Show();
                        this.Close();
                    }
                }
                if (player.GetPosition().X == player.GetPosition().Y && player.GetPosition().X == 7 && grid.countOfColumns == 8)
                {
                    DialogResult result = MessageBox.Show(
                         "Вы прошли 2 уровень!! \n" +
                         "Желаете продолжить?",
                         "Сообщение",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    if (result.ToString() == "Yes")
                    {
                        grid = new Grid(720, 720, 10, 10, conf.MapForThirdLevel);
                        player = new Rabbit(0, 0, conf.CountOfLives, conf.ImagePathPlayer);
                        wolf = new Wolf(9, 9, conf.ImagePathWolf);
                        Main f = new Main(10, 10, conf.MapForThirdLevel,conf.LevelOfHardOnThirdLevel);

                        f.Show();
                        this.Close();
                    }
                    else
                    {
                        StartForm form = new StartForm();
                        form.Show();
                        this.Close();
                    }
                }
                if (player.GetPosition().X == player.GetPosition().Y && player.GetPosition().X == 9 && grid.countOfColumns == 10)
                {
                    DialogResult result = MessageBox.Show(
                         "Вы прошли игру!!! \n" +
                         "Желаете повторить?",
                         "Сообщение",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    if (result.ToString() == "Yes")
                    {
                        grid = new Grid(720, 720, 6, 6, conf.MapForFirstLevel);
                        player = new Rabbit(0, 0, conf.CountOfLives, conf.ImagePathPlayer);
                        wolf = new Wolf(5, 5, conf.ImagePathWolf);
                        Main f = new Main(6, 6, conf.MapForThirdLevel, conf.LevelOfHardOnFirstLevel);
                        f.Show();
                        this.Close();
                    }
                    else
                    {
                        StartForm form = new StartForm();
                        form.Show();
                        this.Close();
                    }
                }
            }

        }
        int prov = 0;
        public void TickForHandicate(object sender, EventArgs e)
        {
            if (prov != 0)
            {
                if (complex == "Light")
                    TimerForFirstMoveEnemy.Enabled = true;
                else
                    TimerForSecondMoveEnemy.Enabled = true;
                TimerForPresent.Enabled = false;
            }
            else
                prov++;
          
        }
        public void TickBoom(object sender, EventArgs e)
        {
            bombImage.Image = Image.FromFile(bomb.ImagePathBOOM);
            if((player.GetPosition().X == bomb.GetPosition().X && player.GetPosition().Y == bomb.GetPosition().Y)|| (player.GetPosition().X+1 == bomb.GetPosition().X && player.GetPosition().Y == bomb.GetPosition().Y) || (player.GetPosition().X - 1 == bomb.GetPosition().X && player.GetPosition().Y == bomb.GetPosition().Y) || (player.GetPosition().X == bomb.GetPosition().X && player.GetPosition().Y+1 == bomb.GetPosition().Y) || (player.GetPosition().X == bomb.GetPosition().X && player.GetPosition().Y-1 == bomb.GetPosition().Y))
            {
                for(int i = 0;i<conf.DamageOfBomb;i++)
                {
                    panel1.Controls.Remove(PointsOfHealth[CountOfHealthNow - (i+1)]);

                }
                CountOfHealthNow -= conf.DamageOfBomb;
                player.UpdatePosition(-player.GetPosition().X, -player.GetPosition().Y);
                playerImage.Location = new Point(0, 0);
            }
            TimeBoom.Enabled = false;
        }

        public void TickBeforeBoom(object sender, EventArgs e)
        {
            TimeBoom.Enabled = true;
            TimeBefoorBoom.Enabled = false;
        }

        public void TickForBomb(object sender, EventArgs e)
        {
            
            bomb = new Bomb(grid, player.GetPosition(), wolf.GetPosition(), conf.ImagePathBomb, "boom.png");
            bombImage.Location = new Point(bomb.GetPosition().X * grid.WidthOfCell, bomb.GetPosition().Y * grid.HeightOfCell);
            bombImage.Height = grid.HeightOfCell;
            bombImage.Width = grid.WidthOfCell;
            bombImage.Image = Image.FromFile(bomb.ImagePath);
            bombImage.Visible = true;
            bombImage.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(bombImage);
            TimeBefoorBoom.Enabled = true;
        }

        bool GoWall, Choosing = true;
        public void ChangesInGame(Configarithion configuration)
        {
            conf = configuration;
            playerImage.Image = Image.FromFile(conf.ImagePathPlayer);
            WolfImage.Image = Image.FromFile(conf.ImagePathWolf);
        }
        public void Start()
        {
            if (complex == "Light")
                TimerForFirstMoveEnemy.Enabled = true;
            else
                TimerForSecondMoveEnemy.Enabled = true;

        }
        private void gunaCircleButton2_Click(object sender, EventArgs e)
        {
            if (complex == "Light")
                TimerForFirstMoveEnemy.Enabled = false;
            else
                TimerForSecondMoveEnemy.Enabled = false;
            var SettingForm = new Settings("Main", new MyDelegate(ChangesInGame), new MyDelegate1(Start));
            SettingForm.Show();
        }


        private void gunaCircleButton2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!player.IsGoing)
            {
                if (e.KeyCode == Keys.Left)
                {
                    ChoseStep(-1, 0, TimerForPlayer);
                }

                if (e.KeyCode == Keys.Right)
                {
                    ChoseStep(1, 0, TimerForPlayer);
                }

                if (e.KeyCode == Keys.Up)
                {
                    ChoseStep(0, -1, TimerForPlayer);
                }

                if (e.KeyCode == Keys.Down)
                {
                    ChoseStep(0, 1, TimerForPlayer);
                }
                
            }
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int ChoseWay = 0;
        public void StepEveryOneSecond1(object sender, EventArgs e)
        {
            Random rand = new Random();
            Choosing = true;
            while (Choosing)
            {
                if (GoWall == false)
                {
                    ChoseWay = rand.Next(0, 4);
                    GoWall = true;
                }
                ChooseSide();
            }
            TimerForSecondMoveEnemy.Enabled = false;
        }

        public void WaveAlgorithmTick(object sender, EventArgs e)
        {
            Choosing = true;
            while (Choosing)
            {
                ChoseWay = WaveAlgorithm.NextStep(wolf.GetPosition().X, wolf.GetPosition().Y, player.GetPosition().X, player.GetPosition().Y, grid);
                ChooseSide();
            }
            TimerForSecondMoveEnemy.Enabled = false;
        }

        public void ChooseSide()
        {
            if (ChoseWay == 0)
            {
                ChoseStepForEnemy(-1, 0, TimerStepEnemy);
            }
            if (ChoseWay == 1)
            {
                ChoseStepForEnemy(1, 0, TimerStepEnemy);
            }
            if (ChoseWay == 2)
            {
                ChoseStepForEnemy(0, -1, TimerStepEnemy);
            }
            if (ChoseWay == 3)
            {
                ChoseStepForEnemy(0, 1, TimerStepEnemy);
            }
        }

        public void StepEveryOneSecond(object sender, EventArgs e)
        {
            Random rand = new Random();
            Choosing = true;
            while (Choosing)
            {
                ChoseWay = rand.Next(0, 4);
                ChooseSide();
            }
            TimerForFirstMoveEnemy.Enabled = false;
        }

        public void Step_of_wolf(object sender, EventArgs e)
        {
            WolfImage.Location = new Point(WolfImage.Location.X + StepEnemyX, WolfImage.Location.Y + StepEnemyY);
            if (WolfImage.Location.X == wolf.GetPosition().X * grid.WidthOfCell && WolfImage.Location.Y == wolf.GetPosition().Y * grid.HeightOfCell)
            {
                TimerStepEnemy.Enabled = false;
                if (WhatTypeOfEnemyMove == 1)
                    TimerForFirstMoveEnemy.Enabled = true;
                if (WhatTypeOfEnemyMove == 2)
                    TimerForSecondMoveEnemy.Enabled = true;
                if (wolf.GetPosition().X == player.GetPosition().X && wolf.GetPosition().Y == player.GetPosition().Y)
                    QuolityOfLifesCheck();


            }
        }

        public void QuolityOfLifesCheck()
        {
            
                player.QuantityOfLife -= conf.DamageOfWolf;
                panel1.Controls.Remove(PointsOfHealth[CountOfHealthNow - 1]);
                CountOfHealthNow -= 1;
                player.UpdatePosition(-player.GetPosition().X, -player.GetPosition().Y);
                playerImage.Location = new Point(0, 0);
                if (player.QuantityOfLife == 0)
                {
                    DialogResult result = MessageBox.Show(
                    "Вы пососали!!! \n" +
                    "Желаете повторить?",
                    "Сообщение",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    if (result.ToString() == "Yes")
                    {
                        Main f = new Main(6, 6, conf.MapForFirstLevel,conf.LevelOfHardOnFirstLevel);
                        f.Show();
                        this.Close();
                    }
                    else
                    {
                        StartForm form = new StartForm();
                        form.Show();
                        this.Close();
                    }
                }
            
        }

    }
}
