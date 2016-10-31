using System;
using System.Collections.Generic;
using jade.core;
using jade.core.behaviours;
using jade.lang.acl;
using Masma.Common.Interfaces;
using Masma.Lab3.Messages;
using Masma.Lab3.Services;
using Newtonsoft.Json;

namespace Masma.Lab3.Behaviours
{
    public class ConsumerSendSumRequestsBehaviour<T> : OneShotBehaviour, INeedSpecifcAgent
        where T : Agent, IHaveAnWindowsForm
    {
        protected readonly T MyAgent;

        public ConsumerSendSumRequestsBehaviour(T a) : base(a)
        {
            MyAgent = a;
        }

        private List<AID> _providers;

        public override void action()
        {
            _providers = ServiceLocator.FindService("__HandleAddThisNumbersRequest", MyAgent, 10);

            if (_providers.Count == 0)
            {
                MyAgent.Form.AddTextLine("No service provider found.");
            }
            else
            {
                MyAgent.Form.AddTextLine("Found provider " + _providers[0].getLocalName());
                MyAgent.send(CreateRequestMessage());
            }
        }

        private ACLMessage CreateRequestMessage()
        {
            var message = new ACLMessage(ACLMessage.REQUEST);
            message.addReceiver(_providers[0]);
            message.setContent(JsonConvert.SerializeObject(new AddThisNumbersRequest
            {
                Left = 4,
                Right = 5,
                CorrelationId = Guid.NewGuid()
            }));
            return message;
        }
    }
}