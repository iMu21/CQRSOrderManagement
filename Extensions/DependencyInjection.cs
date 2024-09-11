using CQRSOrderManagement.Implements.Handlers.Auth.Command;
using CQRSOrderManagement.Implements.Helpers;
using CQRSOrderManagement.Interfaces.Dispatchers;
using CQRSOrderManagement.Interfaces.Handlers;
using CQRSOrderManagement.Interfaces.Helpers;
using CQRSOrderManagement.Models.Auth.Command;
using CQRSOrderManagement.Models.Auth.Response;
using CQRSOrderManagement.Models.Order.Command;
using CQRSOrderManagement.Models.Order.Query;
using CQRSOrderManagement.Services.Dispatchers;
using CQRSOrderManagement.Services.Handlers.Order.Command;
using CQRSOrderManagement.Services.Handlers.Order.Query;

namespace CQRSOrderManagement.Extensions
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region Register Dispatchers
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();

            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            #endregion

            #region Register Order Handlers
            services.AddScoped<IQueryHandler<Guid, OrderQuery>, GetOrderQueryHandler>();
            services.AddScoped<IQueryHandler<bool, List<OrderQuery>>, GetAllOrdersHandler>();

            services.AddScoped<ICommandHandler<CreateOrderCommand, bool>, CreateOrderCommandHandler>();
            #endregion

            #region Register Auth Handlers
            services.AddScoped<ICommandHandler<ForgetPasswordCommand, ForgetPasswordResponse>, ForgetPasswordCommandHandler>();
            services.AddScoped<ICommandHandler<LoginCommand, AuthResponse>, LoginCommandHandler>();
            services.AddScoped<ICommandHandler<RegisterCommand, AuthResponse>, RegisterCommandHandler>();
            #endregion

            #region Register Helpers
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddTransient<IEmailSender, EmailSender>();
            #endregion
        }
    }


}
