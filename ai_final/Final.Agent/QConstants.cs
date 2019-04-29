namespace Final.Agent
{
    internal class QConstants
    {
        public QConstants( float alpha = 0.5f, float epsilon = 0.5f, float discount = 0.9f, int episodes = 500 )
        {
            this.LearningRate = alpha;
            this.ExplorationRate = epsilon;
            this.Discount = discount;
            this.TrainingEpisodes = episodes;
        }

        public float Discount { get; }

        public float ExplorationRate { get; }

        public float LearningRate { get; }

        public int TrainingEpisodes { get; }
    }
}