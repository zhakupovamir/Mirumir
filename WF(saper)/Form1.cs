using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_saper_
{
    public partial class Form1 : Form
    {
        private int weight = 35, height = 35;
        private int lev = 10, vn = 40;
        Label[,] labels = new Label[10,10];
        Button[,] buttons = new Button[10, 10];
        int[,] mas= new int[10+2,10+2];
        public Form1()
        {
            InitializeComponent();
            NewGame(); 
        }
        public void NewGame()
        {

            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Location = new Point(lev + i * weight, vn + j * height);
                    buttons[i, j].Size = new System.Drawing.Size(weight, height);
                    buttons[i, j].Font = new Font("Tahoma", 20);
                    buttons[i, j].MouseClick += new MouseEventHandler(buttons_MouseClick);
                    Controls.Add(buttons[i, j]);
                }
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    labels[i, j] = new Label();
                    labels[i, j].Text = "";
                    labels[i, j].Top = vn + i * weight;
                    labels[i, j].Left = lev + j * height;
                    labels[i, j].Size = new Size(weight, height);
                    labels[i, j].ForeColor = Color.Black;
                    labels[i, j].BorderStyle = BorderStyle.FixedSingle;
                    labels[i, j].Font = new Font("Tahoma", 27);
                    Controls.Add(labels[i, j]);
                }
            Rastanovka();
        }
        void buttons_MouseClick(object sender, MouseEventArgs e)
        {
            int i = e.X/40;
            int j = e.Y/40;
            buttons[i, j].Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int m = 0; m < 10; m++)
                for (int n = 0; n < 10; n++)
                {
                    mas[m, n] = 0;
                    buttons[m, n].Text = "";
                }
            Rastanovka();
        }

        public void Rastanovka()
        {
            int m, n, bomb = 0;
            int k=0;
            Random rnd = new Random();
            do
            {
                m = rnd.Next(10);
                n = rnd.Next(10);
                if (labels[m, n].Text != "*")
                {
                    labels[m, n].Text = "*";
                    buttons[m, n].Text = "*";
                    mas[m, n] = 9;
                    bomb++;
                }
            }
            while (bomb < 11);
            for (m = 1; m <= 9; m++)
                for (n = 1; n <= 9; n++)
                    if (mas[m, n] != 9)
                    {
                        k = 0;

                        if (mas[m - 1, n - 1] == 9) k++;
                        if (mas[m - 1, n] == 9) k++;
                        if (mas[m - 1, n + 1] == 9) k++;
                        if (mas[m, n - 1] == 9) k++;
                        if (mas[m, n + 1] == 9) k++;
                        if (mas[m + 1, n - 1] == 9) k++;
                        if (mas[m + 1, n] == 9) k++;
                        if (mas[m + 1, n + 1] == 9) k++;
                        mas[m, n] = k;
                        buttons[m, n].Text = Convert.ToString(mas[m, n]);
                        if (k == 0)
                        {
                            buttons[m, n].Text = "";
                        }
                    }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
