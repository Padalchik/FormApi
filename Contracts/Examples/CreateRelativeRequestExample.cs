using Swashbuckle.AspNetCore.Filters;

namespace FormApi.Contracts.Examples
{
    public class CreateRelativeRequestExample : IMultipleExamplesProvider<CreateRelativeRequest>
    {
        public IEnumerable<SwaggerExample<CreateRelativeRequest>> GetExamples()
        {
            return new List<SwaggerExample<CreateRelativeRequest>>
            {
                new SwaggerExample<CreateRelativeRequest>
                {
                    Name = "Example 1",
                    Value = new CreateRelativeRequest(Guid.Empty, "Иванов", "Иван", "Иванович", Models.RelativeType.Brother)
                },
                new SwaggerExample<CreateRelativeRequest>
                {
                    Name = "Example 2",
                    Value = new CreateRelativeRequest(Guid.Empty, "Редькина", "Ирина", "Витальевна", Models.RelativeType.Sister)
                }
            };
        }
    }
}
