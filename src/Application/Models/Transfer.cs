namespace Application.Models;

public class Transfer
{
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid 'From' account.")]
    public int FromAccountId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid 'To' account.")]
    public int ToAccountId { get; set; }

    [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Transfer amount must be positive.")]
    public decimal Amount { get; set; }
}
