using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Worker : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            Console.WriteLine($"This is my work... {message}");
        }
    }
}
