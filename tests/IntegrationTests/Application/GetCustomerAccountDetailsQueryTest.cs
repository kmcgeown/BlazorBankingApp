using Application.Customer.Queries.GetCustomerAccountDetails;
using Application.Interfaces.Repositories;
using AutoFixture;
using FluentAssertions;
using MediatR;
using NSubstitute;

namespace IntegrationTests.Application;

public class GetCustomerAccountDetailsQueryTest
{
    //private readonly IMediator _mediator;
    //private readonly ICustomerRepository _customerRepository;
    //private readonly IFixture _fixture = new Fixture();

    //public GetCustomerAccountDetailsQueryTest(ICustomerRepository customerRepository)
    //{
    //    _customerRepository = customerRepository;
    //    _mediator = Substitute.For<IMediator>();
    //}

    //[Fact]
    //public async Task Handle_return_creditRating_for_given_customer_test()
    //{
    //    var handler = new GetCustomerAccountDetailsQueryHandler(_customerRepository);

    //    var query = new GetCustomerAccountDetailsQuery("Anne");
    //    var result = await handler.Handle(query, CancellationToken.None);

    //    // Assert
    //    result.Should().NotBeNull();
    //    result.CreditRating.Should().Be(80);
    //}
}
