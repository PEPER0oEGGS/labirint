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

            StartEm.Visible = false;
            Grafon.Visible = false;
            MapShose.Visible = false;

        }

        private void NoLOadMap_Click(object sender, EventArgs e)
        {
            MapInput.Visible = false;
            LoadMap.Visible = false;
            NoLOadMap.Visible = false;

            StartEm.Visible = true;
            Grafon.Visible = true;
            MapShose.Visible = true;

        }

        private void LoadMap_Click(object sender, EventArgs e)
        {
            MapInput.Visible = false;
            LoadMap.Visible = false;
            NoLOadMap.Visible = false;

            StartEm.Visible = true;
            Grafon.Visible = true;
            MapShose.Visible = true;

            ReadMap();// подгрузка карты
            
        }

        private void StartEm_Click(object sender, EventArgs e)
        {
            COOPAI AI = new COOPAI();
            AI.StartAI(int.Parse(InpRobMap.Text),map );
           /*/ for(; AI.Ready();;)
            {
                AI.loop(map);
                Thread.Sleep(10);     
            }*/
            
        }

        void ReadMap()
        {
            string k = MapInput.Text;
            char[,] map;
            int i=0;
            char lol;
            bool mark=true;
            for (;mark;)
            {
                if (k[i] != '\r'){
                    lol = k[i];
                    i++;
                    
                }
                else { mark = false; }
            }

            map = new char[i, k.Length / (i + 2)];
            for (i = 0; i < map.Length;)
            {
                map[i, 1] = k[i];

            }






            // map.load();
            //char
            if (k[9] == '2') { k+="2"; }
        }
    }
}
