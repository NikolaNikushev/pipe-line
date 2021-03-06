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
	private List<ToolboxComponent> listOfToolboxItems; 

	private Grid grid;

	private List<Change> changes;

	public virtual Grid Grid
	{
		get;
		set;
	}

	public virtual IEnumerable<DialogWindow> DialogWindow
	{
		get;
		set;
	}

	public virtual IEnumerable<ToolboxComponent> ToolboxComponent
	{
		get;
		set;
	}

	public virtual IEnumerable<Change> Change
	{
		get;
		set;
	}

    /// <summary>
    /// Checks if a particular area is free.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns>True if it is, false otherwise.</returns>
	public virtual bool CheckFreeSpot(int x, int y)
	{
		throw new System.NotImplementedException();
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

    /// <summary>
    /// Creates a new instance of class "ComponentDrawn". 
    /// </summary>
    /// <param name="cName">component name</param>
    /// <param name="cTop">component top coordinate</param>
    /// <param name="cBottom">component bottom coordinate</param>
    /// <param name="cCapacity">component capacity</param>
    /// <returns>True if successfully created, false otherwise.</returns>
	public virtual bool CreateComponentDrawn(string cName, ConnectionPoint cTop, ConnectionPoint cBottom, int cCapacity)
	{
		throw new System.NotImplementedException();
	}

    /// <summary>
    /// Deletes a given "ComponentDrawn".
    /// </summary>
    /// <param name="givenComponent"></param>
    /// <returns>True if successfull, false otherwise.</returns>
	public virtual bool DeleteComponent(ComponentDrawn givenComponent)
	{
		throw new System.NotImplementedException();
	}
    /// <summary>
    /// A "ComponentDrawn" is passed and the particular componentDrawn's properties should be changed.
    /// </summary>
    /// <param name="givenComponent"></param>
    /// <returns>True if successfull, false otherwise.</returns>
	public virtual bool EditComponentDrawn(ComponentDrawn givenComponent)
	{
		throw new System.NotImplementedException();
	}
    /// <summary>
    /// Deletes all "ComponentDrawn"-s from the grid.
    /// </summary>
    /// <param name="givenGrid"></param>
    /// <returns>True for successfull, false otherwise.</returns>
	public virtual bool ClearGrid(Grid givenGrid)
	{
		throw new System.NotImplementedException();
	}

    /// <summary>
    /// Saves the current grid as a file.
    /// </summary>
    /// <param name="givenGrid"></param>
    /// <returns>True if successfull, false otherwise.</returns>
	public virtual bool SaveGrid(Grid givenGrid)
	{
		throw new System.NotImplementedException();
	}
    /// <summary>
    /// Creates a new grid.
    /// </summary>
    /// <returns>True if successfull, false otherwise.</returns>
	public virtual bool NewFile()
	{
		throw new System.NotImplementedException();
	}

    /// <summary>
    /// Opens already created and saved grid.
    /// </summary>
    /// <returns>True if successfull, false otherwise.</returns>
	public virtual bool OpenFile()
	{
		throw new System.NotImplementedException();
	}
    /// <summary>
    /// Goes back to a state before a change is made.
    /// </summary>
    /// <returns>True if successfull, false otherwise.</returns>
	public virtual bool UndoLastChange()
	{
		throw new System.NotImplementedException();
	}
    /// <summary>
    /// Always the user makes a change, a new instance of "Change" class is created.
    /// </summary>
    /// <param name="givenDescription"></param>
    /// <returns>True if successfull, false otherwise.</returns>
	public virtual bool CreateChange(string givenDescription)
	{
		throw new System.NotImplementedException();
	}

	

}

