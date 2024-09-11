namespace CQRSOrderManagement.Interfaces.Handlers
{
    public interface ICommandHandler<TCommand, TResult>
    {
        Task<TResult> HandleAsync(TCommand command);
    }
}
