using System;
using jade.core.behaviours;

namespace Masma.Agent.Base
{
    public class BaseAgent : jade.core.Agent
    {
        public override void setup()
        {
            logMyDetails();

            var arguments = getArguments();

            foreach (var argument in arguments)
            {
                var instance = Activator.CreateInstance((Type) argument) as Behaviour;
                addBehaviour(instance);
            }
        }

        protected void logMyDetails()
        {
            Console.WriteLine("I'm " + getLocalName() + " and I'm living in " +
                              getContainerController().getContainerName() + "\n");
        }

        public override void takeDown()
        {
            Console.WriteLine("Agent " + getContainerController().getContainerName() + " is being removed ... \n");
        }
    }
}