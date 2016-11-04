using jade.core;
using Masma.Builder;
using Masma.Common.Agent;
using Masma.Lab1.Behaviours;
using AgentContainer = jade.wrapper.AgentContainer;

namespace Masma.Lab1.Startup
{
    internal static class Startup
    {
        private static void Main()
        {
            var mc = CreateAgentContainer();
            mc.start();

            var agentBuilder = new AgentBuilder(mc);

            //var agent1 = agentBuilder.Create<BaseAgent>("BaseAgent_1").WithBehaivour<CounterBehaviour>().Build();
            //agent1.start();

            //var agent2 = agentBuilder.Create<BaseAgent>("BaseAgent_2").WithBehaivour<CounterBehaviour>().Build();
            //agent2.start();

            //var agent3 = agentBuilder.Create<BaseAgent>("BaseAgent_3").WithBehaivour<CounterBehaviour>().Build();
            //agent3.start();

            //var agent4 = agentBuilder.Create<BaseAgent>("BaseAgent_4").WithBehaivour<CounterBehaviour>().Build();
            //agent4.start();

            var sumAgent = agentBuilder.Create<BaseAgent>("Sum Agent").WithBehaivour<ComputeSumBehaviour>().Build();
            sumAgent.start();

            var avgAgent = agentBuilder.Create<BaseAgent>("Avg Agent").WithBehaivour<ComputeAverageBehaviour>().Build();
            avgAgent.start();
        }

        private static AgentContainer CreateAgentContainer()
        {
            var p = new ProfileImpl();
            var rt = Runtime.instance();
            return rt.createMainContainer(p);
        }
    }
}