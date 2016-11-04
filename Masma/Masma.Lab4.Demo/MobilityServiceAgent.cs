using jade.core;

namespace Masma.Lab4.Demo
{
    public class MobilityServiceAgent : Agent
    {
        private readonly AID _agentToMove;
        private readonly ContainerID _newContainer;

        public MobilityServiceAgent(AID agentToMove, ContainerID newContainer)
        {
            _agentToMove = agentToMove;
            _newContainer = newContainer;
        }

        public override void setup()
        {
            base.setup();
            addBehaviour(new RequestToMoveAgentBehaviour(_agentToMove, _newContainer));
            takeDown();
        }
    }
}