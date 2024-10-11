namespace Reckoning.Core.Models;
public interface IStatement<T> where T : Statement
{
    public List<T> Statements { get; set; }
}
