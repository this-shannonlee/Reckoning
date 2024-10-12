using System.ComponentModel.DataAnnotations;

namespace Reckoning.Core.Models;
public class Income : Account, IStatement<Statement>
{
    [Display(Name = "Pay Days")]

    public List<DayOfWeek> PayDays { get; set; } = [];

    public override bool IsDebtAccount { get; }

    public List<Statement> Statements { get; set; } = [];
}
