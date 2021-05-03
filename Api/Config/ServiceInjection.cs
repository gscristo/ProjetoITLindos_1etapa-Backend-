using Core.Person;
using Core.Person.Interfaces;
using Core.Person.Validators;
using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Config
{
    public class ServiceInjection
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            var databaseSettings = configuration.GetSection("DatabaseSettings");

            #region DataAccess

            services.AddSingleton<IDataContext>(serviceProvider => new DataContext(databaseSettings["LeanLearningSqlConnection"]));
            services.AddScoped<IPersonRepository, PersonRepository>();

            #endregion

            #region Core Services

            services.AddScoped<ICreatePerson, CreatePerson>();
            services.AddScoped<IGetAllPerson, GetAllPerson>();
            services.AddScoped<IGetPersonById, GetPersonById>();
            services.AddScoped<IDeletePerson, DeletePerson>();
            services.AddScoped<IUpdatePerson, UpdatePerson>();

            #endregion
        }
    }
}
