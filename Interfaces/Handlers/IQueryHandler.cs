namespace CQRSOrderManagement.Interfaces.Handlers
{
    public interface IQueryHandler<TQuery, TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
