namespace Reckoning.Core.Models;
public class Miscellaneous : Account, IStatement<Statement>
{
    public override bool IsDebtAccount { get; }

    public List<Statement> Statements { get; set; } = [];
}
