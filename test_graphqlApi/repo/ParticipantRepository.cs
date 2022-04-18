using test_graphqlApi.data;
using test_graphqlApi.models;

namespace test_graphqlApi.repo
{
    public class ParticipantRepository : IParticipantRepository
    {
        public IEnumerable<Participant> GetAll()
        {
           return new dataExample().GetParticipants();
        }
    }
}
