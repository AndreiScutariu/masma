using System;
using jade.core.behaviours;
using java.lang;

namespace Masma.Agent.Lab1
{
    public class CounterBehaviour : Behaviour
    {
        private int _counter;

        public override void action()
        {
            Console.WriteLine("Agent {0} counted until {1}", myAgent.getLocalName(), ++_counter);
            Thread.sleep(new Random().Next(500, 5000));
        }

        public override bool done()
        {
            return _counter == 100;
        }
    }
}