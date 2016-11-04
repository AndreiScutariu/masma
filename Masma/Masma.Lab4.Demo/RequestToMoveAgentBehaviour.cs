using jade.content.onto.basic;
using jade.core;
using jade.core.behaviours;
using jade.domain.mobility;

namespace Masma.Lab4.Demo
{
    public class RequestToMoveAgentBehaviour : OneShotBehaviour
    {
        private readonly AID _agentToMove;
        private readonly ContainerID _newContainer;

        public RequestToMoveAgentBehaviour(AID agentToMove, ContainerID newContainer)
        {
            _agentToMove = agentToMove;
            _newContainer = newContainer;
        }

        public override void action()
        {
            var moveAction = new MoveAction();
            var describeMovement = new MobileAgentDescription();

            describeMovement.setName(_agentToMove);
            describeMovement.setDestination(_newContainer);
            moveAction.setMobileAgentDescription(describeMovement);

            Common.SendRequest(myAgent, new Action(myAgent.getAMS(), moveAction));
        }
    }
}