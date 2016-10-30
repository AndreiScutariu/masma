using jade.core.behaviours;
using Masma.Common.Agent;
using Masma.Common.Interfaces;
using Masma.Common.Setup;
using Masma.Messages.Common;
using Newtonsoft.Json;

namespace Masma.Common.Behaviour
{
    public class ReceiveAndHandleMessageBehaviour : CyclicBehaviour, INeedSpecifcAgent
    {
        private readonly AgentForRecieveMessage _agent;

        public ReceiveAndHandleMessageBehaviour(AgentForRecieveMessage agent) : base(agent)
        {
            _agent = agent;
        }

        public override void action()
        {
            var message = _agent.receive(); ////TODO Check this

            if (message != null)
            {
                var content = message.getContent();
                var sender = message.getSender();

                var receivedMessage = JsonConvert.DeserializeObject<HeaderMessage>(content);
                var type = receivedMessage.Type;

                var instance = MessageDeserializer.GetMessageInstance(type, content);

                _agent.Handle(instance, sender);
            }
            else
            {
                block();
            }
        }

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}