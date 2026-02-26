using System;
using System.Collections.Generic;

namespace Workflow.Infrastructure.Data.Models;

public partial class State
{
    public int Code { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
}
