using OrderbookLib.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OrderbookLib.Communication
{
    public abstract class CmBase : AbstractCmEvent
    {
        private bool _isRunning;

        protected readonly IPAddress IPAddress;
        protected readonly int Port;

        public event Action<bool>? RunningStateChanged;
        public CmBase(IPAddress iPAddress, int port)
        {
            IPAddress = iPAddress;
            Port = port;
        }
        public bool IsRunning
        {
            get => _isRunning;
            set
            {
                if (_isRunning != value)
                {
                    _isRunning = value;
                    RunningStateChanged?.Invoke(_isRunning);
                }
            }
        }
    }
}
