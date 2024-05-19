namespace ChecklistService_Domain.Models;

using System;

public partial class Work
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public bool Done { get; set; }

    public DateOnly? EndDate { get; set; }
}
