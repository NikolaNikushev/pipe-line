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
    /// <summary>
    /// Sub class of the "ComponentDrawn" class. A particular component called - Splitter. 
    /// SPECIFICATION: IF NORMAL SPLITTER THEN setCurrFlowPossible attribute needs to be false. IF ADJUSTABLE SPLITTER THEN setCurrFlowPossible
    /// needs to be true. Because through the two outputs of the adjustable splitter different amounts of liquid/gas can go through.
    /// </summary>
    public class Splitter : ComponentDrawn
    {
        protected Rectangle rectangleCombLeft;

        protected Rectangle rectangleSmallRightUp;

        protected Rectangle rectangleSmallRightDown;

        public Splitter(Rectangle theRectangle,bool theDiffCurrFlowPossible) : base(theRectangle)
        {


            
            rectangleSmallRightUp = new Rectangle();
            rectangleSmallRightUp.X = rectangleBig.X + rectangleBig.Width / 2;
            rectangleSmallRightUp.Y = rectangleBig.Y;
            rectangleSmallRightUp.Height = rectangleBig.Height / 2;
            rectangleSmallRightUp.Width = rectangleBig.Width / 2;


            rectangleSmallRightDown = new Rectangle();
            rectangleSmallRightDown.X = rectangleBig.X + rectangleBig.Width / 2;
            rectangleSmallRightDown.Y = rectangleBig.Y + rectangleBig.Height / 2;
            rectangleSmallRightDown.Height = rectangleBig.Height / 2;
            rectangleSmallRightDown.Width = rectangleBig.Width / 2;


            rectangleCombLeft = new Rectangle();
            rectangleCombLeft.X = rectangleBig.X;
            rectangleCombLeft.Y = rectangleBig.Y;
            rectangleCombLeft.Height = rectangleBig.Height;
            rectangleCombLeft.Width = rectangleBig.Width / 2;

            
            diffCurrFlowPossible = theDiffCurrFlowPossible;
            if (diffCurrFlowPossible)
            {
                imageResource = Image.FromFile("images\\ad_splitter2.png");
            }
            else
            {
                imageResource = Image.FromFile("images\\splitter2.png");
            }
            CreateConnectionPoints();

        }

        public override bool CreateConnectionPoints()
        {
            try
            {
                ConnectionPoint connRighttUp = new ConnectionPoint(rectangleSmallRightUp, this, false);
                ConnectionPoint connRightDown = new ConnectionPoint(rectangleSmallRightDown, this, false);
                ConnectionPoint connLeftComb = new ConnectionPoint(rectangleCombLeft, this, true);

                listOfConnectionPoints.Add(connRighttUp);
                listOfConnectionPoints.Add(connRightDown);
                listOfConnectionPoints.Add(connLeftComb);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}