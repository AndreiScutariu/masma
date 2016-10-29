using System;
using jade.core.behaviours;

namespace Masma.Agent.Lab1
{
    public class ComputeSumBehaviour : Behaviour
    {
        private int _counter;

        private int _sum;

        public override void action()
        {
            _counter++;
            _sum += new Random().Next(1, 10);

            if (_counter%100 == 0)
            {
                Console.WriteLine("Agent {0} processed {1} and obtained the partial result {2}.", myAgent.getLocalName(),
                    _counter, _sum);
            }
        }

        public override bool done()
        {
            return _counter == 10000;
        }
    }
}