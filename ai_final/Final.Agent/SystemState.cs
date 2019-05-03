namespace Final.Agent
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class SystemState
    {
        public ControlledWorker Controlled { get; }

        public RobotControlState RobotState { get; }

        public SystemState Update( )
        {
            throw new NotImplementedException( );
        }

        public Robot Robot { get; }

        public List<IAgent> WorkerStates { get; }
    }
}