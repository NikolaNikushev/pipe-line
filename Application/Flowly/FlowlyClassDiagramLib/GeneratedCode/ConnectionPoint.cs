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

/// <summary>
/// "ConnectionPoint" is the place where each "Component" is connected with another one.
/// </summary>
public class ConnectionPoint
{

    private Point coordinates;

    private float currentFlow;

    private bool isOutput;

    private ComponentDrawn componentDrawnBelong;

    private bool isAvailable;

    private Point coordinates1;

    /// <summary>
    /// Sets availability of a "ConnectionPoint".
    /// </summary>
    /// <param name="givenAvailable"></param>
    /// <returns>True if successfull, false otherwise</returns>
	public virtual bool SetAvailable(bool givenAvailable)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Sets the current flow going through the "ConnectionPoint". Current flow means the amount of gas
    /// or liquid going through at the moment.
    /// </summary>
    /// <param name="givenFlow"></param>
    /// <returns>True if successfull, false otherwise</returns>
	public virtual bool SetCurrentFlow(float givenFlow)
    {
        throw new System.NotImplementedException();
    }

}

