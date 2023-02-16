using GatewayAPI.Configuration;
using GatewayAPI.Extensions;

using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var graphQlConfig = new GraphQLConfiguration();
builder.Configuration.GetSection("GraphQL").Bind(graphQlConfig);

builder.Services
    .AddGraphQLServices(graphQlConfig);

builder.Services
    .AddSingleton(ConnectionMultiplexer.Connect(graphQlConfig.Redis!.Endpoint))
    .AddGraphQLServer()
    .AddRemoteSchemasFromRedis(graphQlConfig.ServiceName!, sp => sp.GetRequiredService<ConnectionMultiplexer>())
    .RenameType("Product", "CatalogProduct", "catalog");

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
