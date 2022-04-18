using GraphQL.Types;
using test_graphqlApi.models;

namespace test_graphqlApi.graphqlCore
{
    public class ParticipantType : ObjectGraphType<Participant>
    {
        public ParticipantType()
        {
            Name = "Participant Type";
            Description = "Participant Type";
            Field(x => x.Id).Description("Id");
            Field(x => x.Name).Description("Name");
            Field(x => x.Age).Description("Age");
            Field(x => x.UserName).Description("UserName");
            Field(x => x.FirstName).Description("FirstName");
            Field(x => x.LastName).Description("LastName");
            Field(x => x.Rate).Description("Rate");
        }
    }
}
