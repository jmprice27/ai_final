namespace Final.Agent
{
    using System;
    using Final.Warehouse;

    public class AgentSystem
    {
        public Map Map { get; }

        public SystemState State { get; private set; }

        public void Advance( int timeStep = 1 )
        {
            this.State = this.Advance( this.Advance( this.State ) );
        }

        /// <summary>
        /// Move system and all agents to the next state frame
        /// </summary>
        /// <param name="currentState"></param>
        /// <param name="timeStep"></param>
        /// <returns></returns>
        private SystemState Advance( SystemState currentState, int timeStep = 1 )
        {
            foreach (var worker in currentState.WorkerStates)
            {
                if (!worker.HasRoute)
                {
                    worker.AssignDestination( this.Dispatch() );
                }

                worker.Advance( );
            }

            if (!currentState.Robot.HasRoute)
            {
                currentState.Robot.AssignDestination( this.Dispatch() );
            }

            currentState.Robot.Advance( );

            return currentState.Update( );
        }

        private Node Dispatch( )
        {
            var nodeCount = this.Map.Nodes.Count;
            var random = new Random( );

            int destinationNodeId = random.Next( 0, nodeCount );

            return this.Map.FindNode( destinationNodeId );
        }
    }
}