using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Flowly.GeneratedCode
{
    [Serializable]
    class SerializationObject
    {
       
        public string Name
        {
            get;
           private set;
        }
        public List<ComponentDrawn> listCompDrawn
        {
            get;
           private set;

        }
         public string Destionation
        {
            get;
            private set;
        }
      

        public SerializationObject(string theName, List<ComponentDrawn> theListCompDrawn, string theDestination)
        {
            
            Name = theName;
            listCompDrawn = theListCompDrawn;
            Destionation = theDestination;
          
        }
    }
}
