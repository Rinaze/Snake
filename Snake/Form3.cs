﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form3 : Form
    {
        private int width = 700;
        private int height = 700;
        private Label snake;
        private Label complexity;
        private Button complexity1;
        private Button complexity2;
        private Button complexity3;
        private Button close;
        public Form3()
        {
            InitializeComponent();
            this.Width = width;
            this.Height = height;

            snake = new Label();
            snake.Text = "ЗМЕЙКА";
            snake.AutoSize = true;
            snake.Location = new Point(135, 20);
            snake.Font = new Font("Boucherie block", 70, FontStyle.Regular);
            this.Controls.Add(snake);

            complexity = new Label();
            complexity.Text = "Выберите сложность";
            complexity.AutoSize = true;
            complexity.Location = new Point(150, 230);
            complexity.Font = new Font("Boucherie block", 30, FontStyle.Regular);
            this.Controls.Add(complexity);

            complexity1 = new Button();
            complexity1.Text = "легкая";
            complexity1.AutoSize = true;
            complexity1.Location = new Point(290, 310);
            complexity1.Font = new Font("Boucherie block", 20, FontStyle.Regular);
            complexity1.Click += (sender, e) =>
            {
                Form1 game1 = new Form1();
                this.Hide();
                game1.ShowDialog();
                this.Close();
            };
            this.Controls.Add(complexity1);

            complexity2 = new Button();
            complexity2.Text = "средняя";
            complexity2.AutoSize = true;
            complexity2.Location = new Point(280, 380);
            complexity2.Font = new Font("Boucherie block", 20, FontStyle.Regular);
            complexity2.Click += (sender, e) =>
            {
                Form4 game2 = new Form4();
                this.Hide();
                game2.ShowDialog();
                this.Close();
            };
            this.Controls.Add(complexity2);


            complexity3 = new Button();
            complexity3.Text = "сложная";
            complexity3.AutoSize = true;
            complexity3.Location = new Point(280, 450);
            complexity3.Font = new Font("Boucherie block", 20, FontStyle.Regular);
            complexity3.Click += (sender, e) =>
            {
                Form5 game3 = new Form5();
                this.Hide();
                game3.ShowDialog();
                this.Close();
            };
            this.Controls.Add(complexity3);

            close = new Button();
            close.Text = "выйти из игры";
            close.AutoSize = true;
            close.Location = new Point(250, 590);
            close.Font = new Font("Boucherie block", 20, FontStyle.Regular);
            close.Click += (sender, e) =>
            {
                this.Close();
            };
            this.Controls.Add(close);
        }
    }
}
