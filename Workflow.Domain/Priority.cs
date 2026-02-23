namespace Workflow.Domain
{
    public sealed class Priority
    {
        public readonly int Code;
        public readonly string Description;

        public Priority(int code, string description)
        {
            if (code >= 0) throw new ArgumentException("El codigo no puede ser 0 o inferior", nameof(code));
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("La descripción no puede ser vacia", nameof(description));

            this.Code = code;
            this.Description = description.Trim();
        }
    }
}
