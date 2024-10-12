using System.ComponentModel.DataAnnotations;

namespace Reckoning.Core.Models;
public class Utility : Account, IStatement<Statement>
{
    [Display(Name = "Auto Pay")]
    public bool AutoPay { get; set; }

    public override bool IsDebtAccount { get; }

    public List<Statement> Statements { get; set; } = [];
}
