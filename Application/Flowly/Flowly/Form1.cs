using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flowly
{
    /// <summary>
    /// The main window form of the application.
    /// </summary>
    public partial class Form1 : Form
    {
        private int yPos;
        private int xPos;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grid.AllowDrop = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void grid_Click(object sender, EventArgs e)
        {

        }

        private void toolPump_MouseDown(object sender, MouseEventArgs e)
        {
            toolPump.DoDragDrop(toolPump.Image, DragDropEffects.Copy);

        }

        private void grid_DragEnter(object sender, DragEventArgs e)
        {

            e.Effect = DragDropEffects.Copy;


        }

        private void grid_DragDrop(object sender, DragEventArgs e)
        {


            //grid.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            g = grid.CreateGraphics();
       
            g.DrawImage((Image)e.Data.GetData(DataFormats.Bitmap),new Point(xPos, yPos));

        }

        private void grid_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
        }


        private void grid_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox p = sender as PictureBox;

            if (p != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    p.Top += (e.Y - yPos);
                    p.Left += (e.X - xPos);
                }
            }
        }
    }
}
