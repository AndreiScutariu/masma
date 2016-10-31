using System.Collections.Generic;
using System.Windows.Forms;
using jade.core;
using jade.domain;
using jade.domain.FIPAAgentManagement;

namespace Masma.Lab3.Services
{
    //Contains methods for managing services
    public class ServiceLocator
    {
        //returns a list of agents which provide the service serviceName
        //myAgent is the searcher agent (the requester)
        //if no providers are found returns an empty list
        public static List<AID> FindService(string serviceName, Agent myAgent, int timeOut)
        {
            var providers = new List<AID>();
            var found = false;

            var t1 = PerformanceCounter.GetValue();
            while (!found)
            {
                if (PerformanceCounter.GetValue() - t1 > timeOut)
                    break;

                Application.DoEvents();

                var template = new DFAgentDescription();
                var sd = new ServiceDescription();
                sd.setType(serviceName);
                template.addServices(sd);

                var result = DFService.search(myAgent, template);
                if (result != null && result.Length > 0)
                {
                    for (var i = 0; i < result.Length; i++)
                    {
                        providers.Add(result[i].getName());
                        found = true;
                    }
                }
            }

            return providers;
        }


        //registers a service named serviceName
        //myAgent is the agent providing the service
        public static void RegisterService(string serviceName, Agent myAgent)
        {
            var dfd = new DFAgentDescription();
            dfd.setName(myAgent.getAID());
            var sd = new ServiceDescription();
            sd.setType(serviceName);
            sd.setName(serviceName);
            dfd.addServices(sd);
            DFService.register(myAgent, dfd);
        }


        //Deregisters the service(s) provided by myAgent
        public static void DeregisterService(Agent myAgent)
        {
            DFService.deregister(myAgent);
        }
    }
}