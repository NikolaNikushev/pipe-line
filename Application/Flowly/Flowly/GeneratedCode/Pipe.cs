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
namespace Flowly
{
    [Serializable]
    /// <summary>
    /// Sub class of the "ComponentDrawn" class. A particular component called - Pipe. Nothing specific in it. Set diffCurrFlowPossible 
    /// needs to be false.
    /// </summary>
    public class Pipe : ComponentDrawn
    {
        protected Rectangle rectanglePipeLeft;

        protected Rectangle rectanglePipeRight;

        private List<Point> pipePoints;

        public List<Point> PipePoints
        {
            get { return pipePoints; }
            private set { pipePoints = value; }
        }



        public Pipe(Rectangle theRectangle) : base(theRectangle)
        {

           /* imageResource = Image.FromFile("images\\pump.png");
            rectanglePipeLeft = new Rectangle();
            rectanglePipeLeft.X = rectangleBig.X;
            rectanglePipeLeft.Y = rectangleBig.Y;
            rectanglePipeLeft.Height = rectangleBig.Height;
            rectanglePipeLeft.Width = rectangleBig.Width / 2;


            rectanglePipeRight = new Rectangle();
            rectanglePipeRight.X = rectangleBig.X + rectangleBig.Width / 2;
            rectanglePipeRight.Y = rectangleBig.Y;
            rectanglePipeRight.Height = rectangleBig.Height;
            rectanglePipeRight.Width = rectangleBig.Width / 2;

            CreateConnectionPoints();
            */

        }

        public Pipe() : base(new Rectangle())
        {
            this.listOfConnectionPoints = new List<ConnectionPoint>();
            this.pipePoints = new List<Point>();
        }


        public override bool CreateConnectionPoints()
        {
            try
            {
                ConnectionPoint connLeft = new ConnectionPoint(rectanglePipeLeft, this, false);
                ConnectionPoint connRight = new ConnectionPoint(rectanglePipeRight, this, true);
                

                listOfConnectionPoints.Add(connLeft);
                listOfConnectionPoints.Add(connRight);
               
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SetConnection(ConnectionPoint connection)
        {
            if (rectanglePipeRight == null)
            {
                rectanglePipeRight = connection.rectangle;
            }
            else
            {
                rectanglePipeLeft = connection.rectangle;
            }
            AddConnection(connection);
        }


        private void AddConnection(ConnectionPoint cp)
        {
            this.listOfConnectionPoints.Add(cp);
        }

        public void AddPointToList(Point p)
        {
            this.pipePoints.Add(p);
        }
    }

}