namespace Final.Agent
{
    using System;

    public class AgentSystem
    {
        /// <summary>
        /// Move system and all agents to the next state frame
        /// </summary>
        /// <param name="currentState"></param>
        /// <param name="timeStep"></param>
        /// <returns></returns>
        public SystemState Advance( SystemState currentState, int timeStep = 1 )
        {
            throw new NotImplementedException( );
        }

        /// <summary>
        /// Iterate through the agents and assign
        /// </summary>
        private void GenerateDestinations( )
        {
            throw new NotImplementedException( );
        }
    }
}