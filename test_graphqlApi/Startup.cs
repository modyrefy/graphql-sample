using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using test_graphqlApi.graphqlCore;
using test_graphqlApi.repo;

namespace test_graphqlApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IParticipantRepository, ParticipantRepository>();
            services.AddSingleton<ISchema, ParticipantSchema>(services => new ParticipantSchema(new SelfActivatingServiceProvider(services)));
           services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
            }).AddSystemTextJson();
            // services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            //services.AddScoped<ParticipantSchema>();
            //services.AddSingleton<ParticipantType>();
            //services.AddSingleton<ParticipantQuery>();
            //services.AddGraphQL();
            // services.AddGraphQL().AddSystemTextJson().AddGraphTypes(typeof(ParticipantSchema),ServiceLifetime.Scoped);

            //var sp = services.BuildServiceProvider();
            //services.AddSingleton<ipar>(new ParticipantSchema(new FuncDependencyResolver(type => sp.GetService(type))));


            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
           
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseAuthorization();
            //app.UseGraphQL("/graphql");
            app.UseGraphQL<ISchema>();
            app.UseGraphQLPlayground(options: new PlaygroundOptions());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
