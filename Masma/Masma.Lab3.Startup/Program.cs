using System.Threading;
using jade.core;
using Masma.Builder;
using Masma.Lab3.Behaviours;
using AgentContainer = jade.wrapper.AgentContainer;

namespace Masma.Lab3.Startup
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var mc = CreateAgentContainer();
            mc.start();

            var agentBuilder = new AgentBuilder(mc);

            var provider = agentBuilder.Create<AgentWithForm>("Provider_1")
                .WithBehaivour<WinFormRefreshBehaviour<AgentWithForm>>()
                .WithBehaivour<ProviderHandleRequestsBehaviour>()
                .Build();
            provider.start();

            var provider2 = agentBuilder.Create<AgentWithForm>("Provider_2")
                .WithBehaivour<WinFormRefreshBehaviour<AgentWithForm>>()
                .WithBehaivour<ProviderHandleRequestsBehaviour>()
                .Build();
            provider2.start();

            var provider3 = agentBuilder.Create<AgentWithForm>("Provider_3")
                .WithBehaivour<WinFormRefreshBehaviour<AgentWithForm>>()
                .WithBehaivour<ProviderHandleRequestsBehaviour>()
                .Build();
            provider3.start();

            Thread.Sleep(1000);

            var consumer = agentBuilder
                .Create<AgentWithForm>("Consumer")
                .WithBehaivour<WinFormRefreshBehaviour<AgentWithForm>>()
                //.WithBehaivour<ConsumerSendSumRequestsBehaviour<AgentWithForm>>()
                .WithBehaivour<ConsumerSendCostOfProductRequestsBehaviour<AgentWithForm>>()
                .WithBehaivour<ConsumerHandleResponsesBehaviour>()
                .Build();
            consumer.start();
        }

        private static AgentContainer CreateAgentContainer()
        {
            var p = new ProfileImpl();
            var rt = Runtime.instance();
            return rt.createMainContainer(p);
        }
    }
}