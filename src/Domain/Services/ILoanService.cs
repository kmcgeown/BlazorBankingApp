namespace Domain.Services
{
    public interface ILoanService
    {
        (bool IsApproved, string Message, decimal? InterestRate) ApplyForLoan(
            int creditRating,
            decimal amount,
            int duration
        );
    }
}
