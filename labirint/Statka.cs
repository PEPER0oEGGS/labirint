using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labirint
{
    public partial class Statka : Form
    {
        COOPAI AI2;
        int n = 0;
        public Statka(ref COOPAI AI)
        {
            AI2 = AI;
            InitializeComponent();
            kolvo.Text += ": ";
            kolvo.Text += AI.robots.Length;
            time.Text += ": ";
            time.Text += AI.takts;
            text(n);
            grafika(n);
        }
         
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (n!= 0)
            {
                n=n - 1;
                text(n);
                grafika(n);
            }
            else { n = AI2.robots.Length - 1; text(n);
                grafika(n);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((n + 1) != AI2.robots.Length)
            {
                n = n + 1;
                text(n);
                grafika(n);
            }
            else
            {
                n = 0; text(n);
                grafika(n);
            }
        }

        void text(int n)
        {
            way.Text = "Пройденный путь: ";
            way.Text += AI2.robots[n].Way();
            task.Text = "Решено задач: ";
            task.Text += AI2.robots[n].Taskcounter;
        }
        void grafika(int n)
        {
            float xSize = 20, ySize = 20;
            Pen Bpen = new Pen(Color.Black);
            Pen Wpen = new Pen(Color.White);
            Brush bbrush = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Black);
            Brush Wbrush = new HatchBrush(HatchStyle.Percent90, Color.White);
            Brush Dbrush = new HatchBrush(HatchStyle.Percent90, Color.Aqua);
            PointF LUpoint = new PointF { X = 0, Y = 0 };
            PointF[] polygon = new PointF[4];
            LUpoint.Y = 0;
            LUpoint.X = 0;
            for (int i = 0, j = 0; j < AI2.robots[n].GetTrack().GetLength(1);)
            {
                polygon[0] = LUpoint;
                LUpoint.Y += ySize;
                polygon[1] = LUpoint;
                LUpoint.X += xSize;
                polygon[2] = LUpoint;
                LUpoint.Y -= ySize;
                polygon[3] = LUpoint;
                if (AI2.robots[n].GetTrack()[i, j] == 0) { Grafon.CreateGraphics().DrawPolygon(Bpen, polygon); Grafon.CreateGraphics().FillPolygon(bbrush, polygon); } else
                {
                    if (AI2.robots[n].GetTrack()[i, j] == 1) { Grafon.CreateGraphics().DrawPolygon(Wpen, polygon); Grafon.CreateGraphics().FillPolygon(Wbrush, polygon); } else {
                        Grafon.CreateGraphics().DrawPolygon(Wpen, polygon); Grafon.CreateGraphics().FillPolygon(Dbrush, polygon);}
                }
                i++;
                if (i>= AI2.robots[n].GetTrack().GetLength(0))
                { i = 0; LUpoint.Y += ySize; LUpoint.X = 0; j++; }
                
            }
        }
    }
}
