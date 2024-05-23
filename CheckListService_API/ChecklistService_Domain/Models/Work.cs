namespace ChecklistService_Domain.Models;

using System;
using System.ComponentModel.DataAnnotations;

public partial class Work
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Description { get; set; } = null!;

    public bool Done { get; set; }

    public DateOnly? EndDate { get; set; }
}
