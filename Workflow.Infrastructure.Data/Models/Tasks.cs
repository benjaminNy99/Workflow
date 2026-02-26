using System;
using System.Collections.Generic;

namespace Workflow.Infrastructure.Data.Models;

public partial class Tasks
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int StateCode { get; set; }

    public int PriorityCode { get; set; }

    public virtual Priority PriorityCodeNavigation { get; set; } = null!;

    public virtual State StateCodeNavigation { get; set; } = null!;
}
