using System;
using System.Threading;
using jade.core;
using jade.core.behaviours;
using jade.lang.acl;
using Masma.Common.Setup;
using Masma.Messages;
using Newtonsoft.Json;

namespace Masma.Common.Behaviour
{
    public class SendMessageToRandomAgentBehaviour : CyclicBehaviour
    {
        public override void action()
        {
            Thread.Sleep(1000);

            var receiverId = new Random().Next(0, Agents.All.Length);
            while (myAgent.getLocalName() == Agents.All[receiverId])
            {
                receiverId = new Random().Next(0, Agents.All.Length);
            }

            var message = new ACLMessage();
            var receiverAid = new AID(Agents.All[receiverId], AID.ISLOCALNAME);
            message.addReceiver(receiverAid);

            var messageContent = new WhatIsTheTimeRequest {CorrelationId = Guid.NewGuid(), Value = "What is the time?"};
            message.setContent(JsonConvert.SerializeObject(messageContent));
            myAgent.send(message);
        }
    }
}