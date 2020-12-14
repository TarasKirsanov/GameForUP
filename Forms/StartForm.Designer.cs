
namespace Rabbit__Game
{
    partial class StartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartButton = new Guna.UI2.WinForms.Guna2Button();
            this.SettingButton = new Guna.UI2.WinForms.Guna2Button();
            this.ExitButton = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.BorderColor = System.Drawing.Color.White;
            this.StartButton.BorderRadius = 30;
            this.StartButton.BorderThickness = 1;
            this.StartButton.CheckedState.Parent = this.StartButton;
            this.StartButton.CustomImages.Parent = this.StartButton;
            this.StartButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            this.StartButton.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartButton.ForeColor = System.Drawing.Color.White;
            this.StartButton.HoverState.Parent = this.StartButton;
            this.StartButton.Location = new System.Drawing.Point(247, 106);
            this.StartButton.Name = "StartButton";
            this.StartButton.ShadowDecoration.Parent = this.StartButton;
            this.StartButton.Size = new System.Drawing.Size(232, 69);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // SettingButton
            // 
            this.SettingButton.BorderColor = System.Drawing.Color.White;
            this.SettingButton.BorderRadius = 30;
            this.SettingButton.BorderThickness = 1;
            this.SettingButton.CheckedState.Parent = this.SettingButton;
            this.SettingButton.CustomImages.Parent = this.SettingButton;
            this.SettingButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            this.SettingButton.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SettingButton.ForeColor = System.Drawing.Color.White;
            this.SettingButton.HoverState.Parent = this.SettingButton;
            this.SettingButton.Location = new System.Drawing.Point(247, 241);
            this.SettingButton.Name = "SettingButton";
            this.SettingButton.ShadowDecoration.Parent = this.SettingButton;
            this.SettingButton.Size = new System.Drawing.Size(232, 69);
            this.SettingButton.TabIndex = 1;
            this.SettingButton.Text = "Settings";
            this.SettingButton.Click += new System.EventHandler(this.SettingButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BorderColor = System.Drawing.Color.White;
            this.ExitButton.BorderRadius = 30;
            this.ExitButton.BorderThickness = 1;
            this.ExitButton.CheckedState.Parent = this.ExitButton;
            this.ExitButton.CustomImages.Parent = this.ExitButton;
            this.ExitButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            this.ExitButton.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.HoverState.Parent = this.ExitButton;
            this.ExitButton.Location = new System.Drawing.Point(247, 373);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.ShadowDecoration.Parent = this.ExitButton;
            this.ExitButton.Size = new System.Drawing.Size(232, 69);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Exit";
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(58)))), ((int)(((byte)(107)))));
            this.ClientSize = new System.Drawing.Size(742, 593);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.SettingButton);
            this.Controls.Add(this.StartButton);
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button StartButton;
        private Guna.UI2.WinForms.Guna2Button SettingButton;
        private Guna.UI2.WinForms.Guna2Button ExitButton;
    }
}