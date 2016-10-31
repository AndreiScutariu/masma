using jade.core;
using jade.core.behaviours;
using jade.lang.acl;
using Masma.Common.Interfaces;
using Masma.Common.Setup;
using Masma.Messages.Common;
using Newtonsoft.Json;

namespace Masma.Lab3.Behaviours.Base
{
    public abstract class ReceiveAndHandleMessageBehaviour<T> : CyclicBehaviour, INeedSpecifcAgent
        where T : Agent, IHaveAnWindowsForm
    {
        protected readonly T MyAgent;

        protected ReceiveAndHandleMessageBehaviour(T a) : base(a)
        {
            MyAgent = a;
        }

        public override void action()
        {
            var message = MyAgent.receive();

            if (message != null)
            {
                var content = message.getContent();
                var sender = message.getSender();

                var receivedMessage = JsonConvert.DeserializeObject<HeaderMessage>(content);
                var type = receivedMessage.Type;

                var instance = MessageDeserializer.GetMessageInstance(type, content);

                HandleWithCastToMessage(instance, sender);
            }
            else
            {
                block();
            }
        }

        protected abstract void HandleWithCastToMessage(object message, AID sender);

        protected void SendMessage(AID to, object info, int type = ACLMessage.REQUEST)
        {
            var reply = new ACLMessage(type);
            var receiverAid = new AID(to.getLocalName(), AID.ISLOCALNAME);
            reply.addReceiver(receiverAid);

            reply.setContent(JsonConvert.SerializeObject(info));
            MyAgent.send(reply);
        }
    }

    public interface IHandleMessage<in T> where T : IMessage
    {
        void Handle(T message, AID sender);
    }
}