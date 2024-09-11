﻿namespace CQRSOrderManagement.Interfaces.Dispatchers
{
    public interface IQueryDispatcher
    {
        Task<TResult> DispatchAsync<TQuery, TResult>(TQuery query);
    }
}
