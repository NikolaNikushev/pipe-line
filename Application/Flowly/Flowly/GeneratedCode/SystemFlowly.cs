﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Flowly.GeneratedCode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO; //because of FileStream
using System.Runtime.Serialization.Formatters.Binary; //because of BinaryFormatter
using System.Runtime.Serialization;//because of SerializationException
namespace Flowly
{
    /// <summary>
    /// Class named "SystemFlowly". Meant to possess many of the methods to manipulate, create, delete "ComponentDrawn"-s.
    /// Has a list for "Change"-s to keep track of them.
    /// Has a list meant to be a toolbox.
    /// </summary>
    public class SystemFlowly
    {
        /// <summary>
        /// toolbox of the program. Simpe list of "ToolboxComponent"-s. Make the difference between "ComponentDrawn" and "ToolboxComponent".
        /// </summary>
        /// 

        private IGridChanged gridChangedListener;

        private IChangeOccured changeListener;

        private List<ToolboxComponent> listOfToolboxItems;

        private Grid grid;

        private List<Change> changes;

        public int counterChange;

        public Grid Grid
        {
            get
            {
                return grid;
            }
        }


        public SystemFlowly(Grid grid,IChangeOccured theChangeListener, IGridChanged theGridChangedListener)
        {
            this.grid = grid;
            counterChange = 0;
            Array.ForEach(Directory.GetFiles("../../Changes"), File.Delete);
            changeListener = theChangeListener;
            gridChangedListener = theGridChangedListener;
            changes = new List<Change>();
        }

        /// <summary>
        /// Checks if a particular area is free.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>True if it is, false otherwise.</returns>
        public virtual bool CheckFreeSpot(Rectangle r)
        {
            
            List<Rectangle> rectangles = grid.GetComponentsRectangles();
            foreach (Rectangle rect in rectangles)
            {
                if (r.IntersectsWith(rect)) return false;
            }

            return !grid.CheckComponentIntersectsWithPipe(r);
            
        }

        /// <summary>
        /// After deleting a component makes a spot free.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>True if successfull, false otherwise.</returns>
        public virtual bool MakeSpotFree(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        internal ConnectionPoint GetConnectionPointAt(Point newPoint)
        {

            if (grid != null)
            {
                return grid.IsInputOutput(newPoint);
            }
            return null;
        }

        internal ComponentDrawn GetComponentPointAt(Point newPoint)
        {
            if (grid != null)
            {
                return grid.GetComponentAt(newPoint);
            }
            return null;


        }

        /// <summary>
        /// Opposite of the above method.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>True for successfull, false otherwise.</returns>
        public virtual bool MakeSpotBusy(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        internal bool DrawPipeToCursor(Point start, Point end, ref Pipe currentPipe)
        {
           

            return grid.DrawPipeToPoint(start, end, ref currentPipe);
        }

        internal void AddPipe(Pipe pipe)
        {
            //save state
            CreateChange("Add pipe.");
            //end
            grid.AddPipe(pipe);

         
        }

        internal void RemovePipe(Pipe pipe)
        {
            //save state
            CreateChange("Remove pipe.");
            //end
            grid.RemovePipe(pipe);

          
        }

        /// <summary>
        /// Creates a new instance of class "ComponentDrawn". 
        /// </summary>
        /// <param name="cName">component name</param>
        /// <param name="rectangle">The rectangle that the component will have</param>
        /// <param name="cCapacity">component capacity</param>
        /// <returns>True if successfully created, false otherwise.</returns>
        public virtual bool CreateComponentDrawn(ComponentName cName, Rectangle rectangle,decimal theFlow, decimal theCapacity, int theTopPerc, int theBottomPerc)
        {
            //save state
            CreateChange("Create component.");
            //end

            /* Pump newPump = new Pump(r);
             List<ConnectionPoint> testListOfConnectionPoints = newPump.GiveMeYourConnectionPoints();
             foreach (ConnectionPoint testCP in testListOfConnectionPoints)
             {
                 g.DrawRectangle(Pens.Blue, testCP.rectangle);
             }*/
            ComponentDrawn cd = null;
            switch (cName)
            {
                case ComponentName.Merger:
                    cd = new Merger(rectangle);
                    break;
                case ComponentName.Pipe:
                    cd = new Pipe(rectangle);
                    break;
                case ComponentName.Pump:
                    //  cd = new Pump(rectangle);
                    cd = new Pump(rectangle, (float)theCapacity, (float)theFlow);
                    cd.SetCapacity((float)theCapacity);
                    cd.SetCurrentFlow((float)theFlow);
                    List<ConnectionPoint> pumpOutput = cd.GiveMeYourOutputConnectionPoints();
                    pumpOutput[0].SetCapacity((float)theCapacity);
                    pumpOutput[0].SetCurrentFlow((float)theFlow);
                    break;
                case ComponentName.Sink:
                    //  cd = new Sink(rectangle);
                    cd = new Sink(rectangle, (float)theCapacity);
                    break;
                case ComponentName.Splitter:
                    cd = new Splitter(rectangle, false);
                    break;
                case ComponentName.SplitterAdj:
                    // cd = new Splitter(rectangle, true);
                    cd = new Splitter(rectangle, true, theTopPerc, theBottomPerc);
                    break;

                default:

                    return false;
            }
            if (cd == null)
            {
                return false;
            }
            else
            {
                grid.AddComponentDrawnToGridList(cd);
                grid.Paint(cd);


               

                return true;
            }

        }


        //public ComponentDrawn GetComponentAtRectangle(Rectangle theRectangle)
        //{
        //    foreach(ComponentDrawn cd in Grid.ListOfComponents)
        //    {
        //        if(cd.RectangleBig==theRectangle)
        //        {
        //            return cd;
        //        }
               
        //    }
        //    return null;
        //}

        internal void DrawPipeline(Pipe pipe)
        {
            //save state
            CreateChange("Draw pipeline.");
            //end

            grid.DrawPipelineAndUpdateFLow(pipe);
            
        }

        internal void AddComponentDrawn(Pipe pipe)
        {
            grid.AddComponentDrawnToGridList(pipe);
        }

        /// <summary>
        /// Deletes a given "ComponentDrawn".
        /// </summary>
        /// <param name="givenComponent"></param>
        /// <returns>True if successfull, false otherwise.</returns>
        public virtual bool DeleteComponent(ComponentDrawn givenComponent)
        {
            //save state
            CreateChange("Delete component.");
            //end

            grid.RemoveComponentDrawnFromGridList(givenComponent);

            

            return true;
        }
        /// <summary>
        /// A "ComponentDrawn" is passed and the particular componentDrawn's properties should be changed.
        /// </summary>
        /// <param name="givenComponent"></param>
        /// <returns>True if successfull, false otherwise.</returns>
        public virtual bool EditComponentDrawn(ComponentDrawn cGivenComponent, float cGivenFlow, float cGivenCapacity, int cTbLeft, int cTbRight)
        {
            //save state
            CreateChange("Edit component.");
            //end


            try
            {
                if (cGivenFlow > cGivenCapacity)
                {
                    cGivenFlow = cGivenCapacity;
                }
                if (cGivenComponent is Pump)
                {
                    cGivenComponent.SetCapacity(cGivenCapacity);
                    cGivenComponent.SetCurrentFlow(cGivenFlow);
                    List<ConnectionPoint> pumpOutput = cGivenComponent.GiveMeYourOutputConnectionPoints();
                    pumpOutput[0].SetCapacity(cGivenCapacity);
                    pumpOutput[0].SetCurrentFlow(cGivenFlow);

                }
                else if (cGivenComponent is Pipe)
                {
                    cGivenComponent.SetCurrentFlow(cGivenFlow);
                }
                else if (cGivenComponent is Splitter)
                {
                    List<ConnectionPoint> currentOutputConnectionPoints = cGivenComponent.GiveMeYourOutputConnectionPoints();
                    ConnectionPoint currentInputConnectionPoint = cGivenComponent.GiveMeYourInputConnectionPoints()[0];


                    cGivenComponent.SetCapacity(cGivenCapacity);
                    cGivenComponent.SetCurrentFlow(cGivenFlow);
                    currentInputConnectionPoint.SetCapacity(cGivenCapacity);
                    currentInputConnectionPoint.SetCurrentFlow(cGivenFlow);

                    //if adj splitter
                    (cGivenComponent as Splitter).TopOutputPercentage = cTbLeft;
                    (cGivenComponent as Splitter).BottomOutputPercentage = cTbRight;
                    (cGivenComponent as Splitter).UpdateOutputs();

                }
                else if (cGivenComponent is Merger)
                {
                    cGivenComponent.SetCapacity(cGivenCapacity);
                    foreach (ConnectionPoint item in cGivenComponent.GiveMeYourOutputConnectionPoints())
                    {
                        if (cGivenFlow == 0)
                        {
                            item.SetCurrentFlow(0);
                        }
                    }
                    //Split the capacity
                    List<ConnectionPoint> inputTempConnPoints = cGivenComponent.GiveMeYourInputConnectionPoints();
                    inputTempConnPoints[0].SetCapacity(cGivenCapacity / 2);
                    inputTempConnPoints[1].SetCapacity(cGivenCapacity / 2);
                }
                //Sink
                else
                {
                    cGivenComponent.SetCapacity(cGivenCapacity);
                    cGivenComponent.SetCurrentFlow(cGivenFlow);
                    List<ConnectionPoint> sinkInput = cGivenComponent.GiveMeYourInputConnectionPoints();
                    sinkInput[0].SetCapacity(cGivenCapacity);
                    sinkInput[0].SetCurrentFlow(cGivenFlow);

                }



                

                return true;

            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Deletes all "ComponentDrawn"-s from the grid.
        /// </summary>
        /// <param name="givenGrid"></param>
        /// <returns>True for successfull, false otherwise.</returns>
        public virtual bool ClearGrid(bool outside)
        {
            if(outside)
            {
               // save state
                CreateChange("Clear grid.");
                //end
            }



            try
            {
                this.grid.Graphic.Clear(Color.White);
                this.grid.ListOfComponents.Clear();

               
                return true;
            }
            catch
            {
                MessageBox.Show("Something went wrong while clearing the grid!");
                return false;
            }
        }

        /// <summary>
        /// Saves the current grid as a file.
        /// </summary>
        /// <param name="givenGrid"></param>
        /// <returns>True if successfull, false otherwise.</returns>
        public virtual bool SaveAsGrid(Grid givenGrid, out string returnedName)
        {
            returnedName = "";
            bool success = false;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                FileStream myFileStream = null;
                BinaryFormatter myBinaryFormatter = null;

                try
                {
                    myFileStream = new FileStream(saveFileDialog.FileName + ".fly", FileMode.Create, FileAccess.Write);
                    myBinaryFormatter = new BinaryFormatter();
                    givenGrid.Name = Path.GetFileNameWithoutExtension(saveFileDialog.FileName);
                    givenGrid.Destination = saveFileDialog.FileName;
                    SerializationObject newObject = new SerializationObject(givenGrid.Name, givenGrid.ListOfComponents, givenGrid.Destination);
                    myBinaryFormatter.Serialize(myFileStream, newObject);
                    returnedName = givenGrid.Name;
                    MessageBox.Show("Successfully saved - " + givenGrid.Name);
                    success = true;
                }

                catch (Exception e)
                {
                    MessageBox.Show("Somethign went wrong while saving!");
                    MessageBox.Show(e.Message);
                    success = false;
                }
                finally
                {
                    if (myFileStream != null)
                    {

                        myFileStream.Close();

                    }
                }


            }


            return success;

        }


        public virtual bool SaveGrid(Grid givenGrid, out string returnedName)
        {
            bool success = false;

            returnedName = givenGrid.Name;


            FileStream myFileStream = null;
            BinaryFormatter myBinaryFormatter = null;

            try
            {
                myFileStream = new FileStream(givenGrid.Destination + ".fly", FileMode.Create, FileAccess.Write);
                myBinaryFormatter = new BinaryFormatter();


                SerializationObject newObject = new SerializationObject(givenGrid.Name, givenGrid.ListOfComponents, givenGrid.Destination);
                myBinaryFormatter.Serialize(myFileStream, newObject);

                MessageBox.Show("Successfully saved - " + givenGrid.Name);
                success = true;
            }

            catch (Exception e)
            {
                MessageBox.Show("Somethign went wrong while saving!");
                MessageBox.Show(e.Message);
                success = false;
            }
            finally
            {
                if (myFileStream != null)
                {

                    myFileStream.Close();

                }
            }




            return success;

        }

        /// <summary>
        /// Creates a new grid.
        /// </summary>
        /// <returns>True if successfull, false otherwise.</returns>
        public virtual bool NewFile(PictureBox givenPictureBox)
        {
            bool success = false;
            try
            {
                if (this.grid != null)
                {
                    ClearGrid(false);
                    CloseGrid(false);
                }
                Grid newlyCreatedGrid = new Grid(givenPictureBox);
                this.grid = newlyCreatedGrid;

                //save state
              //  CreateChange("Newly created grid.");
                //end

                success = true;

                Array.ForEach(Directory.GetFiles("../../Changes"), File.Delete);
                changes.Clear();
                gridChangedListener.GridChanged();
                counterChange = 0;
            }
            catch
            {
                success = false;
                MessageBox.Show("Something went wrong creating the new grid!");
            }
            return success;


        }

        internal void UpdateGrid()
        {
            grid.PaintAllComponents();
        }

        internal void HighlightAllAvailableInputs(ComponentDrawn currentComponent)
        {
            grid.HighightAllAvailableInputs(currentComponent);
        }

        internal void HighlightAllAvailableOutputs()
        {
            grid.HighightAllAvailableOutputs();
        }
        /// <summary>
        /// Opens already created and saved grid.
        /// </summary>
        /// <returns>True if successfull, false otherwise.</returns>
        public virtual bool OpenFile(PictureBox givenPictureBox, out string returnedName)
        {


            returnedName = "";

            bool success = false;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (this.grid != null)
                {
                    ClearGrid(false);
                    CloseGrid(false);
                }

                FileStream myFileStream = null;
                BinaryFormatter myBinaryFormatter = null;
                try
                {
                    myFileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                    myBinaryFormatter = new BinaryFormatter();

                    SerializationObject myNewOpenObj = (SerializationObject)myBinaryFormatter.Deserialize(myFileStream);
                    Grid myNewGrid = new Grid(givenPictureBox);
                    myNewGrid.Name = myNewOpenObj.Name;
                    myNewGrid.Destination = myNewOpenObj.Destionation;
                    myNewGrid.ListOfComponents = myNewOpenObj.listCompDrawn;

                    returnedName = myNewGrid.Name;

                    this.grid = myNewGrid;

                    this.grid.PaintAllComponents();

                    //save state
                  //  CreateChange("Newly opened grid.");
                    //end

                    success = true;
                    Array.ForEach(Directory.GetFiles("../../Changes"), File.Delete);
                    changes.Clear();
                    gridChangedListener.GridChanged();
                    counterChange = 0;
                }

                catch (Exception e)
                {
                    MessageBox.Show("Somethign went wrong while opening!");
                    MessageBox.Show(e.Message);
                    success = false;
                }
                finally
                {
                    if (myFileStream != null)
                    {

                        myFileStream.Close();

                    }
                }
            }

            return success;
        }
        /// <summary>
        /// Goes back to a state before a change is made.
        /// </summary>
        /// <returns>True if successfull, false otherwise.</returns>
        public virtual bool UndoLastChange(PictureBox givenPictureBox,string givenDescription)
        {

            bool success = false;
           
                if (this.grid != null)
                {
                    ClearGrid(false);
                    CloseGrid(false);
                }

                FileStream myFileStream = null;
                BinaryFormatter myBinaryFormatter = null;
                try
                {
                    myFileStream = new FileStream("../../Changes/"+givenDescription, FileMode.Open, FileAccess.Read);
                    myBinaryFormatter = new BinaryFormatter();

                    SerializationObject myNewOpenObj = (SerializationObject)myBinaryFormatter.Deserialize(myFileStream);
                    Grid myNewGrid = new Grid(givenPictureBox);
                    myNewGrid.Name = myNewOpenObj.Name;
                    myNewGrid.Destination = myNewOpenObj.Destionation;
                    myNewGrid.ListOfComponents = myNewOpenObj.listCompDrawn;
                
                    this.grid = myNewGrid;

                    this.grid.PaintAllComponents();

                    success = true;
                }

                catch (Exception e)
                {
                MessageBox.Show(e.Message);
                    
                    success = false;
                }
                finally
                {
                    if (myFileStream != null)
                    {

                        myFileStream.Close();

                    }
                }
            

            return success;
            
         
        }
        /// <summary>
        /// Always the user makes a change, a new instance of "Change" class is created.
        /// </summary>
        /// <param name="givenDescription"></param>
        /// <returns>True if successfull, false otherwise.</returns>
        /// 

      
            
        public virtual bool CreateChange(string givenDescription)
        {
            bool success = false;
            FileStream myFileStream = null;
            BinaryFormatter myBinaryFormatter = null;

            try
            {
                //save state
                //if(counterChange==10)
                //{
                //    Array.ForEach(Directory.GetFiles("../../Changes"), File.Delete);
                //    counterChange = 0;
                //    gridChangedListener.GridChanged();
                //}
                myFileStream = new FileStream("../../Changes/"+counterChange + " - " + givenDescription, FileMode.Create, FileAccess.Write);
               
               
               

                myBinaryFormatter = new BinaryFormatter();

                SerializationObject newObject = new SerializationObject(grid.Name, grid.ListOfComponents, grid.Destination);
                myBinaryFormatter.Serialize(myFileStream, newObject);

                Change myNewChange = new Change(counterChange + " - " + givenDescription);
                changes.Add(myNewChange);
                changeListener.ChangeOccured(myNewChange);
                counterChange++;
                success = true;

                //end
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                success = false;
            }
            finally
           {

                if (myFileStream != null)
                {

                    myFileStream.Close();

                }
            }

            return success;
        }

       

        public bool CloseGrid(bool outside)
        {
            try
            {

                if(outside)
                {
                    this.grid = null;
                     Array.ForEach(Directory.GetFiles("../../Changes"), File.Delete);
                    changes.Clear();
                      gridChangedListener.GridChanged();
                     counterChange = 0;
                    return true;
                }
                else
                {
                    this.grid = null;
                   
                    return true;
                }
               
            }
            catch
            {
                return false;
            }
        }

    }
}

