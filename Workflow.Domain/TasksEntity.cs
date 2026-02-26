namespace Workflow.Domain
{
    public sealed class TasksEntity
    {
        public readonly Guid Id;
        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public int StateCode { get; private set; }
        public int PriorityCode { get; private set; }

        public TasksEntity(string name, string description, int stateCode, int priorityCode)
        {
            _ValidateName(name);
            _ValidateDescription(description);

            Id = Guid.NewGuid();
            Name = name.Trim();
            Description = description.Trim();
            StateCode = stateCode;
            PriorityCode = priorityCode;
        }

        public TasksEntity(Guid id, string name, string description, int stateCode, int priorityCode)
        {
            _ValidateName(name);
            _ValidateDescription(description);

            Id = id;
            Name = name.Trim();
            Description = description.Trim();
            StateCode = stateCode;
            PriorityCode = priorityCode;
        }

        public void ChangeData(string name, string description)
        {
            _ValidateName(name);
            _ValidateDescription(description);

            Name = name.Trim();
            Description = description.Trim();
        }

        public void ChangeState(StateEntity state)
        {
            StateCode = state.Code;
        }

        public void ChangePriority(PriorityEntity priority)
        {
            PriorityCode = priority.Code;
        }

        private void _ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("El nombre no puede ser vacio", nameof(name));
        }

        private void _ValidateDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("El nombre no puede ser vacio", nameof(description));
        }
    }
}
