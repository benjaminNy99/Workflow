using Workflow.Application.Services;
using Workflow.Domain;

namespace Workflow.Application.PriorityUseCase
{
    public sealed class GetPriorityByCode
    {
        private ICodeRepository<PriorityEntity> _repository;

        public GetPriorityByCode(ICodeRepository<PriorityEntity> repository)
        {
            _repository = repository;
        }

        public async Task<PriorityEntity?> ExecuteAsync(int code)
        {
            return await _repository.GetAsync(code);
        }
    }
}
