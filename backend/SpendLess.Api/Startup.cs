using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SpendLess.Api.Queries.Categories;
using SpendLess.Api.Queries.Expenses;
using SpendLess.Api.Queries.Predictions;
using SpendLess.Api.Queries.Raports;
using SpendLess.Api.Queries.Stats;
using SpendLess.Domain.Interfaces;
using SpendLess.Infrastructure;
using SpendLess.Infrastructure.Repositories;

namespace SpendLess.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SpendLessContext spendLessContext)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseCors();

            spendLessContext.Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            #region Categories
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddMediatR(typeof(GetCategoryByIdQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AddCategoryCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateCategoryCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(RemoveCategoryCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetAllCategoriesQuery).GetTypeInfo().Assembly);
            #endregion

            #region Expenses
            services.AddScoped<IExpensesRepository, ExpensesRepository>();
            services.AddMediatR(typeof(GetExpenseByIdQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AddExpenseCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateExpenseCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(RemoveExpenseCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetAllExpensesQuery).GetTypeInfo().Assembly);
            #endregion

            #region Raports
            services.AddScoped<IRaportsRepository, RaportsRepository>();
            services.AddMediatR(typeof(GetRaportQuery).GetTypeInfo().Assembly);
            #endregion

            #region Predictions
            services.AddScoped<IPredictionsRepository, PredictionsRepository>();
            services.AddMediatR(typeof(GetPredictionQuery).GetTypeInfo().Assembly);
            #endregion

            #region Stats
            services.AddMediatR(typeof(GetStatsQuery).GetTypeInfo().Assembly);
            #endregion

            services.AddDbContext<SpendLessContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SpendLess")));
            services.AddCors();
        }
    }
}

