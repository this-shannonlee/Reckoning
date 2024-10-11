using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reckoning.Core.Models;

public enum AccountStatus { Active, Closed, Collection }

public abstract class Account
{
    public int ID { get; set; }

    [Required, StringLength(50)]
    public required string Name { get; set; }

    [StringLength(50)]
    public string? Description { get; set; }

    [DataType(DataType.Url)]
    public string? Website { get; set; }

    public int EmailID { get; set; }

    public Email? Email { get; set; }

    public int PhoneID { get; set; }

    public Phone? Phone { get; set; }

    [StringLength(50)]
    public string? Notes { get; set; }

    // TODO: Protect Balance
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Balance { get; set; }

    [Display(Name = "Account Status")]
    public AccountStatus AccountStatus { get; set; }

    public abstract bool IsDebtAccount { get; }

    [StringLength(50), Display(Name = "Account Type")]
    public string? AccountType { get; set; }
}
