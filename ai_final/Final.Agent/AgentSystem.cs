namespace Final.Agent
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class AgentSystem
    {
        /// <summary>
        /// Move system and all agents to the next state frame
        /// </summary>
        /// <param name="currentState"></param>
        /// <param name="timeStep"></param>
        /// <returns></returns>
        SystemState Advance(SystemState currentState, int timeStep = 1)
        {
            throw new NotImplementedException( );
        }

        /// <summary>
        /// Iterate through the agents and assign 
        /// </summary>
        void GenerateDestinations()
        {
            throw new NotImplementedException( );
        }
    }
}
