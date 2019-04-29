namespace Final.Agent
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SystemState
    {
        RobotControlState RobotState { get; }

        List<IAgent> WorkerStates {get;}


    }
}
