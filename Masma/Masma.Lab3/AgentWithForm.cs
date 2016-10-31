using Masma.Common.Agent;
using Masma.Lab3.Form;

namespace Masma.Lab3
{
    public class AgentWithForm : BaseAgent, IHaveAnWindowsForm
    {
        public FormAgent Form { get; set; }

        public override void setup()
        {
            base.setup();

            Form = new FormAgent
            {
                Text = getLocalName()
            };

            Form.Show();
        }
    }
}