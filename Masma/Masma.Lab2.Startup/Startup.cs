using jade.core;
using Masma.Builder;
using Masma.Common.Agent;
using Masma.Common.Behaviour;
using Masma.Messages;
using AgentContainer = jade.wrapper.AgentContainer;

namespace Masma.Lab2.Startup
{
    internal class Startup
    {
        private static void Main()
        {
            var mc = CreateAgentContainer();
            mc.start();

            var agentBuilder = new AgentBuilder(mc);

            var agent1 = agentBuilder.Create<AgentForRecieveMessage>("Agent_1")
                .WithBehaivour<ReceiveAndHandleMessageBehaviour>()
                .WithBehaivour<SendMessageToRandomAgentBehaviour>()
                .Build();

            var agent2 = agentBuilder.Create<AgentForRecieveMessage>("Agent_2")
                .WithBehaivour<ReceiveAndHandleMessageBehaviour>()
                .WithBehaivour<SendMessageToRandomAgentBehaviour>()
                .Build();

            var agent3 = agentBuilder.Create<AgentForRecieveMessage>("Agent_3")
                .WithBehaivour<ReceiveAndHandleMessageBehaviour>()
                .WithBehaivour<SendMessageToRandomAgentBehaviour>()
                .Build();

            var agent4 = agentBuilder.Create<AgentForRecieveMessage>("Agent_4")
                .WithBehaivour<ReceiveAndHandleMessageBehaviour>()
                .WithBehaivour<SendMessageToRandomAgentBehaviour>()
                .Build();

            agent1.start();
            agent2.start();
            agent3.start();
            agent4.start();
        }

        private static AgentContainer CreateAgentContainer()
        {
            var p = new ProfileImpl();
            var rt = Runtime.instance();
            return rt.createMainContainer(p);
        }
    }
}