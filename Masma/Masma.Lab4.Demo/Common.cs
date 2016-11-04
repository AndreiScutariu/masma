using System;
using jade.content.lang.sl;
using jade.content.onto.basic;
using jade.core;
using jade.domain.mobility;
using jade.lang.acl;

namespace Masma.Lab4.Demo
{
    public class Common
    {
        public static void SendRequest(Agent caller, Action action)
        {
            // registers the ontology and the standard language for communicating with the AMS 
            caller.getContentManager().registerLanguage(new SLCodec());
            caller.getContentManager().registerOntology(MobilityOntology.getInstance());

            // Send the request to the AMS
            var request = new ACLMessage(ACLMessage.REQUEST);
            request.setLanguage(new SLCodec().getName());
            request.setOntology(MobilityOntology.getInstance().getName());

            try
            {
                caller.getContentManager().fillContent(request, action);
                request.addReceiver(action.getActor());
                caller.send(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}