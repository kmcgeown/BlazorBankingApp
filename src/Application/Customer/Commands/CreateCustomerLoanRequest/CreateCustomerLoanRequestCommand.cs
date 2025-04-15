using Application.Models;
using Application.Services;
using Domain.Services;

namespace Application.Customer.Commands.CreateCustomerLoanRequest;

public record CreateCustomerLoanRequestCommand(LoanRequest loanRequest) : IRequest<Account>;

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
            command.loanRequest.CreditRating,
            command.loanRequest.Amount,
            command.loanRequest.DurationYears
        );
        if (IsApproved)
        {
            account.Type = Enums.AccountType.Loan;
            account.Balance = command.loanRequest.Amount;
            account.OutstandingBalance =
                (command.loanRequest.Amount * (InterestRate ?? 0)) + command.loanRequest.Amount;
            //_ = await _customerRepository.UpdateCustomerAccount(account);
        }
        else
        {
            account.Type = Enums.AccountType.Loan;
            account.Balance = 0;
            account.OutstandingBalance = 0;
        }

        await Task.Delay(100);
        return account;
    }
}
