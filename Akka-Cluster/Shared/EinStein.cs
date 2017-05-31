using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class EinStein : UntypedActor
    {
        public EinStein()
        {
            //Receive<string>(_ => Console.WriteLine("E=MC^2"));
        }

        protected override void OnReceive(object message)
        {
            Console.WriteLine($"E=MC^2 and {message}");
        }
    }
}
