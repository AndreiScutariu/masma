using System;
using jade.core;

namespace Masma.Lab4.Demo
{
    public class MobileAgent : Agent
    {
        public override void setup()
        {
            Console.WriteLine("Agent {0} started...", getAID().getName());

            doMove(new ContainerID("Container1", null));
        }

        public override void beforeMove()
        {
            Console.WriteLine("Agent {0} began moving...", getAID().getName());
        }

        public override void afterMove()
        {
            Console.WriteLine("Agent {0} finished moving...", getAID().getName());
        }
    }
}