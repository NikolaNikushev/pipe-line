using Flowly.GeneratedCode;
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
        SystemFlowly flowly;
        Grid theGrid;


        private bool modeCreate = false;
        private bool modePipeCreate = false;

        //for testingperposes
        PictureBox currentPB;

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
            theGrid = new Grid(grid);
            flowly = new SystemFlowly(theGrid);
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

        Point lastPoint = new Point(-1, -1);
        Pipe pipe = null;

        private void grid_Click(object sender, EventArgs e)
        {
            //if(theImageLocationIsValid)
            int x = xPos;
            int y = yPos;
            if (modePipeCreate)
            {
                if (currentPB.Image.Equals(toolPipe.Image))
                {
                    Point newPoint = new Point(x, y);

                    //start drawing pipeline.
                    if (lastPoint.X == -1 || lastPoint.Y == -1)
                    {
                        ConnectionPoint cp = flowly.CheckInputOrOutput(newPoint);
                        if (cp != null)
                        {
                            if (cp.IsOutput)
                            {
                                cp.SetAvailable(false);
                                pipe = new Pipe();
                                pipe.SetConnection(cp);
                                lastPoint = newPoint;
                                pipe.AddPointToList(lastPoint);
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                       
                        bool isAdded = flowly.DrawPipeline(lastPoint, newPoint, pipe);
                        if (isAdded)
                        {

                          
                            lastPoint = newPoint;
                        }
                        else
                        {
                            ConnectionPoint cp = flowly.CheckInputOrOutput(newPoint);
                            if (cp != null)
                            {
                                if (!cp.IsOutput)
                                {
                                    cp.SetAvailable(false);

                                    pipe.SetConnection(cp);
                                   
                                   
                                    isAdded = flowly.DrawPipeline(lastPoint, newPoint, pipe);
                                    if (isAdded)
                                    {
                                        MessageBox.Show("Connected");
                                      
                                        pipe = null;
                                        lastPoint = new Point(-1, -1);
                                    }
                                }
                            }

                        }

                    }
                }
            }
            else
            {
                //pipe.AddPointToList(lastPoint);


                //MessageBox.Show("Pipe is connected");
                if (pipe != null)
                {
                    flowly.RemovePipe(pipe);
                    pipe = null;
                    lastPoint = new Point(-1, -1);
                }
            }


            if (modeCreate)
            {

                x -= currentPB.Width / 2;
                y -= currentPB.Height / 2;
                int width = currentPB.Width;
                int height = currentPB.Height;
                Rectangle r = new Rectangle(x, y, width, height);
                ComponentName currentComponentName;
                if (currentPB.Image.Equals(toolPump.Image))
                {
                    currentComponentName = ComponentName.Pump;


                }

                else if (currentPB.Image.Equals(toolSplitter.Image))
                {
                    currentComponentName = ComponentName.Splitter;
                }
                else if (currentPB.Image.Equals(toolSplitterAdj.Image))
                {
                    currentComponentName = ComponentName.SplitterAdj;
                }
                else if (currentPB.Image.Equals(toolMerger.Image))
                {
                    currentComponentName = ComponentName.Merger;
                }
                else //then it's a sink
                {
                    currentComponentName = ComponentName.Sink;
                }
                if (flowly.CheckFreeSpot(r))
                {
                    //TODO Fix capacity
                    flowly.CreateComponentDrawn(currentComponentName, r, 5);

                }
                else
                {
                    MessageBox.Show("The element is coliding with another element.");


                }
                // KeyValuePair<Rectangle, Image> item = new KeyValuePair<Rectangle, Image>(r, currentPB.Image);

                // dictionary.Add(r, currentPB.Image);

                // Paint(item);

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
            modePipeCreate = true;
            HighlightCurrentPB(sender as PictureBox);
        }

        private void ActivateCreating(PictureBox pb)
        {
            modeCreate = true;
            modePipeCreate = false;
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

        private void clearGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Do you really want to clear the grid?", "Confirmation", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                flowly.ClearGrid(theGrid);
            }
        }

        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            flowly.SaveGrid(theGrid);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult dg = MessageBox.Show("Do you want to save before closing?", "Confirmation", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                flowly.SaveGrid(theGrid);
                flowly.ClearGrid(theGrid);
                flowly.OpenFile(grid);
            }
            else
            {
                flowly.ClearGrid(theGrid);
                flowly.OpenFile(grid);
            }


        }
    }
}

