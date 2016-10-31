using Masma.Common.Agent;
using Masma.Lab3.Form;

namespace Masma.Lab3
{
    public class AgentWithForm : BaseAgent, IHaveAnWindowsForm, IContainNumberProviders
    {
        public int NumberOfProviders { get; set; }

        public FormAgent Form { get; set; }

        public override void setup()
        {
            Form = new FormAgent
            {
                Text = getLocalName()
            };

            Form.Show();

            base.setup();
        }
    }
}