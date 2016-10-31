using jade.core;
using jade.core.behaviours;
using Masma.Common.Interfaces;

namespace Masma.Lab3.Behaviours
{
    public class WinFormRefreshBehaviour<T> : TickerBehaviour, INeedSpecifcAgent where T : Agent, IHaveAnWindowsForm
    {
        private readonly T _myAgent;

        public WinFormRefreshBehaviour(T a) : base(a, 100)
        {
            _myAgent = a;
        }

        public override void onTick()
        {
            _myAgent.Form.DoEvents();
        }
    }
}