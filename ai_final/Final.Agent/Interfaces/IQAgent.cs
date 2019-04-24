using System;
using System.Collections.Generic;
using System.Text;

namespace Final.Agent
{
    interface IQAgent : IAgent
    {
        float LearningRate{ get; }

        float ExplorationRate { get; }

        float Discount { get; }

        int TrainingEpisodes { get; }

        float QValue { get; }

        float Value { get; }

        void Update( RobotControlState state, IAgentAction action, IRobotControl nextState, float reward );

        IAgentAction Policy { get; }

        List<IAgentAction> LegalActions { get; }



    }
}
