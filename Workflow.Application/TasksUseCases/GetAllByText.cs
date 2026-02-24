using Workflow.Application.Services;
using Workflow.Domain;

namespace Workflow.Application.TasksUseCases
{
    public sealed class GetAllByText
    {
        private readonly ITextRepository<Tasks> _repository;

        public GetAllByText(Services.ITextRepository<Tasks> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Tasks>> ExecuteAsync(string text)
        {
            if (string.IsNullOrEmpty(text)) return Enumerable.Empty<Tasks>();

            return _repository.GetAllAsync(text);
        }
    }
}
