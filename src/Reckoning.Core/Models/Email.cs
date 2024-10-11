using System.ComponentModel.DataAnnotations;

namespace Reckoning.Core.Models;

public class Email
{
    public int ID { get; set; }

    [Required]
    [StringLength(50), DataType(DataType.EmailAddress)]
    public required string Address { get; set; }

    public List<Account> Accounts { get; set; } = [];
}
