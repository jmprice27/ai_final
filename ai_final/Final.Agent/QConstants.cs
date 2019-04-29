using System;
using System.Collections.Generic;
using System.Text;

namespace Final.Agent
{
    class QConstants
    {
        public QConstants(float alpha=0.5f, float epsilon = 0.5f, float discount = 0.9f, int episodes = 500)
        {
            this.LearningRate = alpha;
            this.ExplorationRate = epsilon;
            this.Discount = discount;
            this.TrainingEpisodes = episodes;
        }

        float LearningRate { get; }

        float ExplorationRate { get; }

        float Discount { get; }

        int TrainingEpisodes { get; }
    }
}
