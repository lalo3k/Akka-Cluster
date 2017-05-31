using Akka.Actor;
using Akka.Routing;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverWorker
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("funnybusiness");
            var worker = system.ActorOf(Props.Create<EinStein>().WithRouter(FromConfig.Instance), "cleverdrone");
            system.WhenTerminated.Wait();
        }
    }
}
