using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using Graphql_API.Contracts;
using Graphql_API.Entities.Context;
using Graphql_API.GraphQL.GraphQLQueries;
using Graphql_API.GraphQL.GraphQLSchema;
using Graphql_API.GraphQL.GraphQLTypes;
using Microsoft.EntityFrameworkCore;
using GraphQL.DataLoader;

namespace Graphql_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("graphqlConString")));

            builder.Services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
            builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<AppQuery>();
            builder.Services.AddScoped<AppMutation>();
            builder.Services.AddScoped<OwnerType>();
            builder.Services.AddScoped<OwnerInputType>();
            builder.Services.AddScoped<AccountType>();
            builder.Services.AddScoped<AccountTypeEnumType>();

            builder.Services.AddScoped<ISchema, AppSchema>(services => 
                new AppSchema(new FuncServiceProvider(type => services.GetRequiredService(type))));
            builder.Services.AddGraphQL(options =>
                options.ConfigureExecution((opt, next) =>
                {
                    opt.EnableMetrics = true;
                    return next(opt);
                }).AddSystemTextJson().AddDataLoader()
            );

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseGraphQLPlayground();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseGraphQL<ISchema>();

            app.Run();
        }
    }
}