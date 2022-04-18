using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.Types;
using test_graphqlApi;
using test_graphqlApi.graphqlCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddSingleton<ISchema, ParticipantSchema>(services => new ParticipantSchema(new SelfActivatingServiceProvider(services)));
// register graphQL
//builder.Services.AddGraphQL();//.AddSystemTextJson();

builder.Services.AddGraphQL(options => options.AddSystemTextJson().AddSchema<ParticipantSchema>());
// default setup
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "GraphQLNetExample", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQLNetExample v1"));
    // add altair UI to development only

    //app.UseGraphQLAltair();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// make sure all our schemas registered to route
app.UseGraphQL<ISchema>();

app.Run();






//var startup = new Startup(builder.Configuration);
//IWebHostEnvironment environment = builder.Environment;

//startup.ConfigureServices(builder.Services);
//var app = builder.Build();
//startup.Configure(app, environment);
//app.Run();

// Add services to the container.



// Configure the HTTP request pipeline.
