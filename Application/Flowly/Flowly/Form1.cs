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


        private WorkingMode currentWorkingMode;

        string nameForForm;

        private bool modeCreate = false;

        private ComponentDrawn currentSelectedComponent;

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
            currentSelectedComponent = null;



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
            if (currentPB != null)
            {
                //if(theImageLocationIsValid)
                int x = xPos;
                int y = yPos;
                if (currentWorkingMode != WorkingMode.pipe)
                {
                    if (pipe != null)
                    {
                        flowly.RemovePipe(pipe);
                        pipe = null;
                        lastPoint = new Point(-1, -1);
                    }
                }
                Point newPoint;
                switch (currentWorkingMode)
                {
                    case WorkingMode.pipe:
                        nudCapacity.Enabled = false;
                        nudFlow.Enabled = false;
                        trackBarLeft.Enabled = false;
                        trackBarRight.Enabled = false;
                        btnUpdate.Enabled = false;
                        nudCapacity.Value = 0;
                        nudFlow.Value = 0;
                        trackBarLeft.Value = 50;
                        trackBarRight.Value = 50;
                        if (currentPB.Image.Equals(toolPipe.Image))
                        {
                            newPoint = new Point(x, y);

                            //start drawing pipeline.
                            if (lastPoint.X == -1 || lastPoint.Y == -1)
                            {
                                ConnectionPoint cp = flowly.GetConnectionPointAt(newPoint);
                                if (cp != null)
                                {

                                    if (cp.IsOutput)
                                    {
                                       
                                        // cp.SetAvailable(false);
                                        pipe = new Pipe();
                                        pipe.SetConnection(cp);
                                        cp.PipeConnection = pipe;
                                        lastPoint = newPoint;
                                        pipe.AddPointToList(lastPoint);
                                        flowly.HighlightAllAvailableInputs(pipe.GiveMeYourConnectionPoints().First().ComponentDrawnBelong);
                                    }
                                }
                                else
                                {

                                    return;
                                }
                            }
                            else
                            {

                                bool isAdded = flowly.DrawPipeline(lastPoint, newPoint, ref pipe);
                                if (isAdded)
                                {
                                    lastPoint = newPoint;
                                    if (pipe.GiveMeYourConnectionPoints().Count == 2)
                                    {
                                        flowly.HighlightAllAvailableOutputs();
                                        MessageBox.Show("Connected");
                                        flowly.AddComponentDrawn(pipe);
                                        pipe = null;
                                        lastPoint = new Point(-1, -1);

                                    }
                                    else
                                    {
                                        /*ConnectionPoint cp = flowly.GetConnectionPointAt(newPoint);
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
                                                    flowly.AddComponentDrawn(pipe);
                                                    pipe = null;
                                                    lastPoint = new Point(-1, -1);
                                                }
                                                else
                                                {
                                                    cp.SetAvailable(true);
                                                    pipe.RemoveConnection(cp);
                                                }

                                        }
                                        */

                                    }

                                }
                            }
                        }
                        
                        break;
                    case WorkingMode.create:
                        nudCapacity.Enabled = false;
                        nudFlow.Enabled = false;
                        trackBarLeft.Enabled = false;
                        trackBarRight.Enabled = false;
                        btnUpdate.Enabled = false;
                        nudCapacity.Value = 0;
                        nudFlow.Value = 0;
                        trackBarLeft.Value = 50;
                        trackBarRight.Value = 50;

                        x -= currentPB.Width / 2;
                        y -= currentPB.Height / 2;
                        if (flowly.Grid == null)
                        {
                            MessageBox.Show("No grid is open! Create a new grid or open an existing one!");

                        }
                        else
                        {
                            int width = currentPB.Width;
                            int height = currentPB.Height;
                            Rectangle r = new Rectangle(x, y, width, height);
                            ComponentName currentComponentName;
                            ComponentDrawn createdComponent;
                            if (currentPB.Image.Equals(toolPump.Image))
                            {
                                currentComponentName = ComponentName.Pump;


                            }


                            else if (currentPB.Image.Equals(toolPipe.Image))
                            {
                                currentComponentName = ComponentName.Pipe;
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
                                //TODO capacity
                               if(flowly.CreateComponentDrawn(currentComponentName, r, 5))
                                {
                                   
                                }
                                

                            }
                            else
                            {
                                MessageBox.Show("The element is coliding with another element.");


                            }

                        }
                        // KeyValuePair<Rectangle, Image> item = new KeyValuePair<Rectangle, Image>(r, currentPB.Image);

                        // dictionary.Add(r, currentPB.Image);

                        // Paint(item);
                        break;
                    case WorkingMode.remove:
                        nudCapacity.Enabled = false;
                        nudFlow.Enabled = false;
                        trackBarLeft.Enabled = false;
                        trackBarRight.Enabled = false;
                        btnUpdate.Enabled = false;
                        nudCapacity.Value = 0;
                        nudFlow.Value = 0;
                        trackBarLeft.Value = 50;
                        trackBarRight.Value = 50;

                        newPoint = new Point(x, y);
                        ComponentDrawn componentAtPoint = flowly.GetComponentPointAt(newPoint);
                        if (componentAtPoint == null)
                        {
                            if (flowly.Grid == null)
                            {
                                MessageBox.Show("No grid is open! Create a new grid or open an existing one!");
                            }
                            else
                            {
                                MessageBox.Show("No component selected");
                            }

                            return;
                        }
                        else
                        {

                            DialogResult dg = MessageBox.Show(String.Format("Do you wish to delete {0}?", componentAtPoint.GetType().Name), "Deleting component", MessageBoxButtons.YesNo);
                            if (dg == DialogResult.Yes)
                            {
                                flowly.DeleteComponent(componentAtPoint);

                            }

                        }

                        break;
                    case WorkingMode.edit:
                        newPoint = new Point(x, y);
                        currentSelectedComponent = flowly.GetComponentPointAt(newPoint);
                        if (currentSelectedComponent == null)
                        {
                            if (flowly.Grid == null)
                            {
                                MessageBox.Show("No grid is open! Create a new grid or open an existing one!");
                            }
                            else
                            {
                                MessageBox.Show("No component selected");
                            }

                            return;
                        }
                        if(currentSelectedComponent.DiffCurrFlowPossible == true)
                        {
                            List<ConnectionPoint> currentConnectionPoints = new List<ConnectionPoint>();
                            foreach (ConnectionPoint item in currentSelectedComponent.GiveMeYourConnectionPoints())
                            {
                                if (item.IsOutput)
                                {
                                    currentConnectionPoints.Add(item);
                                }
                            }
                            if (currentSelectedComponent.CurrentFlow == 0)
                            {
                                trackBarLeft.Value = 50;
                                trackBarRight.Value = 50;
                            }
                            else
                            {
                                trackBarLeft.Value = (Convert.ToInt32(currentSelectedComponent.CurrentFlow) / Convert.ToInt32(currentSelectedComponent.CurrentFlow - currentConnectionPoints[0].CurrentFlow));
                                trackBarRight.Value = (Convert.ToInt32(currentSelectedComponent.CurrentFlow) / Convert.ToInt32(currentSelectedComponent.CurrentFlow - currentConnectionPoints[1].CurrentFlow));
                            }
                            
                            trackBarLeft.Enabled = true;
                            trackBarRight.Enabled = true;
                        }
                        nudFlow.Value = (decimal)currentSelectedComponent.CurrentFlow;
                        nudCapacity.Value = (decimal)currentSelectedComponent.Capacity;
                        btnUpdate.Enabled = true;
                        nudFlow.Enabled = true;
                        nudCapacity.Enabled = true;
                        
                        break;
                    default:
                        break;


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
            currentWorkingMode = WorkingMode.pipe;

            HighlightCurrentPB(sender as PictureBox);
           
        }

        void RefreshGridFromMode()
        {
            if (currentWorkingMode != null)
            {
                if (currentWorkingMode == WorkingMode.pipe)
                {
                    flowly.UpdateGrid();
                }
            }
        }

        private void ActivateCreating(PictureBox pb)
        {
            RefreshGridFromMode();
            currentWorkingMode = WorkingMode.create;
            HighlightCurrentPB(pb);


        }

        private void HighlightCurrentPB(PictureBox pb)
        {
            if (currentPB != null)
            {
                currentPB.BackColor = Control.DefaultBackColor;
            }
            if (currentWorkingMode == WorkingMode.pipe)
            {
                flowly.HighlightAllAvailableOutputs();
            }
          
            //if (modeCreate)
            //{
            //    //followCursorPB.Image = pb.Image;
            //    //followCursorPB.Width = pb.Width;
            //    //followCursorPB.Height = pb.Height;
            //}
            pb.BackColor = Color.Yellow;
            currentPB = pb;
        }

        private void toolEdit_Click(object sender, EventArgs e)

        {
            RefreshGridFromMode();
            currentWorkingMode = WorkingMode.edit;
            HighlightCurrentPB(sender as PictureBox);
        }

        private void toolRemove_Click(object sender, EventArgs e)
        {
            RefreshGridFromMode();
            currentWorkingMode = WorkingMode.remove;
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
            if (flowly.Grid != null)
            {
                DialogResult dg = MessageBox.Show("Do you really want to clear the grid?", "Confirmation", MessageBoxButtons.YesNo);
                if (dg == DialogResult.Yes)
                {
                    flowly.ClearGrid();

                }
            }
            else
            {
                MessageBox.Show("No grid is open! Create a new grid or open an existing one!");
            }
        }

        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (flowly.Grid == null)
            {
                MessageBox.Show("No grid is open! Create a new grid or open an existing one!");
            }
            else
            {

                //save as
                flowly.SaveAsGrid(theGrid, out nameForForm);
                if (nameForForm == "")
                {

                }
                else
                {
                    this.Text = this.Text = "Flowly - flow system / " + nameForForm;
                }


            }
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flowly.Grid != null)
            {
                // ask this if there are any changes!
                DialogResult saveChanges = MessageBox.Show("Do you want to save before opening a new grid?", "Save before closing", MessageBoxButtons.YesNo);
                if (saveChanges == DialogResult.Yes)
                {
                    //save and open
                    if (theGrid.Name != null)
                    {
                        flowly.SaveGrid(theGrid, out nameForForm);
                    }
                    else
                    {
                        flowly.SaveAsGrid(theGrid, out nameForForm);
                    }


                    if (nameForForm == "")
                    {

                    }
                    else
                    {
                        this.Text = "Flowly - flow system / " + nameForForm;
                    }

                    flowly.NewFile(grid);

                    this.Text = "Flowly - flow system / (New grid)";


                }
                else
                {
                    flowly.NewFile(grid);

                    this.Text = "Flowly - flow system / (New grid)";
                }
            }
            else
            {
                flowly.NewFile(grid);

                this.Text = "Flowly - flow system / (New grid)";
            }

            theGrid = flowly.Grid;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flowly.Grid != null)
            {
                // ask this if there are any changes!
                DialogResult saveChanges = MessageBox.Show("Do you want to save before closing?", "Save before closing", MessageBoxButtons.YesNo);
                if (saveChanges == DialogResult.Yes)
                {
                    //save and open
                    if (theGrid.Name != null)
                    {
                        flowly.SaveGrid(theGrid, out nameForForm);
                    }
                    else
                    {
                        flowly.SaveAsGrid(theGrid, out nameForForm);
                    }


                    if (nameForForm == "")
                    {

                    }
                    else
                    {
                        this.Text = "Flowly - flow system / " + nameForForm;
                    }

                    flowly.OpenFile(grid, out nameForForm);
                    if (nameForForm == "")
                    {

                    }
                    else
                    {
                        this.Text = "Flowly - flow system / " + nameForForm;
                    }


                }
                else
                {
                    // open


                    flowly.OpenFile(grid, out nameForForm);
                    if (nameForForm == "")
                    {

                    }
                    else
                    {
                        this.Text = "Flowly - flow system / " + nameForForm;
                    }
                }
            }
            else
            {
                //open
                flowly.OpenFile(grid, out nameForForm);
                if (nameForForm == "")
                {

                }
                else
                {
                    this.Text = "Flowly - flow system / " + nameForForm;
                }
            }


            theGrid = flowly.Grid;

        }

        private void saveWithoutAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flowly.Grid != null)
            {
                if (flowly.Grid.Destination == null)
                {
                    //save as 
                    flowly.SaveAsGrid(theGrid, out nameForForm);
                    this.Text = this.Text = "Flowly - flow system / " + nameForForm;
                }
                else
                {
                    //save
                    flowly.SaveGrid(theGrid, out nameForForm);
                    this.Text = this.Text = "Flowly - flow system / " + nameForForm;
                }
            }
            else
            {
                MessageBox.Show("No grid is open! Create a new grid or open an existing one!");
            }


        }

        private void closeGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flowly.Grid != null)
            {
                flowly.ClearGrid();
                flowly.CloseGrid();
                this.Text = "Flowly - flow system / (No name)";
            }
            else
            {
                MessageBox.Show("No grid is open! Create a new grid or open an existing one!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //When user goes into Edit Mode
            //Update button is enabled and changes on selected component are possible
            int x = xPos;
            int y = yPos;
            if(currentWorkingMode == WorkingMode.edit)
            {
                float givenFlow = (float)nudFlow.Value;
                float givenCapacity = (float)nudCapacity.Value;
                if (currentSelectedComponent == null)
                {
                    if (flowly.Grid == null)
                    {
                        MessageBox.Show("No grid is open! Create a new grid or open an existing one!");
                    }
                    else
                    {
                        MessageBox.Show("No component selected");
                    }

                    return;
                }  
                // If its adjustable splitter
                else if(currentSelectedComponent.DiffCurrFlowPossible == true)
                {
                    currentSelectedComponent.SetCapacity(givenCapacity);
                    currentSelectedComponent.SetCurrentFlow(givenFlow);

                    List<ConnectionPoint> currentConnectionPoints = new List<ConnectionPoint>();
                    foreach (ConnectionPoint item in currentSelectedComponent.GiveMeYourConnectionPoints())
                    {
                        if (item.IsOutput)
                        {
                            currentConnectionPoints.Add(item);
                        }
                    }

                    currentConnectionPoints[0].SetCurrentFlow(currentSelectedComponent.CurrentFlow * trackBarLeft.Value);
                    currentConnectionPoints[1].SetCurrentFlow(currentSelectedComponent.CurrentFlow * trackBarRight.Value);
                }
                //If its other type of component
                else
                {
                    currentSelectedComponent.SetCapacity(givenCapacity);
                    currentSelectedComponent.SetCurrentFlow(givenFlow);
                }






            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void trackBarRight_ValueChanged(object sender, EventArgs e)
        {
            trackBarLeft.Value = 100 - trackBarRight.Value;
            labelRightTrack.Text = trackBarRight.Value.ToString() + "%";
        }

        private void trackBarLeft_ValueChanged(object sender, EventArgs e)
        {
            trackBarRight.Value = 100 - trackBarLeft.Value;
            labelLeftTrack.Text = trackBarLeft.Value.ToString() + "%";
        }
    }
    enum WorkingMode
    {
        pipe,
        create,
        remove,
        edit
    }
}

