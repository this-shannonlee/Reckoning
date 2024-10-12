using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reckoning.Core.Models;

public enum SubscriptionTerm { Monthly, Quarterly, Yearly }

public class Subscription : Account, IStatement<Bill>
{
    [Column(TypeName = "decimal(18, 2)"), DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [Display(Name = "Subscription Term")]
    public SubscriptionTerm Term { get; set; } = SubscriptionTerm.Monthly;

    [Display(Name = "Renewal Date")]
    [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
    [DataType(DataType.Date)]
    public DateTime RenewalDate { get; set; }

    [Display(Name = "Auto Pay")]
    public bool AutoPay { get; set; }

    [Display(Name = "Payment Account")]
    public int PaymentAccountID { get; set; }

    public override bool IsDebtAccount { get; }
    public List<Bill> Statements { get; set; } = [];
}
