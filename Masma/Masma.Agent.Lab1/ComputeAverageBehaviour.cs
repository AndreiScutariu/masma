using System;
using jade.core.behaviours;

namespace Masma.Agent.Lab1
{
    public class ComputeAverageBehaviour : Behaviour
    {
        private double _average;
        private int _counter;

        private int _sum;

        public override void action()
        {
            _counter++;
            _sum += new Random().Next(1, 10);
            _average = (double) _sum/_counter;

            if (_counter%100 == 0)
            {
                Console.WriteLine("Agent {0} processed {1} and obtained the partial result {2}.", myAgent.getLocalName(),
                    _counter, _average);
            }
        }

        public override bool done()
        {
            return _counter == 10000;
        }
    }
}