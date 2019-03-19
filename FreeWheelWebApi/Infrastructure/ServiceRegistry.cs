using FreeWheel.Service.DataServices;
using FreeWheel.Service.Infrasturcture.ErrorHandler;
using FreeWheelDataAccess.Context;
using Microsoft.Extensions.DependencyInjection;

namespace FreeWheel.MovieWebApi.Infrastructure
{
    internal static  class ServiceRegistry
    {
        public static void ConfigureServices(IServiceCollection services)
        {
           
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IErrorHandler, ErrorHandler>();
        }
    }
}
