using System;
using System.Collections.Generic;
using jade.core;
using jade.core.behaviours;
using jade.lang.acl;
using Masma.Common.Interfaces;
using Masma.Lab3.Messages;
using Masma.Lab3.ProductRepository;
using Masma.Lab3.Services;
using Newtonsoft.Json;

namespace Masma.Lab3.Behaviours
{
    public class ConsumerSendCostOfProductRequestsBehaviour<T> : OneShotBehaviour, INeedSpecifcAgent
        where T : Agent, IHaveAnWindowsForm, IContainNumberProviders
    {
        protected readonly T MyAgent;

        private List<AID> _providers;

        public ConsumerSendCostOfProductRequestsBehaviour(T a) : base(a)
        {
            MyAgent = a;
        }

        public override void action()
        {
            _providers = ServiceLocator.FindService("__HandleAddThisNumbersRequest", MyAgent, 10);
            MyAgent.NumberOfProviders = _providers.Count;

            if (_providers.Count == 0)
            {
                MyAgent.Form.AddTextLine("No service provider found.");
            }
            else
            {
                MyAgent.Form.AddTextLine($"Found {_providers.Count} providers.");

                var productId = ProductRepostory.RandomProduct();

                foreach (var provider in _providers)
                {
                    MyAgent.send(CreateRequestMessage(provider, productId));
                }
            }
        }

        private static ACLMessage CreateRequestMessage(AID provider, int productId)
        {
            var message = new ACLMessage(ACLMessage.REQUEST);
            message.addReceiver(provider);
            message.setContent(JsonConvert.SerializeObject(new CostOfProductRequest
            {
                ProductId = productId,
                CorrelationId = Guid.NewGuid()
            }));
            return message;
        }
    }
}