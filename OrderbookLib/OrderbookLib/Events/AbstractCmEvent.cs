using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderbookLib.Events
{
    public abstract class AbstractCmEvent
    {
        public abstract event EventHandler<CmEventArgs>? Connected;
        public abstract event EventHandler<CmEventArgs>? Disconnected;
        public abstract event EventHandler<CmEventArgs>? Received;
    }
}
