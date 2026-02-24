using Workflow.Application.Services;
using Workflow.Domain;

namespace Workflow.Application.StateUseCades
{
    public sealed class GetStateByCode
    {
        private readonly ICodeRepository<State> _repository;

        public GetStateByCode(ICodeRepository<State> repository)
        {
            _repository = repository;
        }

        public async Task<State?> Execute(int code)
        {
            return await _repository.GetAsync(code);
        }
    }
}
