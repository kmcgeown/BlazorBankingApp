namespace Application.Models;

public class Account
{
    public int AccountId { get; set; }
    public decimal Balance { get; set; }
    public decimal OutstandingBalance { get; set; }
    public AccountType Type { get; set; }
    public AccountStatus Status { get; set; }
}
