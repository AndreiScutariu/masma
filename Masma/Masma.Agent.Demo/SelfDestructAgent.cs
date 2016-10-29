using java.lang;
using Masma.Agent.Base;

namespace Masma.Demo
{
    public class SelfDestructAgent : BaseAgent
    {
        public override void setup()
        {
            logMyDetails();
            Thread.sleep(3000);
            doDelete();
        }
    }
}