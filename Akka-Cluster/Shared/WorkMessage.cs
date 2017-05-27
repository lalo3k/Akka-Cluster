using System;

namespace Shared
{
    public class WorkMessage
    {
        public WorkMessage(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }

        public override string ToString()
        {
            return Message;
        }
    }
}
