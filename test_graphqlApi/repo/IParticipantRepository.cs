using test_graphqlApi.models;

namespace test_graphqlApi.repo
{
    public interface IParticipantRepository
    {
        IEnumerable<Participant> GetAll();
    }
}
