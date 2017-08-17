using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Configuration;

namespace HyperionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = 
@"akka {
  actor {
    serializers {
      hyperion = ""Akka.Serialization.HyperionSerializer, Akka.Serialization.Hyperion""
    }
        serialization-bindings {
            ""System.Object"" = hyperion
        }
    }
}";

            using (var sys = ActorSystem.Create("test"))
            {

                var a = sys.ActorOf<TestActor>();
                a.Tell("Arjen");

                Console.WriteLine("started");
                Console.ReadLine();
            }
        }
    }

    public class TestActor : ReceiveActor
    {
        public TestActor()
        {
            Receive<string>(_ =>
            {
                Console.WriteLine($"Hello {_}");
            });
        }
    }
}
