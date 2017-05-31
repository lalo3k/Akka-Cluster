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
            var smartWorker = system.ActorOf(Props.Empty.WithRouter(FromConfig.Instance), "albert");
            var ran = new Random();
            system.Scheduler.Advanced.ScheduleRepeatedly(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2), () =>
            {
                if (worker.Ask<Routees>(new GetRoutees()).Result.Members.Any())
                {
                    worker.Tell(new CalculateAmicableNumbers(ran.Next(1, 200000)));
                }

                smartWorker.Ask<Routees>(new GetRoutees()).ContinueWith(result =>
                {
                    if (result.Result.Members.Any())
                    {
                        smartWorker.Tell(new CleverMessage("Hello"));
                    }
                });
                
            });
            system.WhenTerminated.Wait();
        }
    }
}
