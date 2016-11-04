using jade.core;
using Masma.Builder;
using AgentContainer = jade.wrapper.AgentContainer;

namespace Masma.Lab4.Startup
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var mc = CreateAgentContainer();
            mc.start();

            var agentBuilder = new AgentBuilder(mc);


        }

        private static AgentContainer CreateAgentContainer()
        {
            var p = new ProfileImpl();
            var rt = Runtime.instance();
            return rt.createMainContainer(p);
        }
    }
}