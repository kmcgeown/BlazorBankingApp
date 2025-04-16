using Application.Customer.Commands.CreateCustomerLoanRequest;
using Application.Enums;
using Application.Interfaces.Repositories;
using Application.Models;
using Domain.Services;
using FluentAssertions;
using Moq;

namespace IntegrationTests.Application
{
    public class CreateCustomerLoanRequestCommandHandlerTest
    {
        //    [Fact]
        //    public async Task Handle_ShouldReturnApprovedLoanAccount_WhenLoanIsApproved()
        //    {
        //        // Arrange
        //        var mockRepo = new Mock<ICustomerRepository>();
        //        var mockLoanService = new Mock<ILoanService>();

        //        var loanRequest = new LoanRequest
        //        {
        //            CustomerId = 1,
        //            Amount = 5000,
        //            CreditRating = 55,
        //            DurationYears = 3,
        //        };

        //        mockLoanService
        //            .Setup(s =>
        //                s.ApplyForLoan(
        //                    loanRequest.CreditRating,
        //                    loanRequest.Amount,
        //                    loanRequest.DurationYears
        //                )
        //            )
        //            .Returns((true, "Approved", 0.08m));

        //        var handler = new CreateCustomerLoanRequestCommandHandler(
        //            mockRepo.Object,
        //            mockLoanService.Object
        //        );

        //        var command = new CreateCustomerLoanRequestCommand(loanRequest);

        //        // Act
        //        var result = await handler.Handle(command, CancellationToken.None);

        //        // Assert
        //        result.Should().NotBeNull();
        //        result.Type.Should().Be(AccountType.Loan);
        //        result.Status.Should().Be(AccountStatus.Open);
        //        result.Balance.Should().Be(5000);
        //        result.OutstandingBalance.Should().BeApproximately(5000 * 1.08m, 0.01m);

        //        mockRepo.Verify(
        //            repo => repo.UpdateCustomerAccount(result, loanRequest.CustomerId),
        //            Times.Once
        //        );
        //    }
    }
}

//private readonly IMediator _mediator;
//private readonly ILoanService _loanService;
//private readonly ICustomerRepository _customerRepository;
//private readonly IFixture _fixture = new Fixture();

//public CreateCustomerLoanRequestCommandHandlerTest(
//    ICustomerRepository customerRepository,
//    ILoanService loanService
//)
//{
//    _mediator = Substitute.For<IMediator>();
//    _loanService = Substitute.For<ILoanService>();
//    _customerRepository = customerRepository;
//    //_loanService = loanService;
//}

//[Theory]
//[InlineData(20, 1, 20)]
//[InlineData(30, 3, 15)]
//[InlineData(50, 5, 10)]
//[InlineData(60, 1, 12)]
//[InlineData(75, 3, 8)]
//[InlineData(100, 5, 5)]
//public async Task Handle_return_true_for_test(
//    int creditRating,
//    int duration,
//    decimal expectedInterestRate
//)
//{
//    var client = _fixture
//        .Build<LoanRequest>()
//        .With(c => c.Amount, 10000)
//        .With(c => c.CreditRating, Arg.Is(creditRating))
//        .With(c => c.DurationYears, Arg.Is(duration))
//        .Create();

//    var handler = new CreateCustomerLoanRequestCommandHandler();
//    var command = new CreateCustomerLoanRequestCommand(client);

//    //LoanRequest loanRequest
//    // Act
//    var result = await handler.Handle(command, CancellationToken.None);

//    //Assert
//    result.Status.Should().Be(AccountStatus.Open);
//    result
//        .OutstandingBalance.Should()
//        .Be(result.OutstandingBalance * (1 + Arg.Is(expectedInterestRate)));
//}
