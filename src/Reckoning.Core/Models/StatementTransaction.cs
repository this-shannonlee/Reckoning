using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reckoning.Core.Models;

public enum TransactionStatus
{
    Forecast,
    Due,
    Pending,
    Settled,
    Scheduled
}

public enum TransactionCategory
{
    Other,
    [Display(Name = "Credit Card")]
    CreditCard,
    Deposit,
    Entertainment,
    Food,
    Loan,
    Shopping,
    Travel,
    Transfer,
    Utilities,
}

public class StatementTransaction
{
    public int ID { get; set; }

    public int PayorStatementID { get; set; }

    [Display(Name = "Payor")]
    public Statement? PayorStatement { get; set; }

    public int PayeeStatementID { get; set; }

    [Display(Name = "Payee")]
    public Statement? PayeeStatement { get; set; }

    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; }

    [Required]
    [Display(Name = "Date Submitted")]
    [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
    [DataType(DataType.Date)]

    public required DateTime SubmitDate { get; set; }

    [Display(Name = "Reference #")]
    public string? ReferenceNo { get; set; }

    [Required]
    public required TransactionStatus Status { get; set; } = TransactionStatus.Due;

    [Required]
    public required TransactionCategory Category { get; set; } = TransactionCategory.Other;

    [StringLength(50)]
    public string? Notes { get; set; }
}
