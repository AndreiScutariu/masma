using System.Collections.Generic;
using jade.core;
using Masma.Lab3.Behaviours.Base;
using Masma.Lab3.Messages;
using Masma.Lab3.ProductRepository;

namespace Masma.Lab3.Behaviours
{
    public class ConsumerHandleResponsesBehaviour : ReceiveAndHandleMessageBehaviour<AgentWithForm>,
        IHandleMessage<AddThisNumbersResponse>,
        IHandleMessage<CostOfProductResponse>
    {
        private readonly List<ProductWithSender> _receivedProducts;

        public ConsumerHandleResponsesBehaviour(AgentWithForm a) : base(a)
        {
            _receivedProducts = new List<ProductWithSender>();
        }

        public void Handle(AddThisNumbersResponse message, AID sender)
        {
            MyAgent.Form.AddTextLine($"Received from {sender.getLocalName()} [msg corr. id: {message.CorrelationId}] value: {message.Value}.");
        }

        public void Handle(CostOfProductResponse message, AID sender)
        {
            _receivedProducts.Add(new ProductWithSender
            {
                Product = message.Product,
                Sender = sender
            });

            MyAgent.Form.AddTextLine($"Received from {sender.getLocalName()} [msg corr. id: {message.CorrelationId}] product: {message.Product}.");

            if (_receivedProducts.Count == MyAgent.NumberOfProviders)
            {
                MyAgent.Form.AddTextLine($"Found min product: {GetMinProduct(_receivedProducts)}.");
            }
        }

        private static ProductWithSender GetMinProduct(IList<ProductWithSender> receivedProducts)
        {
            var minProd = receivedProducts[0];
            foreach (var receivedProduct in receivedProducts)
            {
                if (minProd.Product.Price > receivedProduct.Product.Price)
                {
                    minProd = receivedProduct;
                }
            }
            return minProd;
        }

        protected override void HandleWithCastToMessage(object message, AID sender)
        {
            if (message is AddThisNumbersResponse)
            {
                Handle((AddThisNumbersResponse) message, sender);
            }

            if (message is CostOfProductResponse)
            {
                Handle((CostOfProductResponse) message, sender);
            }
        }

        private class ProductWithSender
        {
            public Product Product { get; set; }

            public AID Sender { get; set; }

            public override string ToString() => $"{Product}, from sender: {Sender}";
        }
    }
}