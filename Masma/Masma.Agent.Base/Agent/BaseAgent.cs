using System;
using Masma.Common.Interfaces;

namespace Masma.Common.Agent
{
    public class BaseAgent : jade.core.Agent
    {
        public override void setup()
        {
            logMyDetails();

            var arguments = getArguments();

            foreach (var argument in arguments)
            {
                var type = (Type) argument;
                jade.core.behaviours.Behaviour instance;

                if (typeof(INeedSpecifcAgent).IsAssignableFrom(type))
                {
                    instance = Activator.CreateInstance(type, this) as jade.core.behaviours.Behaviour;
                }
                else
                {
                    instance = Activator.CreateInstance(type) as jade.core.behaviours.Behaviour;
                }

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