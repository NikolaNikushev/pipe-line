﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Flowly
{

    /// <summary>
    /// Objects of this class will be the "drawing" place of the user. A grid will contain components in it.
    /// </summary>
    public class Grid
    {
        private const int PIPE_SIZE = 5;


        private List<ComponentDrawn> listOfComponents;



        private Graphics graphic;



        private string name;

        private string destination;

        private PictureBox grid;


        public String Destination
        {
            get
            {
                return destination;
            }
            set
            {
                destination = value;
            }
        }

        object b = new object();

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public List<ComponentDrawn> ListOfComponents
        {
            get
            {

                return listOfComponents;
            }
            set
            {
                listOfComponents = value;
            }
        }



        public Grid(PictureBox grid)
        {
            ListOfComponents = new List<Flowly.ComponentDrawn>();
            Graphic = grid.CreateGraphics();
            this.grid = grid;

        }



        public Graphics Graphic
        {
            get
            {
                return graphic;
            }
            set
            {
                graphic = value;
            }
        }

        internal bool CheckComponentIntersectsWithPipe(Rectangle r)
        {
            foreach (ComponentDrawn p in ListOfComponents)
            {
                if (!(p is Pipe)) continue;
                bool intersects = CheckInteresectsWithPipe(r, p as Pipe);
                if (intersects)
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Adds a component to the listOfComponents list.
        /// </summary>
        /// <param name="givenComponent"></param>
        /// <returns>True if successfull, false otherwise</returns>
        public virtual bool AddComponentDrawnToGridList(ComponentDrawn givenComponent)
        {
            try
            {
                this.ListOfComponents.Add(givenComponent);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("There are a problem adding the component to the grid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        internal ConnectionPoint IsInputOutput(Point newPoint)
        {
            foreach (ComponentDrawn item in ListOfComponents)
            {
                Rectangle componentRect = item.RectangleBig;
                Rectangle pointRect = new Rectangle(newPoint, new Size(1, 1));
                if (componentRect.IntersectsWith(pointRect))
                {
                    List<ConnectionPoint> conPoints = item.GiveMeYourConnectionPoints();
                    foreach (ConnectionPoint cp in conPoints)
                    {
                        if (pointRect.IntersectsWith(cp.rectangle))
                        {

                            if (cp.Available)
                            {
                                return cp;
                            }

                        }
                    }
                }
            }

            return null;
        }

        internal ComponentDrawn GetComponentAt(Point pointLocation)
        {
            Rectangle pointRect = new Rectangle(pointLocation, new Size(5, 5));
            foreach (ComponentDrawn item in ListOfComponents)
            {
                Rectangle componentRect = item.RectangleBig;
                if (item is Pipe)
                {
                    Pipe pipe = item as Pipe;
                    if (CheckInteresectsWithPipe(pointRect, pipe)) return pipe;
                }

                if (componentRect.IntersectsWith(pointRect))
                {
                    return item;
                }
            }

            return null;
        }

        /// <summary>
        /// Opposite of the other method.
        /// </summary>
        /// <param name="givenComponent"></param>
        /// <returns>True if successfull, false otherwise.</returns>
        public virtual bool RemoveComponentDrawnFromGridList(ComponentDrawn givenComponent)
        {
            //try
            //  {
            foreach (ComponentDrawn cd in this.ListOfComponents)
            {
                cd.FlowWasUpdated = false;
            }
            foreach (ConnectionPoint cp in givenComponent.GiveMeYourConnectionPoints())
            {
                if (cp.PipeConnection != null)
                {
                    RemovePipe(cp.PipeConnection);
                }
            }

            this.ListOfComponents.Remove(givenComponent);
            PaintAllComponents();
            return true;
            //  }
            //catch (Exception e)
            //{
            //    MessageBox.Show("There are a problem removing the component to the grid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
        }

        internal void RemovePipe(Pipe pipe)
        {

            foreach (ConnectionPoint CP in pipe.GiveMeYourConnectionPoints())
            {
                if (!CP.IsOutput)
                {
                    Queue<ComponentDrawn> elements = new Queue<ComponentDrawn>();
                   
                    ComponentDrawn drawnComponent = CP.ComponentDrawnBelong;
                     CP.PipeConnection.GetEndConnectionPoint().SetCurrentFlow(drawnComponent.CurrentFlow - CP.CurrentFlow);
                    elements.Enqueue(drawnComponent);
                    
                    while (elements.Count > 0)
                    {
                        drawnComponent = elements.Dequeue();
                        
                        drawnComponent.UpdateComponentFlow();
                        drawnComponent.FlowWasUpdated = true;
                        List<ConnectionPoint> lcp = drawnComponent.GiveMeYourOutputConnectionPoints();
                        
                        foreach (ConnectionPoint output in lcp)
                        {
                           
                            if(output.PipeConnection != null)
                            {
                                if (!output.PipeConnection.GetEndConnectionPoint().ComponentDrawnBelong.FlowWasUpdated)
                                {
                                    output.PipeConnection.GetEndConnectionPoint().SetCurrentFlow(drawnComponent.CurrentFlow - CP.CurrentFlow);
                                    
                                    elements.Enqueue(output.PipeConnection.GetEndConnectionPoint().ComponentDrawnBelong);
                                }
                            }
                        }
                    }

                }
                CP.PipeConnection = null;
            }
            ListOfComponents.Remove(pipe);


        }

        internal void AddPipe(Pipe pipe)
        {
            this.ListOfComponents.Add(pipe);


        }

        public static bool CheckPipeIntersects(Point a1, Point a2, Point b1, Point b2)
        {
            Point b = new Point(a2.X - a1.X, a2.Y - a1.Y);
            Point d = new Point(b2.X - b1.X, b2.Y - b1.Y);
            float bDotDPerp = b.X * d.Y - b.Y * d.X;

            // if b dot d == 0, it means the lines are parallel so have infinite intersection points
            if (bDotDPerp == 0)
                return false;

            Point c = new Point(b1.X - a1.X, b1.Y - a1.Y);
            float t = (c.X * d.Y - c.Y * d.X) / bDotDPerp;
            if (t < 0 || t > 1)
                return false;

            float u = (c.X * b.Y - c.Y * b.X) / bDotDPerp;
            if (u < 0 || u > 1)
                return false;

            //intersection = new Point((int)(a1.X + t  b.X), (int)(a1.Y + t  b.Y));

            return true;
        }

        internal void DrawPipelineAndUpdateFLow(Pipe pipe)
        {
            //Todo Check if it is a connection between elements that are not end or start 
            ConnectionPoint startPoint = pipe.GetStartConnectionPoint();
            if (startPoint == null)
            {
                MessageBox.Show("What did you do? grid-drawpipeline");
                return;
            }
            ConnectionPoint endPoint = pipe.GetEndConnectionPoint();
            if (endPoint == null)
            {
                MessageBox.Show("You are drawing the pipe too soon, you need to have an endpoint!");
                return;
            }
            Pen colorOfPen = new Pen(Color.Gray, PIPE_SIZE);

            endPoint.SetCurrentFlow(startPoint.CurrentFlow);
            // endPoint.SetCurrentFlow(startPoint.CurrentFlow - (startPoint.CurrentFlow - endPoint.CurrentCapacity));
            endPoint.ComponentDrawnBelong.UpdateComponentFlow();


            if (((startPoint.CurrentFlow > endPoint.ComponentDrawnBelong.Capacity) && (startPoint.CurrentFlow - endPoint.ComponentDrawnBelong.Capacity >= 0.1F)) && endPoint.ComponentDrawnBelong is Sink)
            {
                colorOfPen.Color = Color.Red;
            }
            for (int i = 0; i < pipe.PipePoints.Count - 1; i++)
            {
                Point start = pipe.PipePoints[i];
                Point end = pipe.PipePoints[i + 1];
                graphic.DrawLine(colorOfPen, start, end);
            }


            //int index = listOfComponents.IndexOf(endPoint.ComponentDrawnBelong);
            //ListOfComponents.Insert(index, endPoint.ComponentDrawnBelong);
            //ListOfComponents.RemoveAt(index+1);

            //Paint(endPoint.ComponentDrawnBelong);
            // PaintAllComponents();



        }

        private bool CheckIntersectAllOther(Point start, Point end, Pipe currentPipe)
        {

            if (CheckInteresectsWithSelf(start, end, currentPipe))
            {
                return false;
            }
            int listOfComponentsCount = listOfComponents.Count;
            for (int i = 0; i < listOfComponentsCount; i++)
            {
                ComponentDrawn d = listOfComponents[i];

                if (d is Pipe)
                {
                    if (CheckInteresectsWithPipe(start, end, currentPipe, d as Pipe))
                    {
                        return true;
                    }
                }
            }
            bool isColliding = false;
            for (int i = 0; i < listOfComponentsCount; i++)
            {
                ComponentDrawn d = listOfComponents[i];
                if (d != currentPipe.GiveMeYourConnectionPoints().Last().ComponentDrawnBelong)

                    if (CheckInteresectsWithComponentDrawn(start, end, currentPipe, d))
                    {
                        if (d.RectangleBig.Contains(start))
                        {
                            continue;
                        }
                        MessageBox.Show("Intersects component");
                        return true;

                    }
            }
            return false;
        }


        private bool CheckInteresectsWithSelf(Point start, Point end, Pipe currentPipe)
        {
            int listOfComponentsCount = listOfComponents.Count;
            int currentPipeLines = currentPipe.PipePoints.Count;
            for (int i = 0; i < currentPipeLines - 1; i++)
            {
                Point other1 = currentPipe.PipePoints[i];
                Point other2 = currentPipe.PipePoints[i + 1];
                if (start != other1 && start != other2)
                {
                    if (CheckPipeIntersects(start, end, currentPipe.PipePoints[i], currentPipe.PipePoints[i + 1]))
                    {
                        MessageBox.Show("Intersects with itself");

                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckInteresectsWithPipe(Point start, Point end, Pipe currentPipe, Pipe pipe)
        {

            int pipeLinesCount = pipe.PipePoints.Count;
            List<Point> pLines = pipe.PipePoints;

            for (int j = 0; j < pipeLinesCount - 1; j++)
            {
                if (CheckPipeIntersects(start, end, pLines[j], pLines[j + 1]))
                {
                    MessageBox.Show("Intersects another line");
                    return true;
                }
            }
            return false;
        }

        private bool CheckInteresectsWithPipe(Rectangle r, Pipe pipe)
        {

            int pipeLinesCount = pipe.PipePoints.Count;
            List<Point> pLines = pipe.PipePoints;
            Point topLeft = r.Location;
            Point topRight = new Point(r.X + r.Width, r.Y);
            Point bottomRight = new Point(r.X + r.Width, r.Y + r.Height);
            Point bottomLeft = new Point(r.X, r.Y + r.Height);
            for (int j = 0; j < pipeLinesCount - 1; j++)
            {
                if (CheckPipeIntersects(topLeft, topRight, pLines[j], pLines[j + 1]))
                {
                    // MessageBox.Show("Intersects pipe");
                    return true;
                }
                if (CheckPipeIntersects(topRight, bottomRight, pLines[j], pLines[j + 1]))
                {
                    // MessageBox.Show("Intersects pipe");
                    return true;
                }
                if (CheckPipeIntersects(bottomRight, bottomLeft, pLines[j], pLines[j + 1]))
                {
                    // MessageBox.Show("Intersects pipe");
                    return true;
                }
                if (CheckPipeIntersects(topLeft, bottomLeft, pLines[j], pLines[j + 1]))
                {
                    //MessageBox.Show("Intersects pipe");
                    return true;
                }
            }

            return false;
        }

        private bool CheckInteresectsWithComponentDrawn(Point start, Point end, Pipe currentPipe, ComponentDrawn d)
        {
            Rectangle dRect = d.RectangleBig;

            Point p = new Point(dRect.X, dRect.Y);
            Point p2 = new Point(dRect.X + dRect.Width, dRect.Y);
            if (CheckPipeIntersects(start, end, p, p2))
            {
                return true;
            }

            p = new Point(dRect.X + dRect.Width, dRect.Y);
            p2 = new Point(dRect.X + dRect.Width, dRect.Y + dRect.Height);
            if (CheckPipeIntersects(start, end, p, p2))
            {
                return true;
            }
            p = new Point(dRect.X, dRect.Y + dRect.Height);
            p2 = new Point(dRect.X + dRect.Width, dRect.Y + dRect.Height);
            if (CheckPipeIntersects(start, end, p, p2))
            {
                return true;
            }
            p = new Point(dRect.X, dRect.Y);
            p2 = new Point(dRect.X, dRect.Y + dRect.Height);
            if (CheckPipeIntersects(start, end, p, p2))
            {
                return true;
            }
            return false;
        }


        internal bool DrawPipeToPoint(Point start, Point end, ref Pipe curPipe)
        {
            Pipe currentPipe = curPipe;
            int pointsCount = currentPipe.GiveMeYourConnectionPoints().Count;
            if (currentPipe.GiveMeYourConnectionPoints().First().ComponentDrawnBelong == GetComponentAt(end))
            {
                return false;
            }

            if (pointsCount != 2)
            {


                if (CheckInteresectsWithSelf(start, end, currentPipe))
                {

                    return false;
                }
                int listOfComponentsCount = listOfComponents.Count;
                for (int i = 0; i < listOfComponentsCount; i++)
                {
                    ComponentDrawn d = listOfComponents[i];
                    if (currentPipe.PipePoints.Count <= 1)
                    {
                        if (d.GiveMeYourConnectionPoints().Where(x => x == currentPipe.GiveMeYourConnectionPoints().Last()).Any())
                            continue;
                    }



                    if (d is Pipe)
                    {
                        if (CheckInteresectsWithPipe(start, end, currentPipe, d as Pipe))
                        {

                            return false;
                        }

                    }
                    else
                    {
                        if (CheckInteresectsWithComponentDrawn(start, end, currentPipe, d))
                        {

                            if (d.RectangleBig.Contains(end))
                            {
                                ConnectionPoint cp = IsInputOutput(end);
                                if (cp != null)
                                {
                                    if (!cp.IsOutput)
                                    {
                                        cp.PipeConnection = currentPipe;
                                        currentPipe.SetConnection(cp);

                                        if (CheckIntersectAllOther(start, end, currentPipe))
                                        {

                                            cp.PipeConnection = null;
                                            currentPipe.RemoveConnection(cp);
                                            return false;
                                        }
                                        // Pen myPen2 = new Pen(Color.Gray, PIPE_SIZE);
                                        // graphic.DrawLine(myPen2, start, end);

                                        currentPipe.AddPointToList(end);
                                        curPipe = currentPipe;

                                        return true;
                                    }
                                    MessageBox.Show("Intersects component");
                                    return false;

                                }
                            }
                            MessageBox.Show("Intersects component");
                            return false;
                        }
                    }

                }

            }
            Pen myPen = new Pen(Color.Gray, PIPE_SIZE);
            graphic.DrawLine(myPen, start, end);

            currentPipe.AddPointToList(end);
            curPipe = currentPipe;
            return true;

        }

        private void DrawConnectionPointLimits(Brush color, ConnectionPoint cp)
        {
            //int width = cp.rectangle.Width;
            //int height = cp.rectangle.Height;
            //int x = cp.rectangle.X;
            //int y = cp.rectangle.Y;
            //Rectangle r = new Rectangle(new Point(x, y), new Size(width, 5));
            //graphic.FillRectangle(color, r);
            //r = new Rectangle(new Point(x + width, y), new Size(5, height + 5));
            //graphic.FillRectangle(color, r);
            //r = new Rectangle(new Point(x, y + height), new Size(width, 5));
            //graphic.FillRectangle(color, r);
            //r = new Rectangle(new Point(x, y), new Size(5, height));
            //graphic.FillRectangle(color, r);

            Pen myNewPen = new Pen(color, 2);
            graphic.DrawRectangle(myNewPen, cp.rectangle);


            //int width = cp.rectangle.Width / 2;
            //int height = cp.rectangle.Height / 2;
            //int x = cp.rectangle.X;
            //int y = cp.rectangle.Y;
            //Rectangle r = new Rectangle(new Point(x, y), new Size(width, 5));
            //graphic.FillRectangle(color, r);
            //r = new Rectangle(new Point(x + width, y), new Size(5, height + 5));
            //graphic.FillRectangle(color, r);
            ////r = new Rectangle(new Point(x, y + height), new Size(width, 5));
            ////graphic.FillRectangle(color, r);
            ////r = new Rectangle(new Point(x, y), new Size(5, height));
            ////graphic.FillRectangle(color, r);

            //if(cp.IsOutput)
            //{
            //    int width = cp.rectangle.Width / 2;
            //    int height = cp.rectangle.Height / 2;
            //    int x = cp.rectangle.X + width ;
            //    int y = cp.rectangle.Y;
            //    graphic.DrawRectangle(Pens.Black, x, y, width, height);

            //    //int width = cp.rectangle.Width ;
            //    //int height = cp.rectangle.Height;
            //    //int x = cp.rectangle.X;
            //    //int y = cp.rectangle.Y;
            //    //graphic.DrawRectangle(Pens.Black, x, y, width, height);

            //}
            //else
            //{
            //    int width = cp.rectangle.Width / 2;
            //    int height = cp.rectangle.Height / 2;
            //    int x = cp.rectangle.X;
            //    int y = cp.rectangle.Y + height / 2;
            //    graphic.DrawRectangle(Pens.Black, x, y, width, height);
            //}






        }

        private void HighlightPointsOfComponent(ComponentDrawn cd)
        {

        }

        internal void HighightAllAvailableInputs(ComponentDrawn currentComponent)
        {
            foreach (ComponentDrawn cd in ListOfComponents)
            {
                if (cd != null)
                {
                    foreach (ConnectionPoint cp in cd.GiveMeYourConnectionPoints())
                    {
                        if ((cp.Available && !cp.IsOutput) && currentComponent != cd)
                        {
                            DrawConnectionPointLimits(Brushes.Blue, cp);
                        }
                        else
                        {
                            DrawConnectionPointLimits(Brushes.Red, cp);
                        }
                    }
                }

            }
        }

        internal void HighightAllAvailableOutputs()
        {
            foreach (ComponentDrawn cd in ListOfComponents)
            {

                foreach (ConnectionPoint cp in cd.GiveMeYourConnectionPoints())

                    if ((cp.Available && cp.IsOutput))
                    {
                        DrawConnectionPointLimits(Brushes.Blue, cp);
                    }
                    else
                    {
                        DrawConnectionPointLimits(Brushes.Red, cp);
                    }

            }
        }



        public List<Rectangle> GetComponentsRectangles()
        {
            List<Rectangle> rect = new List<Rectangle>();
            foreach (ComponentDrawn component in this.ListOfComponents)
            {

                rect.Add(component.RectangleBig);
            }
            return rect;
        }

        public void PaintAllComponents()
        {
            graphic.Clear(Color.White);
            foreach (ComponentDrawn item in this.ListOfComponents)
            {
                Paint(item);
            }
        }

        public void Paint(ComponentDrawn drawn)
        {
            if (drawn is Pipe)
            {
                Pipe d = drawn as Pipe;
                DrawPipelineAndUpdateFLow(d);

                return;
            }
            Rectangle r = drawn.RectangleBig;
            //  graphic.DrawRectangle(Pens.Red, r);
            graphic.DrawImage(drawn.Image, r);
            graphic.DrawString("C: " + drawn.Capacity.ToString() + " / F: " + drawn.CurrentFlow.ToString(), SystemFonts.DefaultFont, Brushes.Black, r.X, r.Y - r.Width / 2);

        }

    }
}

