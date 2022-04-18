using test_graphqlApi.models;

namespace test_graphqlApi.data
{
    public class dataExample
    {
        public List<Participant> GetParticipants()
        {
            List<Participant> list = new();
            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                list.Add(new Participant()
                {
                    Id = i,
                    Name = $"Name-{i.ToString()}",
                    Age = r.Next(0, 100),
                    UserName = $"UserName-{i.ToString()}",
                    FirstName = $"FirstName-{i.ToString()}",
                    LastName = $"LastName-{i.ToString()}",
                    Rate = r.Next(0, 100),
                });
            }
            return list;
        }
    }
}
