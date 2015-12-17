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
        List<Rectangle> rectangles = new List<Rectangle>();
        Dictionary<Rectangle, Image> dictionary = new Dictionary<Rectangle, Image>();

        Graphics g;
        public Form1()
        {

            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);
        
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
            g = grid.CreateGraphics();



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

                int x = xPos - currentPB.Width / 2;
                int y = yPos - currentPB.Height / 2;
                int width = currentPB.Width;
                int height = currentPB.Height;
                Rectangle r = new Rectangle(x, y, width, height);
                foreach (Rectangle rect in rectangles)
                {
                    if (r.IntersectsWith(rect))
                    {
                        MessageBox.Show("The element is coliding with another element.");
                        return;
                    }
                }
                rectangles.Add(r);
                KeyValuePair<Rectangle, Image> item = new KeyValuePair<Rectangle, Image>(r, currentPB.Image);
               
                dictionary.Add(r, currentPB.Image);

                Paint(item);

                Splitter testMerger = new Splitter(r);
                
                List<ConnectionPoint> testConnPoints = testMerger.GiveMeYourConnectionPoints();

                ConnectionPoint bla   = testConnPoints[0];
                ConnectionPoint bla2  = testConnPoints[1];
               ConnectionPoint bla3  = testConnPoints[2];

                g.DrawRectangle(Pens.Orange, bla.rectangle);
              g.DrawRectangle(Pens.Blue, bla2.rectangle);
                g.DrawRectangle(Pens.Yellow, bla3.rectangle);


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


            // Paint(item)
           


        }

        private void Paint(KeyValuePair<Rectangle, Image> item)
        {
            Rectangle r = item.Key;
            g.DrawRectangle(Pens.Red, r);
            g.DrawImage(item.Value, r);
        }

        HashSet<Rectangle> colisions = new HashSet<Rectangle>();
        
        private void grid_MouseMove(object sender, MouseEventArgs e)
        {

            yPos = (e.Y);
            xPos = (e.X);
            //followCursorPB.Location = new System.Drawing.Point(xPos + groupBox1.Width, yPos);
            //followCursorPB.Visible = true;
           

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
            modeCreate = true;
            HighlightCurrentPB(pb);


        }

        private void HighlightCurrentPB(PictureBox pb)
        {
            if (currentPB != null)
            {
                currentPB.BackColor = Control.DefaultBackColor;
            }
            if (modeCreate)
            {
                //followCursorPB.Image = pb.Image;
                //followCursorPB.Width = pb.Width;
                //followCursorPB.Height = pb.Height;
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

        private void grid_MouseLeave(object sender, EventArgs e)
        {
            //followCursorPB.Visible = false;
        }

        KeyValuePair<Rectangle, Image> collidingObject;

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            /*foreach (var item in dictionary)
            {
                if (item.Key.IntersectsWith(new Rectangle(followCursorPB.Location, followCursorPB.Size))) {
                    Paint(item);
                }
            }*/
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}

