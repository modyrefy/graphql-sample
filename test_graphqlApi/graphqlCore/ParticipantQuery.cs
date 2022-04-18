using GraphQL.Types;
using test_graphqlApi.models;
using test_graphqlApi.repo;

namespace test_graphqlApi.graphqlCore
{
    public class ParticipantQuery : ObjectGraphType//<Participant>
    {
        public ParticipantQuery(IParticipantRepository repo)
        {
            Name = "ParticioantQueryTest";
            Field<ParticipantType>(
                "party",
                resolve: context => repo.GetAll()
                );
        }
    }
}
