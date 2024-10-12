using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reckoning.Core.Models;
public enum StatementStatus { Projection, Active, Closed }

public class Statement
{
    public int ID { get; set; }
    public int AccountID { get; set; }
    public Account? Account { get; set; }

    [Required]
    [Display(Name = "Opening Date")]
    [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
    [DataType(DataType.Date)]
    public required DateTime OpenDate { get; set; }

    [Display(Name = "Closing Date")]
    [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
    [DataType(DataType.Date)]
    public DateTime? CloseDate { get; set; }

    [Display(Name = "Opening Balance"), DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal OpenBalance { get; set; }

    [Display(Name = "Target Balance"), DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal TargetBalance { get; set; }

    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Interest { get; set; }

    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Fees { get; set; }

    [Required]
    public required StatementStatus Status { get; set; }

    [StringLength(50)]
    public string? Notes { get; set; }

    [StringLength(50), Display(Name = "Statement Type")]
    public string? StatementType { get; set; }
}
