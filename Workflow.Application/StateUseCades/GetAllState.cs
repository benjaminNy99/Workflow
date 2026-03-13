using Workflow.Application.Services;
using Workflow.Domain;

namespace Workflow.Application.StateUseCades
{
    public class GetAllState
    {
        private ICodeRepository<StateEntity> _repository;

        public GetAllState(ICodeRepository<StateEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StateEntity>> ExecuteAsync()
        {
            return await _repository.GetAllAsync() ?? Enumerable.Empty<StateEntity>();
        }
    }
}
