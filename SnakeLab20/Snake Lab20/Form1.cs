using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Lab20
{
    public partial class Snake : Form
    {
        Point[] p;
        Point apple;
        int direction;
        int len = 5;
        int count;
        Point die;
        public Snake()
        {
            InitializeComponent();
            p = new Point[200];
            len = 5;
            direction = 3;
            for (int i = 0; i < 5; i++)
            {
                p[0].X = 100;
                p[0].Y = 100+i*10;
            }
            Random x = new Random();
            Random y = new Random();
            apple.X = x.Next(0,50)*10;
            apple.Y = y.Next(0, 50)*10;
            Random xd = new Random();
            Random xy = new Random();
            die.X = xd.Next(5, 40) * 10;
            die.Y = xy.Next(5, 40) * 10;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 198; i >= 0; i--)
            {
                p[i+1].X = p[i].X;
                p[i+1].Y = p[i].Y;
            }
            if(direction ==1 )
            {
                p[0].X = p[1].X-10;
                p[0].Y = p[1].Y;
            }
            if (direction == 2)
            {
                p[0].X = p[1].X + 10;
                p[0].Y = p[1].Y;
            }
            if (direction == 3)
            {
                p[0].X = p[1].X;
                p[0].Y = p[1].Y-10;
            }
            if (direction == 4)
            {
                p[0].X = p[1].X;
                p[0].Y = p[1].Y+10;
            }
            SolidBrush b = new SolidBrush(Color.Green);
            for (int i = 0; i < len; i++)
            {
                e.Graphics.FillEllipse(b,p[i].X,p[i].Y,10,10);

            }
            SolidBrush a = new SolidBrush(Color.Red);
                e.Graphics.FillEllipse(a,apple.X, apple.Y, 10, 10);
            if(p[0].X == apple.X && p[0].Y == apple.Y)
            {
                count++;
                len++;
                Random x = new Random();
                Random y = new Random();
                apple.X = x.Next(0, 50)*10;
                apple.Y = y.Next(0, 50) *10;
                label1.Text = Convert.ToString(count);
            }
            SolidBrush c = new SolidBrush(Color.Black);
            e.Graphics.FillEllipse(c, die.X, die.Y, 10, 10);
            if (p[0].X == die.X && p[0].Y == die.Y)
            {
                count = count -3;
                len = len - 3;
                Random xd = new Random();
                Random xy = new Random();
                die.X = xd.Next(5, 45) * 10;
                die.Y = xy.Next(5, 40) * 10;
                label1.Text = Convert.ToString(count);
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                direction = 1;
            }
            if (e.KeyCode == Keys.Right)
            {
                direction = 2;
            }
            if (e.KeyCode == Keys.Up)
            {
                direction = 3;
            }
            if (e.KeyCode == Keys.Down)
            {
                direction = 4;
            }
        }
       
        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
