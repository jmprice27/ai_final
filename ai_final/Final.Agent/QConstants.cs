namespace Final.Agent
{
    public struct QConstants
    {
        public QConstants( float alpha = 0.5f, float epsilon = 0.5f, float gamma = 0.9f, int episodes = 500 )
        {
            this.LearningRate = alpha;
            this.ExplorationRate = epsilon;
            this.Discount = gamma;
            this.TrainingEpisodes = episodes;
        }

        public float Discount { get; }

        public float ExplorationRate { get; }

        public float LearningRate { get; }

        public int TrainingEpisodes { get; }
    }
}