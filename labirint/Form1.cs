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

namespace labirint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        RealMap map = new RealMap();

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
            //MapInput.Visible = false;
            LoadMap.Visible = false;
            NoLOadMap.Visible = false;
            X.Visible = false;
            Y.Visible = false;
            Location.Visible = false;

            StartEm.Visible = true;
           // Grafon.Visible = true;
            MapShose.Visible = true;
            Rob.Visible = true;
            Robots.Visible = true;
        }

        private void LoadMap_Click(object sender, EventArgs e)
        {
            //MapInput.Visible = false;
            LoadMap.Visible = false;
            NoLOadMap.Visible = false;
            X.Visible = false;
            Y.Visible = false;
            Location.Visible = false;

            StartEm.Visible = true;
            // Grafon.Visible = true;
            MapShose.Visible = true;
            Rob.Visible = true;
            Robots.Visible = true;

            ReadMap();// подгрузка карты
            
        }

        private void StartEm_Click(object sender, EventArgs e)
        {
            COOPAI AI = new COOPAI();
            AI.StartAI(int.Parse(Rob.Text),map );
            for(;true;)
            {
                AI.Loop(map);
                MapInput.Clear();
                for (int i = 0,j = 0; i < AI.MAP().GetLength(1);)
                {
                    MapInput.Text += AI.MAP()[j, i];
                    j++;
                    if (j >= AI.MAP().GetLength(0)) { j = 0;i++; MapInput.Text += Environment.NewLine; }
                }
                MapInput.Update();
                Thread.Sleep(10);     
            }
            
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
                else { mark = false; }
            }
            if (!mark) { 
                maps = new int[i, k.Length / (i + 1)];
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


    }
}
