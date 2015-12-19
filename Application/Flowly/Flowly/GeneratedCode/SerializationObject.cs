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
        public int Id
        {
            get;
          private  set;
        }
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

      

        public SerializationObject(int theId, string theName, List<ComponentDrawn> theListCompDrawn)
        {
            Id = theId;
            Name = theName;
            listCompDrawn = theListCompDrawn;
          
        }
    }
}
