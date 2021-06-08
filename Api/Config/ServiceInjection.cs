using Core.Person;
using Core.Person.Interfaces;
using Core.Person.Validators;
using Core.Product;
using Core.Product.Interfaces;
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
            services.AddScoped<IProductRepository, ProductRepository>();

            #endregion

            #region Core Services

            services.AddScoped<ICreatePerson, CreatePerson>();
            services.AddScoped<IGetAllPerson, GetAllPerson>();
            services.AddScoped<IGetPersonById, GetPersonById>();
            services.AddScoped<IDeletePerson, DeletePerson>();
            services.AddScoped<IUpdatePerson, UpdatePerson>();
            services.AddScoped<IGetPersonByName, GetPersonByName>();
            services.AddScoped<IGetPersonByCpf, GetPersonByCpf>();



            services.AddScoped<ICreateProduct, CreateProduct>();
            services.AddScoped<IGetAllProduct, GetAllProduct>();
            services.AddScoped<IGetProductById, GetProductById>();
            services.AddScoped<IDeleteProduct, DeleteProduct>();
            services.AddScoped<IDeleteProductByCode, DeleteProductByCode>();
            services.AddScoped<IUpdateProduct, UpdateProduct>();
            services.AddScoped<IGetProductByName, GetProductByName>();
            services.AddScoped<IGetProductByCode, GetProductByCode>();
            #endregion
        }
    }
}
