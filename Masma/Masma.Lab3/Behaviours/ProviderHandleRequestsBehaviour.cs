using System.Collections.Generic;
using jade.core;
using Masma.Lab3.Behaviours.Base;
using Masma.Lab3.Messages;
using Masma.Lab3.ProductRepository;
using Masma.Lab3.Services;

namespace Masma.Lab3.Behaviours
{
    public class ProviderHandleRequestsBehaviour : ReceiveAndHandleMessageBehaviour<AgentWithForm>,
        IHandleMessage<AddThisNumbersRequest>
    {
        public ProviderHandleRequestsBehaviour(AgentWithForm a) : base(a)
        {
            ServiceLocator.RegisterService("__HandleAddThisNumbersRequest", MyAgent);
        }

        public void Handle(AddThisNumbersRequest message, AID sender)
        {
            MyAgent.Form.AddTextLine($"Received from {sender.getLocalName()} [msg corr. id: {message.CorrelationId}] values: {message.Left}, {message.Right}.");

            SendMessage(sender, new AddThisNumbersResponse
            {
                CorrelationId = message.CorrelationId,
                Value = message.Left + message.Right
            });
        }

        protected override void HandleWithCastToMessage(object message, AID sender)
        {
            var request = message as AddThisNumbersRequest;
            if (request != null)
            {
                Handle(request, sender);
            }
        }
    }
}