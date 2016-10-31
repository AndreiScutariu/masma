using System.Collections.Generic;
using AgentServices;
using jade.core;
using jade.core.behaviours;
using jade.lang.acl;

namespace Masma.Lab3.Demo
{
    public class Requester : Agent
    {
        private List<AID> _providers;
        private FormAgent _windowsForm;

        public override void setup()
        {
            var args = getArguments();
            if (args != null)
            {
                _windowsForm = (FormAgent) args[0];
                _windowsForm.Text = getName();
                _windowsForm.Show();
            }

            _providers = YellowPages.FindService("Services.Addition", this, 10);

            addBehaviour(new WinFormRefreshBehaviour(this, 100));
            addBehaviour(new ReceiveBehaviour(this));
            addBehaviour(new RequestSendBehaviour(this));
        }

        private class ReceiveBehaviour : CyclicBehaviour
        {
            private new readonly Requester myAgent;

            public ReceiveBehaviour(Requester a) : base(a)
            {
                myAgent = a;
            }

            public override void action()
            {
                var message = myAgent.receive();

                if (message != null)
                {
                    var s = "Received " + message.getContent() + " from " + message.getSender().getLocalName();
                    myAgent._windowsForm.AddTextLine(s);
                }
                else
                    block();
            }
        }

        private class WinFormRefreshBehaviour : TickerBehaviour
        {
            private new readonly Requester myAgent;

            public WinFormRefreshBehaviour(Requester a, long period) : base(a, period)
            {
                myAgent = a;
            }

            public override void onTick()
            {
                myAgent._windowsForm.DoEvents();
            }
        }

        private class RequestSendBehaviour : OneShotBehaviour
        {
            private new readonly Requester myAgent;

            public RequestSendBehaviour(Requester a) : base(a)
            {
                myAgent = a;
            }

            public override void action()
            {
                if (myAgent._providers.Count == 0)
                {
                    myAgent._windowsForm.AddTextLine("No service provider found.");
                }
                else
                {
                    var message = new ACLMessage(ACLMessage.REQUEST);
                    var receiverAid = myAgent._providers[0];
                    myAgent._windowsForm.AddTextLine("Found provider " + receiverAid.getLocalName());
                    message.addReceiver(receiverAid);
                    message.setConversationId("ID1");
                    message.setContent("5:6");
                    myAgent.send(message);
                }
            }
        }
    }
}