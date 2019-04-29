namespace Final.Agent
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal interface IQAgent : IAgent
    {
        QConstants Constants { get; }

        float QValue { get; }

        float Value { get; }
    }
}
