using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Snake
{
    public partial class Form2 : Form
    {
        int sc;
        private int width = 700;
        private int height = 700;
        private Button restart;
        private Label over;
        private Label lscore;
        public Form2(int score)
        {
            InitializeComponent();
            this.Width = width;
            this.Height = height;
            sc = score;

            over = new Label();
            over.Text = "Игра окончена";
            over.AutoSize = true;
            over.Location = new Point(110, 200);
            over.Font = new Font("Arial", 50, FontStyle.Regular);
            this.Controls.Add(over);

            lscore = new Label();
            lscore.Text = "Очки: " + sc;
            lscore.AutoSize = true;
            lscore.Location = new Point(260, 300);
            lscore.Font = new Font("Arial", 40, FontStyle.Regular);
            this.Controls.Add(lscore);

            restart = new Button();
            restart.Text = "В меню";
            restart.AutoSize = true;
            restart.Location = new Point(270, 390);
            restart.Font = new Font("Arial", 30, FontStyle.Regular);
            restart.Click += (sender, e) =>
            {
                Form3 menu = new Form3();
                this.Hide();
                menu.ShowDialog();
                this.Close();
            };
            this.Controls.Add(restart);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
