namespace Application.InterestRules;

public interface IInterestRateRule
{
    bool IsMatch(int creditRating, int duration);
    decimal Rate { get; }
}
