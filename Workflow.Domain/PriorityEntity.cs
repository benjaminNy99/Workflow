namespace Workflow.Domain
{
    public sealed class PriorityEntity
    {
        public readonly int Code;
        public readonly string Description;

        public PriorityEntity(int code, string description)
        {
            if (code >= 0) throw new ArgumentException("El codigo no puede ser 0 o inferior", nameof(code));
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("La descripción no puede ser vacia", nameof(description));

            this.Code = code;
            this.Description = description.Trim();
        }
    }
}
