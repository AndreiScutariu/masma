using jade.core;
using Masma.Lab3.Behaviours.Base;
using Masma.Lab3.Messages;

namespace Masma.Lab3.Behaviours
{
    public class ConsumerHandleResponsesBehaviour : ReceiveAndHandleMessageBehaviour<AgentWithForm>,
        IHandleMessage<AddThisNumbersResponse>
    {
        public ConsumerHandleResponsesBehaviour(AgentWithForm a) : base(a)
        {
        }

        public void Handle(AddThisNumbersResponse message, AID sender)
        {
            MyAgent.Form.AddTextLine($"Received from {sender.getLocalName()} [msg corr. id: {message.CorrelationId}] value: {message.Value}.");
        }

        protected override void HandleWithCastToMessage(object message, AID sender)
        {
            var request = message as AddThisNumbersResponse;
            if (request != null)
            {
                Handle(request, sender);
            }
        }
    }
}