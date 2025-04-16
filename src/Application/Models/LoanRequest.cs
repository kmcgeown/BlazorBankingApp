namespace Application.Models;

public class LoanRequest
{
    public int CustomerId { get; set; }
    public string? Name { get; set; }

    [Range(1.00, 10000.00, ErrorMessage = "Loan amount must be between 1.00 and 10,000.00")]
    public decimal Amount { get; set; } = 0;
    public int CreditRating { get; set; }

    [AllowedValues(1, 3, 5, ErrorMessage = "Loan duration must be 1, 3, or 5 years.")]
    public int DurationYears { get; set; }
}
