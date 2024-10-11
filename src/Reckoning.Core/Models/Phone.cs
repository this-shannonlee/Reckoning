using System.ComponentModel.DataAnnotations;

namespace Reckoning.Core.Models;
public class Phone
{
    public int ID { get; set; }

    [Required]
    [DisplayFormat(DataFormatString = "{0:(###) ###-####}")]
    public required long Number { get; set; }

    public List<Account> Accounts { get; set; } = [];
}

