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
        private List<ComponentDrawn> listOfComponents;



        private Graphics graphic;

      

        private string name;

        private string destination;


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


        /// <summary>
        /// Adds a component to the listOfComponents list.
        /// </summary>
        /// <param name="givenComponent"></param>
        /// <returns>True if successfull, false otherwise</returns>
        public virtual bool AddComponentDrawnToGridList(ComponentDrawn givenComponent)
        {
            try
            {
                this.listOfComponents.Add(givenComponent);
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
            foreach (ComponentDrawn item in ListOfComponents)
            {
                Rectangle componentRect = item.RectangleBig;
                Rectangle pointRect = new Rectangle(pointLocation, new Size(1, 1));
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
            try
            {
                foreach (ConnectionPoint cp in givenComponent.GiveMeYourConnectionPoints())
                {
                    
                }
                this.listOfComponents.Remove(givenComponent);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("There are a problem removing the component to the grid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        internal void RemovePipe(Pipe pipe)
        {
            for (int i = 0; i < pipe.PipePoints.Count - 1; i++)
            {
                graphic.DrawLine(Pens.White, pipe.PipePoints[i], pipe.PipePoints[i + 1]);
            }
            foreach (ConnectionPoint CP in pipe.GiveMeYourConnectionPoints())
            {
                CP.PipeConnection = null;
            }


        }

        internal void AddPipe(Pipe pipe)
        {
            this.listOfComponents.Add(pipe);
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


        internal bool DrawPipeLine(Point start, Point end, ref Pipe curPipe)
        {
            Pipe currentPipe = curPipe;
            int pointsCount = currentPipe.GiveMeYourConnectionPoints().Count;
            if(currentPipe.GiveMeYourConnectionPoints().First().ComponentDrawnBelong == GetComponentAt(end))
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
                                        graphic.DrawLine(Pens.Black, start, end);

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
            graphic.DrawLine(Pens.Black, start, end);

            currentPipe.AddPointToList(end);
            curPipe = currentPipe;
            return true;

        }



        public List<Rectangle> GetComponentsRectangles()
        {
            List<Rectangle> rect = new List<Rectangle>();
            foreach (ComponentDrawn component in this.listOfComponents)
            {

                rect.Add(component.RectangleBig);
            }
            return rect;
        }

        public void PaintAllComponents()
        {
            foreach (ComponentDrawn item in this.listOfComponents)
            {
                Paint(item);
            }
        }

        public void Paint(ComponentDrawn drawn)
        {
            Rectangle r = drawn.RectangleBig;
            graphic.DrawRectangle(Pens.Red, r);
            graphic.DrawImage(drawn.Image, r);
            List<ConnectionPoint> conPoints = drawn.GiveMeYourConnectionPoints();
            foreach (ConnectionPoint cp in conPoints)
            {
                graphic.DrawRectangle(Pens.Blue, cp.rectangle);

            }
        }

    }
}

