using System;
using jade.core;
using jade.lang.acl;
using Masma.Messages;
using Newtonsoft.Json;

namespace Masma.Common.Agent
{
    public class AgentForRecieveMessage : BaseAgent
    {
        public void Handle(object message, AID sender)
        {
            var request = message as WhatIsTheTimeRequest;
            if (request != null)
            {
                Handle(request, sender);
            }

            var response = message as WhatIsTheTimeResponse;
            if (response != null)
            {
                Handle(response, sender);
            }
        }

        private void Handle(WhatIsTheTimeResponse message, AID sender)
        {
            Console.WriteLine("[{0} from {1}] Response[{2}]: {3}.", getLocalName(),
                sender.getLocalName(),
                message.CorrelationId, message.Value);
        }

        private void Handle(WhatIsTheTimeRequest message, AID sender)
        {
            Console.WriteLine("[{0} to {1}] Request[{2}]: {3}.", getLocalName(), sender.getLocalName(),
                message.CorrelationId, message.Value);

            var reply = new ACLMessage();
            var receiverAid = new AID(sender.getLocalName(), AID.ISLOCALNAME);
            reply.addReceiver(receiverAid);

            var messageContent = new WhatIsTheTimeResponse
            {
                Value = "The time is " + DateTime.Now.ToShortDateString(),
                CorrelationId = message.CorrelationId
            };

            reply.setContent(JsonConvert.SerializeObject(messageContent));
            send(reply);
        }
    }
}