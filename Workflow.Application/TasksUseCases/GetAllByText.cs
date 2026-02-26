using Workflow.Application.Services;
using Workflow.Domain;

namespace Workflow.Application.TasksUseCases
{
    public sealed class GetAllByText
    {
        private readonly ITextRepository<TasksEntity> _repository;

        public GetAllByText(Services.ITextRepository<TasksEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TasksEntity>> ExecuteAsync(string text)
        {
            if (string.IsNullOrEmpty(text)) return Enumerable.Empty<TasksEntity>();

            return _repository.GetAllAsync(text);
        }
    }
}
