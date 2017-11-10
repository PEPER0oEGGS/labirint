using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;

namespace labirint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        RealMap map = new RealMap();

       public float xSize = 20, ySize = 20; // определить какие по размеру "пиксели лабиринта" нужно для рисования
                                            // COOPAI AI = new COOPAI();

        public static COOPAI AI = new COOPAI();
        
        private void MapShose_Click(object sender, EventArgs e)
        {
            MapInput.Visible = true;
            LoadMap.Visible = true;
            NoLOadMap.Visible = true;
            X.Visible = true;
            Y.Visible = true;
            Location.Visible = true;

            StartEm.Visible = false;
            Grafon.Visible = false;
            MapShose.Visible = false;
            Rob.Visible = false;
            Robots.Visible = false;
        }

        private void NoLOadMap_Click(object sender, EventArgs e)
        {
            MapInput.Visible = false;// коментить для теста
            LoadMap.Visible = false;
            NoLOadMap.Visible = false;
            X.Visible = false;
            Y.Visible = false;
            Location.Visible = false;

            StartEm.Visible = true;
            Grafon.Visible = true;// коментить для теста
            MapShose.Visible = true;
            Rob.Visible = true;
            Robots.Visible = true;
        }

        private void LoadMap_Click(object sender, EventArgs e)
        {
            MapInput.Visible = false; // коментить для теста
            LoadMap.Visible = false;
            NoLOadMap.Visible = false;
            X.Visible = false;
            Y.Visible = false;
            Location.Visible = false;

            StartEm.Visible = true;
            Grafon.Visible = true;// коментить для теста
            MapShose.Visible = true;
            Rob.Visible = true;
            Robots.Visible = true;

            ReadMap();// подгрузка карты
            
        }

        private void StartEm_Click(object sender, EventArgs e)
        {
           
            AI.StartAI(int.Parse(Rob.Text),map);
            loop();
            Form stata = new Statka(ref AI);
            stata.ShowDialog();

        }

        void ReadMap()
        { 
            string k = MapInput.Text;
            int[,] maps;
            int i=0;
            bool mark=true;
             for (;mark;)
             {
                if (i >= k.Length) { Console.WriteLine("Map size error"); break; }
                if (k[i] != '\r'){i++;}
                else
                {
                   // if ((k.Length + 1) % (i+1) == 0) {
                        mark = false;
                   // } else { Console.WriteLine("Map size error"); break; }
                }

             }
            if (!mark) { 
                maps = new int[i, k.Length / (i + 1)];
                Grafon.CreateGraphics().Clear(Color.Green);
              //  xSize = Grafon.CreateGraphics().DpiX / i;
              //  ySize = Grafon.CreateGraphics().DpiY/ (k.Length / (i + 1)); // определить какие по размеру "пиксели лабиринта"

                int l = 0, j = 0; i = 0;
            
                  for (mark = true; mark;)
                  { 
                    if (k[l] == '\r') { l += 2; i = 0; j++; }
                    if (k[l] == 49) { maps[i, j] = 1; }
                    if (k[l] == 50) { maps[i, j] = 0; }
                    // возможно стоит поменять что то из 1/0 стена и путь мб в булы перевести
                    i++;
                    l++;
                    if (j >= maps.GetLength(1)|| l >= k.Length) { mark = false; }
                  }
             map.load(maps,int.Parse(X.Text), int.Parse(X.Text));
            
            }


        }

        void graffika()
        {
            
            Pen Bpen = new Pen(Color.Black);
            Pen Wpen = new Pen(Color.White);
            Brush[] bbrush = new Brush[20];
            bbrush[0] = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Black);
            bbrush[1] = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Red);
            bbrush[2] = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Orange);
            bbrush[3] = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Yellow);
            bbrush[4] = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Blue);
            bbrush[5] = new HatchBrush(HatchStyle.BackwardDiagonal, Color.BlueViolet);
            bbrush[6] = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Violet);
            bbrush[7] = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Pink);
            bbrush[8] = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Green);
            bbrush[9] = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Purple);
            bbrush[10] = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Aqua);
            bbrush[11] = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Olive);
            bbrush[12] = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Gold);
            bbrush[13] = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Silver);
            bbrush[14] = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Brown);
            bbrush[15] = new HatchBrush(HatchStyle.BackwardDiagonal, Color.WhiteSmoke);
            bbrush[16] = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Coral);
            bbrush[17] = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Tan);
            bbrush[18] = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Crimson);
            bbrush[19] = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Tomato);
            Brush Wbrush = new HatchBrush(HatchStyle.Percent90, Color.White);
            PointF LUpoint = new PointF {X = 0,Y = 0};
            PointF[] polygon = new PointF[4];
            for (int n = 0; n < AI.robots.Length; n++)
            {
               
                LUpoint.Y = ySize * AI.robots[n].Locasion()[0];
                LUpoint.X = xSize * AI.robots[n].Locasion()[1];
                polygon[0] = LUpoint;
                LUpoint.Y += xSize;
                polygon[1] = LUpoint;
                LUpoint.X += ySize;
                polygon[2] = LUpoint;
                LUpoint.Y -= xSize;
                polygon[3] = LUpoint;
                if (AI.localMap[AI.robots[n].Locasion()[1], AI.robots[n].Locasion()[0]] == 1) {
                    Grafon.CreateGraphics().DrawPolygon(Bpen, polygon); Grafon.CreateGraphics().FillPolygon(bbrush[n], polygon); }
            
                    
            }
            
           


        }

        void loop()
        {
            for (; AI.stopmark();)
            {
                AI.Loop(map);
                graffika();

                /* //раскоментить для теста
                MapInput.Clear();
                for (int i = 0,j = 0; i < AI.MAP().GetLength(1);)
                {
                    MapInput.Text += AI.MAP()[j, i];
                    j++;
                    if (j >= AI.MAP().GetLength(0)) { j = 0;i++; MapInput.Text += Environment.NewLine; }
                }
                //*/

                // MapInput.Update(); // раскомментить для проверки.
                Thread.Sleep(10);     
            }

            Console.Write("ready");

        }
    }
}
