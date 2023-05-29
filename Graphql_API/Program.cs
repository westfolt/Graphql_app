using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using Graphql_API.Contracts;
using Graphql_API.Entities.Context;
using Graphql_API.GraphQL.GraphQLQueries;
using Graphql_API.GraphQL.GraphQLSchema;
using Microsoft.EntityFrameworkCore;

namespace Graphql_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("graphqlConString")));

            builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();

            builder.Services.AddSingleton<ISchema, AppSchema>(services => new AppSchema(new SelfActivatingServiceProvider(services)));
            builder.Services.AddGraphQL(options =>
                options.ConfigureExecution((opt, next) =>
                {
                    opt.EnableMetrics = true;
                    return next(opt);
                }).AddSystemTextJson()
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
                app.UseGraphQLAltair();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseGraphQL<ISchema>();

            app.Run();
        }
    }
}