using System.Collections.Generic;
using jade.core;
using Masma.Lab3.Behaviours.Base;
using Masma.Lab3.Messages;
using Masma.Lab3.ProductRepository;
using Masma.Lab3.Services;

namespace Masma.Lab3.Behaviours
{
    public class ProviderHandleRequestsBehaviour : ReceiveAndHandleMessageBehaviour<AgentWithForm>,
        IHandleMessage<AddThisNumbersRequest>, IHandleMessage<CostOfProductRequest>
    {
        private readonly List<Product> _products;

        public ProviderHandleRequestsBehaviour(AgentWithForm a) : base(a)
        {
            ServiceLocator.RegisterService("__HandleAddThisNumbersRequest", MyAgent);
            _products = ProductRepostory.GetMyProducts(MyAgent.getLocalName());

            DisplayMyProducts();
        }

        public void Handle(AddThisNumbersRequest message, AID sender)
        {
            MyAgent.Form.AddTextLine(
                $"Received from {sender.getLocalName()} [msg corr. id: {message.CorrelationId}] values: {message.Left}, {message.Right}.");

            SendMessage(sender, new AddThisNumbersResponse
            {
                CorrelationId = message.CorrelationId,
                Value = message.Left + message.Right
            });
        }

        public void Handle(CostOfProductRequest message, AID sender)
        {
            MyAgent.Form.AddTextLine(
                $"Received from {sender.getLocalName()} [msg corr. id: {message.CorrelationId}] product id: {message.ProductId}.");

            SendMessage(sender, new CostOfProductResponse
            {
                CorrelationId = message.CorrelationId,
                Product = GetProductById(message)
            });
        }

        private void DisplayMyProducts()
        {
            MyAgent.Form.AddTextLine("My products: ");
            foreach (var product in _products)
            {
                MyAgent.Form.AddTextLine("-> " + product);
            }
        }

        protected override void HandleWithCastToMessage(object message, AID sender)
        {
            if (message is AddThisNumbersRequest)
            {
                Handle((AddThisNumbersRequest) message, sender);
            }

            if (message is CostOfProductRequest)
            {
                Handle((CostOfProductRequest) message, sender);
            }
        }

        private Product GetProductById(CostOfProductRequest message)
        {
            foreach (var p in _products)
            {
                if (p.Id == message.ProductId)
                {
                    return p;
                }
            }
            return null;
        }
    }
}