namespace Final.Agent
{
    using System.Collections.Generic;

    public class SystemState
    {
        public ControlledWorker Controlled { get; }

        public RobotControlState RobotState { get; }

        public List<IAgent> WorkerStates { get; }
    }
}