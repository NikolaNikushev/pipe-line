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
namespace Flowly
{
    /// <summary>
    /// Class "Change" is meant to be used for the changes that will be made during runtime. For each activity of the
    /// user new "Change" will be created. So the "Undo" option will be available to the user.
    /// </summary>
    public class Change
    {
        /// <summary>
        /// A string which contaions the description of a change.
        /// </summary>
        private string description;
        public string Desctiption
        {
            get
            {
                return description;
            }
        }
        public Change(string theDescription)
        {
            description = theDescription;
        }

    }
}
