using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reckoning.Core.Models;
public class Bill : Statement
{
    [Required]
    [Display(Name = "Due Date")]
    [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
    [DataType(DataType.Date)]
    public required DateTime DueDate { get; set; }

    [Required]
    [Display(Name = "Amount Due"), DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public required decimal AmountDue { get; set; }

    [Display(Name = "Target Ammount"), DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal TargetAmount { get; set; }

    public bool IsPaid { get; set; }
}

