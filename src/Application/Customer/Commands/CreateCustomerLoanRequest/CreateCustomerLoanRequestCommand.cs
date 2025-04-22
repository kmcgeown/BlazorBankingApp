namespace Application.Customer.Commands.CreateCustomerLoanRequest;

public record CreateCustomerLoanRequestCommand(LoanRequest LoanRequest) : IRequest<Account>;

public class CreateCustomerLoanRequestCommandHandler
    : IRequestHandler<CreateCustomerLoanRequestCommand, Account>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ILoanService _loanService;

    public CreateCustomerLoanRequestCommandHandler(
        ICustomerRepository customerRepository,
        ILoanService loanService
    )
    {
        _customerRepository = customerRepository;
        _loanService = loanService;
    }

    public async Task<Account> Handle(
        CreateCustomerLoanRequestCommand command,
        CancellationToken cancellationToken
    )
    {
        Account account = new();

        var (IsApproved, Message, InterestRate) = _loanService.ApplyForLoan(
            command.LoanRequest.CreditRating,
            command.LoanRequest.Amount,
            command.LoanRequest.DurationYears
        );

        //TODO: Should have its own helper method
        //TODO: Planned to return Message back to the UI to be used in notifications
        if (IsApproved)
        {
            account.Status = Enums.AccountStatus.Open;
            account.Type = Enums.AccountType.Loan;

            account.Balance = command.LoanRequest.Amount;
            var interestRate = InterestRate ?? 0;
            account.OutstandingBalance = command.LoanRequest.Amount * (1 + interestRate);

            //Fake update of db
            _ = await _customerRepository.CreateNewCustomerAccount(
                account,
                command.LoanRequest.CustomerId
            );
        }
        else
        {
            account.Status |= Enums.AccountStatus.Rejected;
            account.Type = Enums.AccountType.Loan;
            account.Balance = 0;
            account.OutstandingBalance = 0;
        }

        return account;
    }
}
