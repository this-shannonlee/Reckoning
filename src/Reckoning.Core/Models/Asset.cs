using System.ComponentModel.DataAnnotations;

namespace Reckoning.Core.Models;
public enum AssetCategory { Checking, Savings, Investment }

public class Asset : Account, IStatement<Statement>
{
    [Display(Name = "Routing Number")]
    public string? RoutingNumber { get; set; }

    [Display(Name = "Asset Category")]
    public AssetCategory AssetCategory { get; set; } = AssetCategory.Checking;

    [Display(Name = "Card Payment Network")]
    public PaymentNetwork PaymentNetwork { get; set; }

    public override bool IsDebtAccount { get; }

    public List<Statement> Statements { get; set; } = [];
}
