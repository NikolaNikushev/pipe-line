using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowly
{
    public interface IChangeOccured
    {
        void ChangeOccured(Change theChange);
    }
}
