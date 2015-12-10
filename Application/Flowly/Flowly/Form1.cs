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

        private bool modeCreate = false;

        //for testingperposes
        PictureBox currentPB;


        Graphics g;
        public Form1()
        {
            InitializeComponent();
            foreach (Control item in this.groupBox1.Controls)
            {
                if (item != toolPipe && item != toolEdit && item != toolRemove)
                    if (item.Name.ToLower().StartsWith("tool"))
                    {
                        PictureBox pb = item as PictureBox;
                        item.Click += (x, y) => ActivateCreating(pb);
                    }
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void grid_Click(object sender, EventArgs e)
        {
            //if(theImageLocationIsValid)
            if (modeCreate)
            {
                g = grid.CreateGraphics();
                g.DrawImage(currentPB.Image, xPos - currentPB.Width / 2, yPos - currentPB.Height / 2, currentPB.Width, currentPB.Height);
            }

        }

        private void toolPump_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void grid_DragEnter(object sender, DragEventArgs e)
        {


        }


        private void grid_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
        }


        private void grid_MouseMove(object sender, MouseEventArgs e)
        {

            yPos = (e.Y);
            xPos = (e.X);

        }

        private void toolPump_Click(object sender, EventArgs e)
        {

        }

        private void toolPipe_Click(object sender, EventArgs e)
        {
            modeCreate = false;
            HighlightCurrentPB(sender as PictureBox);
        }

        private void ActivateCreating(PictureBox pb)
        {
            HighlightCurrentPB(pb);
            modeCreate = true;
           
        }

        private void HighlightCurrentPB(PictureBox pb)
        {
            if (currentPB != null)
            {
                currentPB.BackColor = Control.DefaultBackColor;
            }
            pb.BackColor = Color.Yellow;
            currentPB = pb;
        }

        private void toolEdit_Click(object sender, EventArgs e)
        {
            modeCreate = false;
            HighlightCurrentPB(sender as PictureBox);
        }

        private void toolRemove_Click(object sender, EventArgs e)
        {
            modeCreate = false;
            HighlightCurrentPB(sender as PictureBox);
        }
    }
}
