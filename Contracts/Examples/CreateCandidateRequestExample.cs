using Swashbuckle.AspNetCore.Filters;

namespace FormApi.Contracts.Examples
{
    public class CreateCandidateRequestExample : IMultipleExamplesProvider<CreateCandidateRequest>
    {
        public IEnumerable<SwaggerExample<CreateCandidateRequest>> GetExamples()
        {
            return new List<SwaggerExample<CreateCandidateRequest>>
            {
                new SwaggerExample<CreateCandidateRequest>
                {
                    Name = "Example 1",
                    Value = new CreateCandidateRequest("Иванов", "Пётр", "Козловский")
                },
                new SwaggerExample<CreateCandidateRequest>
                {
                    Name = "Example 2",
                    Value = new CreateCandidateRequest("John", "Doe", "Smith")
                }
            };
        }
    }
}
