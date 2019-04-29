namespace Final.Agent.Interfaces
{
    using Final.Warehouse;

    internal interface IWorker : IAgent
    {
        Route ReRoute( );
    }
}