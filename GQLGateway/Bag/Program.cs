using Bag.API;
using Bag.API.Interface;
using Bag.Configuration;
using Bag.Extensions;
using Bag.Queries;

using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var graphQlConfig = new GraphQLConfiguration();
builder.Configuration.GetSection("GraphQL").Bind(graphQlConfig);

builder.Services
    .AddSingleton(ConnectionMultiplexer.Connect(graphQlConfig.Redis!.Endpoint))
    .AddScoped<IBagService, BagService>()
    .AddGraphQLServer()
    .AddQueryType<QueryBag>()
    .AddMutationType<MutationBag>()
    .AddMutationConventions(applyToAllMutations: true)
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
