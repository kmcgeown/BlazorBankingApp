namespace Application.Customer.Queries.GetCustomerAccountDetails;

public record GetCustomerAccountDetailsQuery(string CustomerName) : IRequest<CustomerDetails>;

public class GetCustomerAccountDetailsQueryHandler
    : IRequestHandler<GetCustomerAccountDetailsQuery, CustomerDetails>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerAccountDetailsQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CustomerDetails> Handle(
        GetCustomerAccountDetailsQuery query,
        CancellationToken cancellationToken
    )
    {
        return await _customerRepository.GetCustomerAccountDetails(query.CustomerName);
    }
}
