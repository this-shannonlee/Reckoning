using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reckoning.Core.Models;
public class Loan : Account, IStatement<Bill>
{
    [Required]
    [Display(Name = "Origination Date")]
    [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
    [DataType(DataType.Date)]
    public required DateTime OriginationDate { get; set; }

    [Display(Name = "Finance Amount")]
    [Column(TypeName = "decimal(18, 2)"), DataType(DataType.Currency)]
    public decimal FinanceAmount { get; private set; }

    [Display(Name = "Total Payments")]
    public int Payments { get; set; }

    [Display(Name = "Payments Left")]
    public int PaymentsLeft { get; set; }

    [Display(Name = "Auto Pay")]
    public bool AutoPay { get; set; }

    public override bool IsDebtAccount { get; } = true;

    public List<Bill> Statements { get; set; } = [];
}
