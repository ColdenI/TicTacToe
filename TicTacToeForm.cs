using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class FormMain : Form
    {

        private byte[] Map = new byte[9];
        private Image X_image, O_image;
        private bool isGameTrue = true;


        private static Image cropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

        public FormMain()
        {
            InitializeComponent();

            for (int i = 0; i < Map.Length; i++) Map[i] = 0;
        }

        private static Rectangle GetRectangle(int x, int y, int x2, int y2) {return new Rectangle(x, y, x2 - x, y2 - y);}

        private void FormMain_Load(object sender, EventArgs e)
        {
            Init_Texture();
        }

        private void Init_Texture()
        {
            X_image = cropImage(Properties.Resources.ox_com_t, GetRectangle(Properties.Settings.Default.X_po_1.X, Properties.Settings.Default.X_po_1.Y, Properties.Settings.Default.X_po_2.X, Properties.Settings.Default.X_po_2.Y));
            O_image = cropImage(Properties.Resources.ox_com_t, GetRectangle(Properties.Settings.Default.O_po_1.X, Properties.Settings.Default.O_po_1.Y, Properties.Settings.Default.O_po_2.X, Properties.Settings.Default.O_po_2.Y));

            Draw();
        }

        private void SetMap(int index)
        {
            if (Map[index] == 0 && isGameTrue)
            {
                Map[index] = 1;
                Draw();
                Logic();
            }
        }

        private void button_item_0_Paint(object sender, EventArgs e)
        {
            SetMap(0);
        }
        private void button_item_1_Paint(object sender, EventArgs e)
        {
            SetMap(1);
        }
        private void button_item_2_Paint(object sender, EventArgs e)
        {
            SetMap(2);
        }
        private void button_item_3_Paint(object sender, EventArgs e)
        {
            SetMap(3);
        }
        private void button_item_4_Paint(object sender, EventArgs e)
        {
            SetMap(4);
        }
        private void button_item_5_Paint(object sender, EventArgs e)
        {
            SetMap(5);
        }
        private void button_item_6_Paint(object sender, EventArgs e)
        {
            SetMap(6);
        }
        private void button_item_7_Paint(object sender, EventArgs e)
        {
            SetMap(7);
        }
        private void button_item_8_Paint(object sender, EventArgs e)
        {
            SetMap(8);
        }

        private void Logic()
        {
            // is Win
            if (
                    (Map[0] == 1 && Map[1] == 1 && Map[2] == 1) ||
                    (Map[3] == 1 && Map[4] == 1 && Map[5] == 1) ||
                    (Map[6] == 1 && Map[7] == 1 && Map[8] == 1) ||
                    (Map[0] == 1 && Map[3] == 1 && Map[6] == 1) ||
                    (Map[3] == 1 && Map[4] == 1 && Map[7] == 1) ||
                    (Map[2] == 1 && Map[5] == 1 && Map[8] == 1) ||
                    (Map[0] == 1 && Map[4] == 1 && Map[8] == 1) ||
                    (Map[2] == 1 && Map[4] == 1 && Map[6] == 1) )
            {
                isGameTrue = false;
                Draw();
                Update();
                MessageBox.Show("Победа!");
                Properties.Settings.Default.stat_win++;
                Properties.Settings.Default.Save();
                NewGame();
               // return;
            }

            isGameTrue = false;
            foreach(byte i in Map)
            {
                if (i == 0)
                {
                    isGameTrue = true;
                }
            }

            if (!isGameTrue)
            {
                MessageBox.Show("Ничья!");             
                Properties.Settings.Default.stat_dr++;
                Properties.Settings.Default.Save();
                NewGame();
                var rand = new Random();
                if (rand.Next(0, 2) == 0) return;
            }


            Draw();
            Update();

            uint _count_res = 0;

            // logic

            if (Map[0] == 2 && Map[1] == 2 && Map[2] == 0) Map[2] = 2;
            else if (Map[0] == 2 && Map[1] == 0 && Map[2] == 2) Map[1] = 2;
            else if (Map[0] == 0 && Map[1] == 2 && Map[2] == 2) Map[0] = 2;

            else if (Map[3] == 2 && Map[4] == 2 && Map[5] == 0) Map[5] = 2;
            else if (Map[3] == 2 && Map[4] == 0 && Map[5] == 2) Map[4] = 2;
            else if (Map[3] == 0 && Map[4] == 2 && Map[5] == 2) Map[3] = 2;

            else if (Map[6] == 2 && Map[7] == 2 && Map[8] == 0) Map[8] = 2;
            else if (Map[6] == 2 && Map[7] == 0 && Map[8] == 2) Map[7] = 2;
            else if (Map[6] == 0 && Map[7] == 2 && Map[8] == 2) Map[6] = 2;


            else if (Map[0] == 2 && Map[3] == 2 && Map[6] == 0) Map[6] = 2;
            else if (Map[0] == 2 && Map[3] == 0 && Map[6] == 2) Map[3] = 2;
            else if (Map[0] == 0 && Map[3] == 2 && Map[6] == 2) Map[0] = 2;


            else if (Map[1] == 2 && Map[4] == 2 && Map[7] == 0) Map[7] = 2;
            else if (Map[1] == 2 && Map[4] == 0 && Map[7] == 2) Map[4] = 2;
            else if (Map[1] == 0 && Map[4] == 2 && Map[7] == 2) Map[1] = 2;

            else if (Map[2] == 2 && Map[5] == 2 && Map[8] == 0) Map[8] = 2;
            else if (Map[2] == 2 && Map[5] == 0 && Map[8] == 2) Map[5] = 2;
            else if (Map[2] == 0 && Map[5] == 2 && Map[8] == 2) Map[2] = 2;


            else if (Map[0] == 2 && Map[4] == 2 && Map[8] == 0) Map[8] = 2;
            else if (Map[0] == 2 && Map[4] == 0 && Map[8] == 2) Map[4] = 2;
            else if (Map[0] == 0 && Map[4] == 2 && Map[8] == 2) Map[0] = 2;

            else if (Map[2] == 2 && Map[4] == 2 && Map[6] == 0) Map[6] = 2;
            else if (Map[2] == 2 && Map[4] == 0 && Map[6] == 2) Map[4] = 2;
            else if (Map[2] == 0 && Map[4] == 2 && Map[6] == 2) Map[2] = 2;



            else if (Map[0] == 1 && Map[1] == 1 && Map[2] == 0) Map[2] = 2;
            else if (Map[0] == 1 && Map[1] == 0 && Map[2] == 1) Map[1] = 2;
            else if (Map[0] == 0 && Map[1] == 1 && Map[2] == 1) Map[0] = 2;

            else if (Map[3] == 1 && Map[4] == 1 && Map[5] == 0) Map[5] = 2;
            else if (Map[3] == 1 && Map[4] == 0 && Map[5] == 1) Map[4] = 2;
            else if (Map[3] == 0 && Map[4] == 1 && Map[5] == 1) Map[3] = 2;

            else if (Map[6] == 1 && Map[7] == 1 && Map[8] == 0) Map[8] = 2;
            else if (Map[6] == 1 && Map[7] == 0 && Map[8] == 1) Map[7] = 2;
            else if (Map[6] == 0 && Map[7] == 1 && Map[8] == 1) Map[6] = 2;


            else if (Map[0] == 1 && Map[3] == 1 && Map[6] == 0) Map[6] = 2;
            else if (Map[0] == 1 && Map[3] == 0 && Map[6] == 1) Map[3] = 2;
            else if (Map[0] == 0 && Map[3] == 1 && Map[6] == 1) Map[0] = 2;

            else if (Map[1] == 1 && Map[4] == 1 && Map[7] == 0) Map[7] = 2;
            else if (Map[1] == 1 && Map[4] == 0 && Map[7] == 1) Map[4] = 2;
            else if (Map[1] == 0 && Map[4] == 1 && Map[7] == 1) Map[1] = 2;

            else if (Map[2] == 1 && Map[5] == 1 && Map[8] == 0) Map[8] = 2;
            else if (Map[2] == 1 && Map[5] == 0 && Map[8] == 1) Map[5] = 2;
            else if (Map[2] == 0 && Map[5] == 1 && Map[8] == 1) Map[2] = 2;

            else if (Map[0] == 1 && Map[4] == 1 && Map[8] == 0) Map[8] = 2;
            else if (Map[0] == 1 && Map[4] == 0 && Map[8] == 1) Map[4] = 2;
            else if (Map[0] == 0 && Map[4] == 1 && Map[8] == 1) Map[0] = 2;

            else if (Map[2] == 1 && Map[4] == 1 && Map[6] == 0) Map[6] = 2;
            else if (Map[2] == 1 && Map[4] == 0 && Map[6] == 1) Map[4] = 2;
            else if (Map[2] == 0 && Map[4] == 1 && Map[6] == 1) Map[2] = 2;

            else {
                while (true && isGameTrue) {
                    int i = new Random().Next(0, 8);
                    if (Map[i] == 0) {
                        Map[i] = 2;
                        break;
                    }
                    _count_res++;
                    if (_count_res > 1000000)
                    {
                        MessageBox.Show("Ничья!");                 
                        Properties.Settings.Default.stat_dr++;
                        Properties.Settings.Default.Save();
                        NewGame();
                    }
                }
            }

            Draw();
            Update();

            // is Game Over
            if (
                    (Map[0] == 2 && Map[1] == 2 && Map[2] == 2) ||
                    (Map[3] == 2 && Map[4] == 2 && Map[5] == 2) ||
                    (Map[6] == 2 && Map[7] == 2 && Map[8] == 2) ||
                    (Map[0] == 2 && Map[3] == 2 && Map[6] == 2) ||
                    (Map[1] == 2 && Map[4] == 2 && Map[7] == 2) ||
                    (Map[2] == 2 && Map[5] == 2 && Map[8] == 2) ||
                    (Map[0] == 2 && Map[4] == 2 && Map[8] == 2) ||
                    (Map[2] == 2 && Map[4] == 2 && Map[6] == 2) )
            {
                isGameTrue = false;
                Draw();
                Update();
                MessageBox.Show("Поражение!");
                Properties.Settings.Default.stat_go++;
                Properties.Settings.Default.Save();
                NewGame();
                return;
            }


            isGameTrue = false;
            foreach (byte i in Map)
            {
                if (i == 0)
                {
                    isGameTrue = true;
                }
            }
            if (!isGameTrue)
            {
                MessageBox.Show("Ничья!");
                Properties.Settings.Default.stat_dr++;
                Properties.Settings.Default.Save();
                NewGame();
                return;
            }

            Draw();
            Update();
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void NewGame()
        {
            if (!isGameTrue)
            {
                Properties.Settings.Default.stat_go++;
                Properties.Settings.Default.Save();
            }
            isGameTrue = true;
            for (int i = 0; i < Map.Length; i++) Map[i] = 0;
            Draw();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void класикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.X_po_1 = new Point(3,3);
            Properties.Settings.Default.X_po_2 = new Point(87,87);
            Properties.Settings.Default.Save();
            Init_Texture();

        }

        private void клсикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.O_po_1 = new Point(91,3);
            Properties.Settings.Default.O_po_2 = new Point(174,87);
            Properties.Settings.Default.Save();
            Init_Texture();
        }

        private void зелёныйToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.X_po_1 = new Point(3,90);
            Properties.Settings.Default.X_po_2 = new Point(87,174);
            Properties.Settings.Default.Save();
            Init_Texture();
        }

        private void зелёный2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.X_po_1 = new Point(178,178);
            Properties.Settings.Default.X_po_2 = new Point(262,262);
            Properties.Settings.Default.Save();
            Init_Texture();
        }

        private void синийToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.X_po_1 = new Point(3,178);
            Properties.Settings.Default.X_po_2 = new Point(87,262);
            Properties.Settings.Default.Save();
            Init_Texture();
        }

        private void голубойToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.X_po_1 = new Point(178,266);
            Properties.Settings.Default.X_po_2 = new Point(262,349);
            Properties.Settings.Default.Save();
            Init_Texture();
        }

        private void крансыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.X_po_1 = new Point(178,3);
            Properties.Settings.Default.X_po_2 = new Point(262,87);
            Properties.Settings.Default.Save();
            Init_Texture();
        }

        private void чёрныйToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.X_po_1 = new Point(3,266);
            Properties.Settings.Default.X_po_2 = new Point(87,349);
            Properties.Settings.Default.Save();
            Init_Texture();
        }

        private void жёлтыйToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.X_po_1 = new Point(3,353);
            Properties.Settings.Default.X_po_2 = new Point(87,437);
            Properties.Settings.Default.Save();
            Init_Texture();
        }

        private void оранжевыйToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.X_po_1 = new Point(3,441);
            Properties.Settings.Default.X_po_2 = new Point(87,524);
            Properties.Settings.Default.Save();
            Init_Texture();
        }

        private void фиолетовыйToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.X_po_1 = new Point(178,90);
            Properties.Settings.Default.X_po_2 = new Point(262,174);
            Properties.Settings.Default.Save();
            Init_Texture();
        }

        private void зелёныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.O_po_1 = new Point(91,90);
            Properties.Settings.Default.O_po_2 = new Point(174,174);
            Properties.Settings.Default.Save();
            Init_Texture();
        }

        private void зелёный2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.O_po_1 = new Point(266,178);
            Properties.Settings.Default.O_po_2 = new Point(349,262);
            Properties.Settings.Default.Save();
            Init_Texture();
        }

        private void синийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.O_po_1 = new Point(91,178);
            Properties.Settings.Default.O_po_2 = new Point(174,262);
            Properties.Settings.Default.Save();
            Init_Texture();
        }

        private void голубойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.O_po_1 = new Point(266,266);
            Properties.Settings.Default.O_po_2 = new Point(349,349);
            Properties.Settings.Default.Save();
            Init_Texture();
        }

        private void красныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.O_po_1 = new Point(266,3);
            Properties.Settings.Default.O_po_2 = new Point(349,87);
            Properties.Settings.Default.Save();
            Init_Texture();
        }

        private void чёрныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.O_po_1 = new Point(91,266);
            Properties.Settings.Default.O_po_2 = new Point(174,349);
            Properties.Settings.Default.Save();
            Init_Texture();
        }

        private void жёлтыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.O_po_1 = new Point(91,353);
            Properties.Settings.Default.O_po_2 = new Point(174,437);
            Properties.Settings.Default.Save();
            Init_Texture();
        }

        private void оранжевыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.O_po_1 = new Point(91,441);
            Properties.Settings.Default.O_po_2 = new Point(174,524);
            Properties.Settings.Default.Save();
            Init_Texture();
        }

        private void фиолетовыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.O_po_1 = new Point(266,90);
            Properties.Settings.Default.O_po_2 = new Point(349,174);
            Properties.Settings.Default.Save();
            Init_Texture();
        }

        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float _win = Properties.Settings.Default.stat_win;
            float _dr = Properties.Settings.Default.stat_dr;
            float _go = Properties.Settings.Default.stat_go;
            float _stat_1 = 0, _stat_2 = 0;

            try
            {
                _stat_1 = Convert.ToInt32(((_win / (_win + _go + _dr)) * 100) + 0);
                _stat_2 = Convert.ToInt32(((_win / (_win + _go)) * 100) + 0);
            }catch (Exception ex) { }


            MessageBox.Show(
                "\t\tСтатистика\n" +
                "\n  Количество побед: \t\t" + Properties.Settings.Default.stat_win.ToString() +
                "\n  Количество в ничью: \t\t" + Properties.Settings.Default.stat_dr.ToString() +
                "\n  Количество поражений: \t\t" + Properties.Settings.Default.stat_go.ToString() +
                "\n  Процент побед: \t\t\t" + _stat_1.ToString() + " %" +
                "\n  Процент побед (от поражений): \t" + _stat_2.ToString() + " %",
                "Статистика"
                ); 
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите очистить статистику?", "?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Properties.Settings.Default.stat_dr = 0;
                Properties.Settings.Default.stat_go = 0;
                Properties.Settings.Default.stat_win = 0;
                Properties.Settings.Default.Save();
            }
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if(tableLayoutPanel.Size.Width > tableLayoutPanel.Size.Height)
            {
                Height += (tableLayoutPanel.Size.Width - tableLayoutPanel.Size.Height);
            }
            else if (tableLayoutPanel.Size.Width < tableLayoutPanel.Size.Height)
            {
                Width += (tableLayoutPanel.Size.Height - tableLayoutPanel.Size.Width);
            }
        }

        private void Draw()
        {           
            Panel[] panels = { button_item_0, button_item_1, button_item_2, button_item_3, button_item_4, button_item_5, button_item_6, button_item_7, button_item_8 };
            for (int i = 0; i < panels.Length; i++)
            {
                switch (Map[i])
                {
                    case 0: panels[i].BackgroundImage = null; break;
                    case 1: panels[i].BackgroundImage = X_image; break;
                    case 2: panels[i].BackgroundImage = O_image; break;
                }             
            }
        }


    }
}
