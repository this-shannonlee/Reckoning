using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reckoning.Core.Models;
public class Credit : Account, IStatement<Bill>
{
    [Column(TypeName = "decimal(18, 2)"), DataType(DataType.Currency)]
    public decimal Limit { get; set; }

    [Column(TypeName = "decimal(18, 2)"), DataType(DataType.Currency)]
    public decimal Available { get; private set; }

    [Column(TypeName = "decimal(18, 2)"), DataType(DataType.Currency)]
    [Display(Name = "Balance Goal %")]
    public decimal BalancePercentGoal { get; set; }

    [Column(TypeName = "decimal(18, 2)"), Display(Name = "APR%")]
    public decimal APRRate { get; set; }

    [Display(Name = "Auto Pay")]
    public bool AutoPay { get; set; }

    [Display(Name = "Payment Network")]
    public PaymentNetwork PaymentNetwork { get; set; }

    public override bool IsDebtAccount { get; } = true;

    public List<Bill> Statements { get; set; } = [];
}
