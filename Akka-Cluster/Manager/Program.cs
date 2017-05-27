using Akka.Actor;
using Akka.Routing;
using Shared;
using System;
using System.Linq;

namespace Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("funnybusiness");
            var worker = system.ActorOf(Props.Create<Worker>().WithRouter(FromConfig.Instance), "drone");
            system.Scheduler.Advanced.ScheduleRepeatedly(TimeSpan.FromSeconds(1), TimeSpan.FromMilliseconds(500), () =>
            {
                if (worker.Ask<Routees>(new GetRoutees()).Result.Members.Any())
                {
                    Console.WriteLine("Sending Message!");
                    worker.Tell(new WorkMessage($"ping at {Guid.NewGuid()}"));
                }
            });
            system.WhenTerminated.Wait();

        }
    }
}
