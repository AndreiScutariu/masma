using System.Drawing;
using AgentServices;
using jade.core;
using jade.wrapper;
using AgentContainer = jade.wrapper.AgentContainer;

namespace Masma.Lab3.Demo
{
    public class MasInit
    {
        public static void DoInitialization()
        {
            var mc = CreateAgentContainer();
            mc.start();

            var ag1Form = new FormAgent();
            ag1Form.Location = new Point(50, 50);

            var ag2Form = new FormAgent();
            ag2Form.Location = new Point(500, 50);

            var requester =
                CreateAgent(mc, "Requester1", "Masma.Lab3.Demo.Requester", new object[] {ag1Form});

            var provider =
                CreateAgent(mc, "Provider1", "Masma.Lab3.Demo.Provider", new object[] {ag2Form});

            requester.start();
            provider.start();
        }

        private static AgentContainer CreateAgentContainer()
        {
            var p = new ProfileImpl();
            var rt = Runtime.instance();
            return rt.createMainContainer(p);
        }

        private static AgentContainer CreateContainer(string containerName, bool isMainContainer, string hostAddress,
            string hostPort, string localPort)
        {
            var p = new ProfileImpl();

            if (containerName != string.Empty)
                p.setParameter(Profile.CONTAINER_NAME, containerName);

            p.setParameter(Profile.MAIN, isMainContainer.ToString());

            if (localPort != null)
                p.setParameter(Profile.LOCAL_PORT, localPort);

            if (hostAddress != string.Empty)
                p.setParameter(Profile.MAIN_HOST, hostAddress);

            if (hostPort != string.Empty)
                p.setParameter(Profile.MAIN_PORT, hostPort);

            if (isMainContainer)
            {
                return Runtime.instance().createMainContainer(p);
            }
            return Runtime.instance().createAgentContainer(p);
        }

        private static AgentController CreateAgent(AgentContainer container, string agentName, string agentClass,
            object[] args)
        {
            return container.createNewAgent(agentName, agentClass, args);
        }
    }
}