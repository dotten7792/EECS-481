using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.PowerPacks;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        private static Timer myTimer;
        RectangleShape rect = new RectangleShape();
        ShapeContainer canvas = new ShapeContainer();
        Random rand = new Random();
        public OvalShape[] Ovals;
        private int Count = 0;
        private int Count2 = 0;
        public Form2()
        {
            Ovals = new OvalShape[300];
            InitializeComponent();
            myTimer = new Timer();
            this.Height = 600;
            this.Width = 1200;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            canvas.Parent = this;
            rect.Parent = canvas;
            rect.Height = 30;
            rect.Width = 10;
            rect.FillStyle = FillStyle.Solid;
            rect.FillColor = Color.Black;
            rect.Location = new Point(1100, 275);

            myTimer.Interval = 100;
            myTimer.Enabled = true;
            myTimer.Tick+=myTimer_Tick;

            this.KeyPress += new KeyPressEventHandler(Form2_KeyPress);

            StartGame();

        }

        void myTimer_Tick(object sender, EventArgs e)
        {
            Point loc = new Point(0, rand.Next() % 520);
            InitOval(loc);

        }

        
        private void InitOval(Point loc)
        {   if (Count2 % 15 == 0) {
                OvalShape oval = new OvalShape(loc.X, loc.Y, 20, 20);
                oval.FillStyle = FillStyle.Solid;
                oval.FillColor = Color.Red;
                oval.Parent = canvas;
                Ovals[Count] = oval;
                Count++;
            }
            for (int i = 0; i < Count; i++)
            {
                Ovals[i].Location = new Point(Ovals[i].Location.X + 10, Ovals[i].Location.Y);
                if (Ovals[i].Location.X >= rect.Location.X && Ovals[i].Location.X <= rect.Location.X + rect.Width &&
                    Ovals[i].Location.Y >= rect.Location.Y && Ovals[i].Location.Y <= rect.Location.Y + rect.Height)
                {
                    Application.Exit();
                }
            }
            Count2++;
        }

        private void StartGame()
        {
            Point loc = new Point(0, rand.Next() % 520);

        }

        void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (e.KeyChar == 'w' && rect.Location.Y > 0)
                {
                    rect.Location = new Point(rect.Left, rect.Top - 10);
                }
                else if (e.KeyChar == 's' && rect.Location.Y < 520)
                {
                    rect.Location = new Point(rect.Left, rect.Top + 10);
                }
        }


    }
}
