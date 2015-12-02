using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowly
{
    class Component:IDeletable,IEditable
    {
        Boolean IDeletable.Delete()
        {
            throw new NotImplementedException();
        }


        Boolean IEditable.Edit()
        {
            throw new NotImplementedException();
        }

    }
}
