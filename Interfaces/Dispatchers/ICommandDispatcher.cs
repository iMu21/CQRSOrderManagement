namespace CQRSOrderManagement.Interfaces.Dispatchers
{
    public interface ICommandDispatcher
    {
        Task<TResult> DispatchAsync<TCommand, TResult>(TCommand query);
    }
}
