using System;
using System.Threading;
using jade.core;

namespace Masma.Lab4.Demo
{
    public class CloningAgent : Agent
    {
        public override void setup()
        {
            Console.WriteLine("Agent {0} started...", getAID().getName());

            Thread.Sleep(1000);

            doClone(new ContainerID("Container1", null), "MobileAgent_Clone");
        }

        public override void beforeClone()
        {
            Console.WriteLine("Cloning agent {0}...", getAID().getName());
        }

        public override void afterClone()
        {
            Console.WriteLine("Clone {0} ready...", getAID().getName());
        }
    }
}