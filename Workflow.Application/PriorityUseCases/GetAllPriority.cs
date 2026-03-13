using Workflow.Application.Services;
using Workflow.Domain;

namespace Workflow.Application.PriorityUseCases
{
    public class GetAllPriority
    {
        private ICodeRepository<PriorityEntity> _repository;

        public GetAllPriority(ICodeRepository<PriorityEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PriorityEntity>> ExecuteAsync()
        {
            return await _repository.GetAllAsync() ?? Enumerable.Empty<PriorityEntity>();
        }
    }
}
