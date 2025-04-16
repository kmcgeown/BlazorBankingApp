namespace Application.Services;

public class LoanService : ILoanService
{
    public const decimal MaxLoanAmount = 10000;
    public static readonly int[] AllowedDurations = { 1, 3, 5 };

    private readonly List<IInterestRateRule> _rules;

    public LoanService()
    {
        _rules = new List<IInterestRateRule>
        {
            new InterestRule(20, 50, 1, 0.20m),
            new InterestRule(20, 50, 3, 0.15m),
            new InterestRule(20, 50, 5, 0.10m),
            new InterestRule(51, 100, 1, 0.12m),
            new InterestRule(51, 100, 3, 0.08m),
            new InterestRule(51, 100, 5, 0.05m),
        };
    }

    public (bool IsApproved, string Message, decimal? InterestRate) ApplyForLoan(
        int creditRating,
        decimal amount,
        int duration
    )
    {
        if (creditRating < 20)
            return (false, "Denied: Too low of a credit rating.", null);

        if (amount <= 0 || amount > MaxLoanAmount)
            return (false, $"Denied: Loan amount must be between 0 and {MaxLoanAmount:C}.", null);

        if (!AllowedDurations.Contains(duration))
            return (false, "Invalid loan duration. Allowed durations are 1, 3, or 5 years.", null);

        var rule = _rules.FirstOrDefault(r => r.IsMatch(creditRating, duration));

        if (rule == null)
            return (false, "Could not determine interest rate for the given parameters.", null);

        return (true, $"Loan approved! Interest Rate: {rule.Rate:P2}.", rule.Rate);
    }
}
