using Domain.Services;

namespace Application.Services;

public class LoanService : ILoanService
{
    private static readonly List<(
        int MinRating,
        int MaxRating,
        int Duration,
        decimal Rate
    )> InterestRateRules =
    [
        (20, 50, 1, 0.20m), // 20%
        (20, 50, 3, 0.15m), // 15%
        (20, 50, 5, 0.10m), // 10%
        (51, 100, 1, 0.12m), // 12%
        (51, 100, 3, 0.08m), // 8%
        (51, 100, 5, 0.05m), // 5%
    ];

    public const decimal MaxLoanAmount = 10000;
    public static readonly int[] AllowedDurations = { 1, 3, 5 };

    public (bool IsApproved, string Message, decimal? InterestRate) ApplyForLoan(
        int creditRating,
        decimal amount,
        int duration
    )
    {
        if (creditRating < 20)
        {
            return (false, "Denied: To low of a credit rating.", null);
        }
        if (amount <= 0 || amount > MaxLoanAmount)
        {
            return (false, $"Denied: Loan amount must be between 0 and {MaxLoanAmount:C}.", null);
        }
        if (!AllowedDurations.Contains(duration))
        {
            return (false, "Invalid loan duration. Allowed durations are 1, 3, or 5 years.", null);
        }
        var rule = InterestRateRules.FirstOrDefault(r =>
            creditRating >= r.MinRating && creditRating <= r.MaxRating && r.Duration == duration
        );
        if (rule == default)
        {
            return (false, "Could not determine interest rate for the given parameters.", null);
        }
        decimal interestRate = rule.Rate;
        string message = $"Loan approved! Interest Rate: {interestRate:P2}.";
        return (true, message, interestRate);
    }
}
