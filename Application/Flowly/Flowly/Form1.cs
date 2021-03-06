﻿using Flowly.GeneratedCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Flowly
{
    /// <summary>
    /// The main window form of the application.
    /// </summary>
    public partial class Form1 : Form, IChangeOccured, IGridChanged
    {
        private int yPos;
        private int xPos;
        SystemFlowly flowly;
        Grid theGrid;
        bool askMeSave;
       
    
        private WorkingMode currentWorkingMode;

        string nameForForm;

        private bool modeCreate = false;
        private bool changeIsMade = false;

        private ComponentDrawn currentSelectedComponent;

        //for testingperposes
        PictureBox currentPB;

        ListBox myChanges = new ListBox();


        public Form1()
        {

            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);

            InitializeComponent();

            askMeSave = false;




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
            flowly = new SystemFlowly(theGrid, this, this);
            currentSelectedComponent = null;
            SetTrackBarVisibility(false);




        }

        public void GridChanged()
        {
            listBoxStates.Items.Clear();
        }


        public void ChangeOccured(Change theChange)
        {

            Invoke( new Action( () =>
            {
                
                    listBoxStates.Items.Add(theChange.Desctiption);
                    askMeSave = true;
                
            }
            ));
            
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
                        ResetProperties();
                        if (currentPB.Image.Equals(toolPipe.Image))
                        {
                            newPoint = new Point(x, y);
                            //  MessageBox.Show(newPoint.ToString() + "\nx:" + newPoint.X + " y:" + newPoint.Y);
                            //start drawing pipeline.
                            if (lastPoint.X == -1 || lastPoint.Y == -1)
                            {
                                ConnectionPoint cp = flowly.GetConnectionPointAt(newPoint);
                                if (cp != null)
                                {

                                    if (cp.IsOutput)
                                    {
                                        flowly.CreateChange("Pipeline");////////////////////////////////
                                        newPoint = cp.PipeStartPoint;
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

                                bool isAdded = flowly.DrawPipeToCursor(lastPoint, newPoint, ref pipe);
                                if (isAdded)
                                {
                                    //continues drawing line
                                    lastPoint = newPoint;

                                    //when connected to a component stops
                                    if (pipe.GiveMeYourConnectionPoints().Count == 2)
                                    {
                                        
                                        pipe.PipePoints.RemoveAt(pipe.PipePoints.Count - 1);
                                        pipe.PipePoints.Add(pipe.GiveMeYourConnectionPoints().Last().PipeStartPoint);
                                        flowly.DrawPipeline(pipe);
                                        flowly.AddComponentDrawn(pipe);

                                        flowly.UpdateGrid();
                                        flowly.HighlightAllAvailableOutputs();
                                        MessageBox.Show("Connected");
                                        pipe = null;
                                        lastPoint = new Point(-1, -1);

                                    }
                                }
                            }
                        }

                        break;
                    case WorkingMode.create:
                        //  ResetProperties();

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




                            if (flowly.CheckFreeSpot(r))
                            {
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


                                if (flowly.CreateComponentDrawn(currentComponentName, r, nudFlow.Value, nudCapacity.Value, trackBarLeft.Value, trackBarRight.Value))
                                {


                                    if (currentComponentName == ComponentName.Pump)
                                    {

                                    }
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

                        //    ResetProperties();
                        break;
                    case WorkingMode.remove:
                        ResetProperties();

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

                        ResetProperties();
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
                        //If component is adjustable splitter ->
                        if (currentSelectedComponent.DiffCurrFlowPossible == true)
                        {


                            SetTrackBarVisibility(true);
                            List<ConnectionPoint> currentOutputConnectionPoints = new List<ConnectionPoint>();
                            foreach (ConnectionPoint item in currentSelectedComponent.GiveMeYourConnectionPoints())
                            {
                                if (item.IsOutput)
                                {
                                    currentOutputConnectionPoints.Add(item);
                                }
                            }
                            //if (currentSelectedComponent.CurrentFlow == 0)
                            //{
                            //    trackBarLeft.Value = 50;
                            //    trackBarRight.Value = 50;
                            //}
                            //else
                            //{
                            //    int maxFlow = Convert.ToInt32(currentSelectedComponent.CurrentFlow);
                            //    trackBarLeft.Value = Convert.ToInt32((maxFlow - currentOutputConnectionPoints[1].CurrentFlow) * 100) / maxFlow;
                            //    trackBarRight.Value = Convert.ToInt32((maxFlow - currentOutputConnectionPoints[0].CurrentFlow) * 100) / maxFlow;
                            //}

                            Splitter testSplitter = (Splitter)currentSelectedComponent;
                            trackBarLeft.Value = testSplitter.TopOutputPercentage;
                            trackBarRight.Value = testSplitter.BottomOutputPercentage;

                            SetTrackBarVisibility(true);
                        }
                        else
                        {


                            SetTrackBarVisibility(false);


                            trackBarLeft.Enabled = false;
                            trackBarLeft.Value = 50;
                            trackBarRight.Enabled = false;
                            trackBarRight.Value = 50;

                        }
                        nudCapacity.Value = (decimal)currentSelectedComponent.Capacity;
                        nudFlow.Value = (decimal)currentSelectedComponent.CurrentFlow;

                        btnUpdate.Enabled = true;
                        if (currentSelectedComponent.EditableProperties.Contains(EditablePropertiesEnum.flow))
                        {
                            nudFlow.Enabled = true;
                        }
                        else
                        {
                            nudFlow.Enabled = false;
                        }
                        if (currentSelectedComponent.EditableProperties.Contains(EditablePropertiesEnum.capacity))
                        {
                            nudCapacity.Enabled = true;
                        }
                        else
                        {
                            nudCapacity.Enabled = false;
                        }

                        break;
                    default:
                        break;


                }
                // KeyValuePair<Rectangle, Image> item = new KeyValuePair<Rectangle, Image>(r, currentPB.Image);

                // dictionary.Add(r, currentPB.Image);

                // Paint(item);
            }
        }

        public void SetTrackBarVisibility(Boolean value)
        {
            trackBarLeft.Enabled = true;
            trackBarRight.Enabled = true;
            trackBarLeft.Visible = value;
            trackBarRight.Visible = value;
            labelLeftTrack.Visible = value;
            labelRightTrack.Visible = value;
            labelLeft.Visible = value;
            labelRight.Visible = value;
        }
        public void ResetProperties()
        {
            nudCapacity.Enabled = false;
            nudFlow.Enabled = false;
            trackBarLeft.Enabled = false;
            trackBarRight.Enabled = false;
            btnUpdate.Enabled = false;
            nudCapacity.Value = 0;
            nudFlow.Value = 0;
            trackBarLeft.Value = 50;
            trackBarRight.Value = 50;
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
            //flowly.CreateChange("0");
            SetTrackBarVisibility(false);
            nudCapacity.Enabled = false;
            nudFlow.Enabled = false;
            currentWorkingMode = WorkingMode.pipe;

            HighlightCurrentPB(sender as PictureBox);

        }

        void RefreshGridFromMode()
        {
            if (currentWorkingMode != null)
            {
                if (currentWorkingMode == WorkingMode.pipe)
                {
                    
                        if (pipe != null)
                        {
                            flowly.RemovePipe(pipe);
                            pipe = null;
                            lastPoint = new Point(-1, -1);
                        }
                    
                    ResetProperties();
                    flowly.UpdateGrid();
                }
            }
        }

        private void ActivateCreating(PictureBox pb)
        {
            ResetProperties();

            RefreshGridFromMode();
            currentWorkingMode = WorkingMode.create;
            HighlightCurrentPB(pb);

            /*

              switch (currentComponentName)
                            {
                                case ComponentName.Pump:
                                    nudCapacity.Enabled = true;
                                    nudFlow.Enabled = true;
                                    btnUpdate.Enabled = true;
                                    break;
                                case ComponentName.Sink:
                                    nudCapacity.Enabled = true;
                                    btnUpdate.Enabled = true;
                                    break;
                                case ComponentName.SplitterAdj:
                                    trackBarLeft.Enabled = true;
                                    trackBarRight.Enabled = true;
                                    trackBarRight.Visible = true;
                                    trackBarLeft.Visible = true;
                                    btnUpdate.Enabled = true;
                                    break;

                                default:
                                    //
                                    break;



                            }
              */

            switch (pb.Name)
            {
                case "toolPump":
                    nudCapacity.Enabled = true;
                    nudFlow.Enabled = true;
                    SetTrackBarVisibility(false);
                    break;

                case "toolSink":
                    nudCapacity.Enabled = true;
                    SetTrackBarVisibility(false);
                    break;
                case "toolSplitterAdj":
                    SetTrackBarVisibility(true);
                    break;

                case "toolSplitter":
                    SetTrackBarVisibility(false);
                    break;
                case "toolMerger":
                    SetTrackBarVisibility(false);
                    break;
                default:

                    //
                    break;

            }


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
            SetTrackBarVisibility(false);
            RefreshGridFromMode();
            currentWorkingMode = WorkingMode.edit;
            HighlightCurrentPB(sender as PictureBox);
        }

        private void toolRemove_Click(object sender, EventArgs e)
        {
            SetTrackBarVisibility(false);
            ResetProperties();
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
                    flowly.ClearGrid(true);

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
                askMeSave = false;
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
                if (askMeSave == true)
                {
                    DialogResult saveChanges = MessageBox.Show("Do you want to save before opening a new grid?", "Save before closing", MessageBoxButtons.YesNo);
                    if (saveChanges == DialogResult.Yes)
                    {
                        //save and open
                        if (theGrid.Name != null)
                        {
                            flowly.SaveGrid(theGrid, out nameForForm);
                            // askMeSave = false;
                        }
                        else
                        {
                            flowly.SaveAsGrid(theGrid, out nameForForm);
                            //askMeSave = false;
                        }
                    }
                    askMeSave = false;


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
                if (askMeSave == true)
                {
                    DialogResult saveChanges = MessageBox.Show("Do you want to save before closing?", "Save before closing", MessageBoxButtons.YesNo);
                    if (saveChanges == DialogResult.Yes)
                    {
                        //save and open
                        if (theGrid.Name != null)
                        {
                            flowly.SaveGrid(theGrid, out nameForForm);
                            // askMeSave = false;
                        }
                        else
                        {
                            flowly.SaveAsGrid(theGrid, out nameForForm);
                            //  askMeSave = false;
                        }
                    }

                    askMeSave = false;


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
                    askMeSave = false;
                    this.Text = this.Text = "Flowly - flow system / " + nameForForm;
                }
                else
                {
                    //save
                    flowly.SaveGrid(theGrid, out nameForForm);
                    askMeSave = false;
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
                flowly.ClearGrid(false);
                flowly.CloseGrid(true);
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

            if (currentWorkingMode == WorkingMode.edit && changeIsMade)
            {
                int x = xPos;
                int y = yPos;
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
                else
                {
                    int tbLeft = trackBarLeft.Value;
                    int tbRight = trackBarRight.Value;

                    flowly.EditComponentDrawn(currentSelectedComponent, givenFlow, givenCapacity, tbLeft, tbRight);
                    changeIsMade = false;
                    flowly.UpdateGrid();
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
            changeIsMade = true;
        }

        private void trackBarLeft_ValueChanged(object sender, EventArgs e)
        {
            trackBarRight.Value = 100 - trackBarLeft.Value;
            labelLeftTrack.Text = trackBarLeft.Value.ToString() + "%";
            changeIsMade = true;
        }

        private void nudCapacity_ValueChanged(object sender, EventArgs e)
        {
            changeIsMade = true;
        }

        private void nudFlow_ValueChanged(object sender, EventArgs e)
        {
            if (nudFlow.Value > nudCapacity.Value && nudFlow.Enabled)
            {
                nudFlow.Value = nudCapacity.Value;

            }
            changeIsMade = true;


        }

        private void buttonGoTo_Click(object sender, EventArgs e)
        {
            if (listBoxStates.SelectedItem != null)
            {
                flowly.UndoLastChange(grid, listBoxStates.SelectedItem.ToString());

                int currNumber = listBoxStates.SelectedIndex;

                string[] files = Directory.GetFiles("../../Changes")
                                         .Select(path => Path.GetFileName(path))
                                         .ToArray();

                for (int counter = currNumber; counter < listBoxStates.Items.Count; counter++)
                {
                    File.Delete("../../Changes/" + files[counter]);

                }
                for (int counter = listBoxStates.Items.Count - 1; counter >= currNumber; counter--)
                {
                    listBoxStates.Items.RemoveAt(listBoxStates.Items.Count - 1);
                }
                flowly.counterChange = currNumber;

            }
            else
            {
                MessageBox.Show("Select a change!");
            }
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            if (listBoxStates.Items.Count == 0)
            {
                MessageBox.Show("No changes!");
            }
            else
            {
                int total = listBoxStates.Items.Count;

                flowly.UndoLastChange(grid, listBoxStates.Items[total - 1].ToString());

                string[] files = Directory.GetFiles("../../Changes")
                                          .Select(path => Path.GetFileName(path))
                                          .ToArray();



                File.Delete("../../Changes/" + files.Where(x => x.Contains((total - 1).ToString())).First());
                listBoxStates.Items.RemoveAt(total - 1);
                flowly.counterChange = total - 1;

            }



        }
        FormWindowState LastWindowState = FormWindowState.Minimized;

        private void Form1_Resize(object sender, EventArgs e)
        {
           
            if (WindowState != LastWindowState)
            {
                LastWindowState = WindowState;


                if (WindowState == FormWindowState.Maximized)
                {
                    //Thread th = new Thread(() => { Thread.Sleep(1000); flowly.UpdateGrid(); });
                    //th.Start();
                    // Maximized!
                }
                if (WindowState == FormWindowState.Normal)
                {
                    Thread th = new Thread(() => { Thread.Sleep(200); flowly.UpdateGrid(); });
                    th.Start();
                    // Restored!
                }
            }
        }





        //private void openLogWithChangesToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Form logWithChanges = new Form();
        //    logWithChanges.ClientSize = new System.Drawing.Size(349, 311);
        //    logWithChanges.Text = "Changes";
        //    logWithChanges.Show();

        //    myChanges.Location = new System.Drawing.Point(57, 31);
        //    myChanges.Size = new System.Drawing.Size(230, 186);

        //    Button buttonRefresh = new Button();
        //    buttonRefresh.Location = new System.Drawing.Point(29, 251);
        //    buttonRefresh.Size = new System.Drawing.Size(101, 35);
        //    buttonRefresh.Text = "Refresh";

        //    Button buttonUndo = new Button();
        //    buttonUndo.Location = new System.Drawing.Point(220, 251);
        //    buttonUndo.Size =  new System.Drawing.Size(101, 35);
        //    buttonUndo.Text = "Undo";






        //    string[] changeNumbers = Directory.GetFiles("../../Changes")
        //                                      .Select(path => Path.GetFileName(path))
        //                                      .ToArray();
        //    foreach (string number in changeNumbers)
        //    {
        //        myChanges.Items.Add(number);
        //    }



        //    logWithChanges.Controls.Add(buttonRefresh);
        //    logWithChanges.Controls.Add(buttonUndo);
        //    logWithChanges.Controls.Add(myChanges);

        //   buttonUndo.Click += new EventHandler(buttonUndo_Click);
        //    buttonRefresh.Click += new EventHandler(buttonRefresh_Click);

        //}

        //private void buttonUndo_Click(object sender, EventArgs e)
        //{
        //    if(myChanges.SelectedItem!=null)
        //    {
        //        flowly.UndoLastChange(grid, myChanges.SelectedItem.ToString());
        //    }
        //    else
        //    {
        //        MessageBox.Show("Select a change!");
        //    }
        //}
        //private void buttonRefresh_Click(object sender, EventArgs e)
        //{
        //    myChanges.Items.Clear();
        //    string[] changeNumbers = Directory.GetFiles("../../Changes")
        //                                       .Select(path => Path.GetFileName(path))
        //                                       .ToArray();
        //    foreach (string number in changeNumbers)
        //    {
        //        myChanges.Items.Add(number);
        //    }
        //}
    }
    enum WorkingMode
    {
        pipe,
        create,
        remove,
        edit
    }
}

