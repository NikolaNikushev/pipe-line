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
    /// Sub class of the "ComponentDrawn" class. A particular component called - Pump. Nothing specific in it. Set diffCurrFlowPossible 
    /// needs to be false.
    /// </summary>
    public class Pump : ComponentDrawn
    {
        public Pump(Rectangle theRectangle) : base(theRectangle)
        {
            imageResource = Image.FromFile("images\\start_point.png");
            CreateConnectionPoints();
            this.EditableProperties.Add(GeneratedCode.EditablePropertiesEnum.capacity);
            this.EditableProperties.Add(GeneratedCode.EditablePropertiesEnum.flow);
        }

        //overloading

        public Pump(Rectangle theRectangle, float theCapacity, float theFlow) : base(theRectangle)
        {
            imageResource = Image.FromFile("images\\start_point.png");
            CreateConnectionPoints();
            this.EditableProperties.Add(GeneratedCode.EditablePropertiesEnum.capacity);
            this.EditableProperties.Add(GeneratedCode.EditablePropertiesEnum.flow);

            SetCapacity(theCapacity);
            SetCurrentFlow(theFlow);
        }

        public override bool CreateConnectionPoints()
        {
            try
            {
                ConnectionPoint conn1 = new ConnectionPoint(rectangleBig, this, true);
                listOfConnectionPoints.Add(conn1);
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
