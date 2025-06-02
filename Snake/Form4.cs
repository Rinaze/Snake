using System;
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
    public partial class Form4 : Form
    {
        private int width = 890;
        private int height = 790;
        private int sizehead = 30;
        private int dx, dy;
        private PictureBox apple;
        private int ai, aj;
        private PictureBox[] snake = new PictureBox[100];
        private int score = 0;
        private Label lscore;
        private Label wal;
        private Label wasd;
        private PictureBox wall;
        private List<PictureBox> walls = new List<PictureBox>();
        private int wi, wj;
        private Button menu;

        private void turn(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "D":
                    dx = 1;
                    dy = 0;
                    break;
                case "A":
                    dx = -1;
                    dy = 0;
                    break;
                case "W":
                    dy = -1;
                    dx = 0;
                    break;
                case "S":
                    dy = 1;
                    dx = 0;
                    break;
            }

        }
        private void Map()
        {
            for (int i = 0; i <= width / sizehead; i++)
            {
                PictureBox p = new PictureBox();
                p.BackColor = Color.Gray;
                p.Location = new Point(0, sizehead * i);
                p.Size = new Size(width - 140, 1);
                this.Controls.Add(p);
            }

            for (int i = 0; i <= (height / sizehead) - 1; i++)
            {
                PictureBox p = new PictureBox();
                p.BackColor = Color.Gray;
                p.Location = new Point(sizehead * i, 0);
                p.Size = new Size(1, width);
                this.Controls.Add(p);
            }
        }
        private void createapple()
        {
            Random r = new Random();
            ai = r.Next(0, height - sizehead-90);
            int tempi = ai % sizehead;
            ai -= tempi;
            aj = r.Next(0, height - sizehead - 90);
            int tempj = aj % sizehead;
            aj -= tempj;
            ai++;
            aj++;
            apple.Location = new Point(ai, aj);
            this.Controls.Add(apple);
            checkapple();
        }

        private void checkapple()
        {
            foreach (var wall in walls)
            {
                if (apple.Location == wall.Location)
                {
                    apple = new PictureBox();
                    apple.BackColor = Color.Red;
                    apple.Size = new Size(sizehead, sizehead);
                    createapple();
                }
            }
        }
        private void eatapple()
        {
            if (snake[0].Location.X == ai && snake[0].Location.Y == aj)
            {
                lscore.Text = "Очки: " + ++score;
                snake[score] = new PictureBox();
                snake[score].Location = new Point(snake[score - 1].Location.X + sizehead * dx, snake[score - 1].Location.Y + sizehead * dy);
                snake[score].Size = new Size(sizehead - 1, sizehead - 1);
                snake[score].BackColor = Color.Green;
                this.Controls.Add(snake[score]);
                createapple();
            }
        }
        private void move()
        {
            for (int i = score; i >= 1; i--)
            {
                snake[i].Location = snake[i - 1].Location;
            }
            snake[0].Location = new Point(snake[0].Location.X + dx * (sizehead), snake[0].Location.Y + dy * (sizehead));
            dead();
        }
        private void update(object obj, EventArgs evenr)
        {
            border();
            eatapple();
            crashwall();
            move();
        }
        private void dead()
        {
            for (int i = 1; i < score; i++)
            {
                if (snake[0].Location == snake[i].Location)
                {
                    over();
                }
            }
        }
        private void over()
        {
            timer1.Stop();
            Form2 dead = new Form2(score);
            this.Hide();
            dead.ShowDialog();
            this.Close();
        }
        private void border()
        {
            if (snake[0].Location.X < 0 || snake[0].Location.X > height - 60 || snake[0].Location.Y < 0 || snake[0].Location.Y > height - 60)
            {
                over();
            }
        }
            private void createwall()
            {
                Random r = new Random();
                wi = r.Next(0, height - sizehead - 90);
                int tempi = wi % sizehead;
                wi -= tempi;
                wj = r.Next(0, height - sizehead - 90);
                int tempj = wj % sizehead;
                wj -= tempj;
                wi++;
                wj++;
                
                for (int i = 0; i < 3; i++)
                {
                    PictureBox wall = new PictureBox();
                    wall.BackColor = Color.Black;
                    wall.Size = new Size(sizehead, sizehead);
                    wall.Location = new Point(wi + i * sizehead, wj);
                    walls.Add(wall);
                    this.Controls.Add(wall);
                }
                wall.Location = new Point(wi, wj);
                this.Controls.Add(wall);
            }
       
        private void crashwall()
        {
            foreach (var wall in walls)
            {
                if (snake[0].Location == wall.Location)
                {
                    over();
                }
            }
        }
        public Form4()
        {
            InitializeComponent();
            Map();
            this.Width = width;
            this.Height = height;

            timer1.Tick += new EventHandler(update);
            timer1.Interval = 200;
            timer1.Start();

            wall = new PictureBox();
            wall.BackColor = Color.Black;
            wall.Size = new Size(sizehead, sizehead);
            createwall();

            dx = 1;
            dy = 0;
            apple = new PictureBox();
            apple.BackColor = Color.Red;
            apple.Size = new Size(sizehead, sizehead);
            createapple();

            snake[0] = new PictureBox();
            snake[0].Location = new Point(151, 151);
            snake[0].Size = new Size(sizehead - 1, sizehead - 1);
            snake[0].BackColor = Color.Green;
            this.Controls.Add(snake[0]);

            menu = new Button();
            menu.Text = "Меню";
            menu.AutoSize = true;
            menu.Location = new Point(775, 10);
            menu.Font = new Font("Boucherie block", 15, FontStyle.Regular);
            menu.Click += (sender, e) =>
            {
                timer1.Stop();
                Form3 menu = new Form3();
                this.Hide();
                menu.ShowDialog();
                this.Close();
            };
            this.Controls.Add(menu);
            menu.TabStop = false;

            lscore = new Label();
            lscore.Text = "Очки: 0";
            lscore.Location = new Point(773, 60);
            lscore.Font = new Font("Boucherie block", 15, FontStyle.Regular);
            this.Controls.Add(lscore);

            wasd = new Label();
            wasd.Text = "Управление\r\n      wasd";
            wasd.AutoSize = true;
            wasd.Location = new Point(770, 95);
            wasd.Font = new Font("Boucherie block", 10, FontStyle.Regular);
            this.Controls.Add(wasd);

            wal = new Label();
            wal.Text = "Остерегайтесь\r\n          стен";
            wal.AutoSize = true;
            wal.Location = new Point(765, 140);
            wal.Font = new Font("Boucherie block", 9, FontStyle.Regular);
            this.Controls.Add(wal);

            this.KeyDown += new KeyEventHandler(turn);
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            
        }
    }
}
