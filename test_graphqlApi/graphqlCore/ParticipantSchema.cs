using GraphQL.Types;

namespace test_graphqlApi.graphqlCore
{
    public class ParticipantSchema: Schema
    {
        public ParticipantSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<ParticipantQuery>();
        }
    }
}
