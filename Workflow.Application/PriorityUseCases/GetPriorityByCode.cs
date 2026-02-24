using Workflow.Application.Services;
using Workflow.Domain;

namespace Workflow.Application.PriorityUseCase
{
    public sealed class GetPriorityByCode
    {
        private ICodeRepository<Priority> _repository;

        public GetPriorityByCode(ICodeRepository<Priority> repository)
        {
            _repository = repository;
        }

        public async Task<Priority?> ExecuteAsync(int code)
        {
            return await _repository.GetAsync(code);
        }
    }
}
