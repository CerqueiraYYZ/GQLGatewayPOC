using Catalog.API.Interfaces;
using Catalog.Configuration;
using Catalog.Domain;
using Catalog.Extensions;
using Catalog.Queries;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var graphQlConfig = new GraphQLConfiguration();
builder.Configuration.GetSection("GraphQL").Bind(graphQlConfig);

builder.Services
    .AddSingleton(ConnectionMultiplexer.Connect(graphQlConfig.Redis.Endpoint))
    .AddScoped<IBrandService, BrandService>()
    .AddScoped<IProductService, ProductService>();

//Add gql
builder.Services
    .AddGraphQLServer()
    .AddQueryType<QueryProduct>()
    .AddTypeExtension<QueryBrand>()
    .InitializeOnStartup()
    .CustomPublishSchemaDefinition(graphQlConfig);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapGraphQL();
app.MapRazorPages();

app.Run();
