using Akka.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class CleverMessage : IConsistentHashable
    {
        public CleverMessage(string message)
        {
            Message = message;
        }
        public object ConsistentHashKey => Message;

        public string Message { get; private set; }
    }
}
