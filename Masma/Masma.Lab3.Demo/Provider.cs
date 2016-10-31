using System;
using AgentServices;
using jade.core;
using jade.core.behaviours;
using jade.lang.acl;

namespace Masma.Lab3.Demo
{
    public class Provider : Agent
    {
        private FormAgent windowsForm;

        public override void setup()
        {
            var args = getArguments();
            if (args != null)
            {
                windowsForm = (FormAgent) args[0];
                windowsForm.Text = getName();
                windowsForm.Show();
            }
            RegisterService();

            addBehaviour(new WinFormRefreshBehaviour(this, 100));
            addBehaviour(new ReceiveBehaviour(this));
        }

        public void RegisterService()
        {
            try
            {
                YellowPages.RegisterService("Services.Addition", this);
                windowsForm.AddTextLine("Services.Addition service registered");
            }
            catch (Exception exc)
            {
                windowsForm.AddTextLine("Exception registering service: " + exc.Message);
            }
        }


        private class ReceiveBehaviour : CyclicBehaviour
        {
            private new readonly Provider myAgent;

            public ReceiveBehaviour(Provider a) : base(a)
            {
                myAgent = a;
            }

            public override void action()
            {
                ACLMessage message = null;

                var pattern = MessageTemplate.MatchConversationId("ID1");
                message = myAgent.receive(pattern);

                if (message != null)
                {
                    var messageContent = message.getContent();
                    var s = "Received " + messageContent + " from " + message.getSender().getLocalName();
                    myAgent.windowsForm.AddTextLine(s);

                    //process the received data, which should be in the format number1:number2
                    //returns the sum of number1 and number2

                    var reply = new ACLMessage();
                    reply.addReceiver(message.getSender());
                    reply.setContent(GetAnswer(messageContent));
                    myAgent.send(reply);
                }
                else
                    block();
            }

            private static string GetAnswer(string s)
            {
                var suma = s.Split(new[] {":"}, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    if (suma.Length != 2)
                    {
                        return "The message must be in the format number:number";
                    }
                    var rez = int.Parse(suma[0]) + int.Parse(suma[1]);
                    return rez.ToString();
                }
                catch (Exception ex)
                {
                    return "The message must be in the format number:number";
                }
            }
        }


        private class WinFormRefreshBehaviour : TickerBehaviour
        {
            private new readonly Provider myAgent;

            public WinFormRefreshBehaviour(Provider a, long period) : base(a, period)
            {
                myAgent = a;
            }

            public override void onTick()
            {
                myAgent.windowsForm.DoEvents();
            }
        }
    }
}