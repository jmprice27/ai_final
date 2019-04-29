namespace Final.Agent.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Final.Warehouse;

    internal interface IWorker : IAgent
    {
        Route ReRoute( );
    }
}
