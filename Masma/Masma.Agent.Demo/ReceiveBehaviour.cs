using jade.core.behaviours;
using Masma.Messages;

namespace Masma.Demo
{
    internal class ReceiveBehaviour<T> : CyclicBehaviour where T : IMessage
    {
        public override void action()
        {
            var message = myAgent.receive();

            if (message != null)
            {

            }
            else
            {
                block();
            }
        }
    }
}