using Workflow.Application.Services;
using Workflow.Domain;

namespace Workflow.Application.StateUseCades
{
    public sealed class GetStateByCode
    {
        private readonly ICodeRepository<StateEntity> _repository;

        public GetStateByCode(ICodeRepository<StateEntity> repository)
        {
            _repository = repository;
        }

        public async Task<StateEntity?> Execute(int code)
        {
            return await _repository.GetAsync(code);
        }
    }
}
