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
    /// "ConnectionPoint" is the place where each "Component" is connected with another one.
    /// </summary>
    public class ConnectionPoint
    {
        public Rectangle rectangle;

        private float currentFlow; 

        private bool isOutput; 

        private ComponentDrawn componentDrawnBelong;

        private bool isAvailable;

        public bool Available { get { return isAvailable; }}

        public ConnectionPoint(Rectangle theRectangle, ComponentDrawn theComponentDrawnBelong,bool theIsOutput)
        {
            rectangle = theRectangle;
            SetCurrentFlow(0);
            isOutput = theIsOutput;
            componentDrawnBelong = theComponentDrawnBelong;
            SetAvailable(true);

        }

        /// <summary>
        /// Sets availability of a "ConnectionPoint".
        /// </summary>
        /// <param name="givenAvailable"></param>
        /// <returns>True if successfull, false otherwise</returns>
        public virtual bool SetAvailable(bool givenAvailable)
        {
            try
            {
                isAvailable = givenAvailable;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the current flow going through the "ConnectionPoint". Current flow means the amount of gas
        /// or liquid going through at the moment.
        /// </summary>
        /// <param name="givenFlow"></param>
        /// <returns>True if successfull, false otherwise</returns>
        public virtual bool SetCurrentFlow(float givenFlow)
        {
            try
            {
                currentFlow = givenFlow;
                return true;
            }
            catch
            {
                return false;
            }
        }

    }

}