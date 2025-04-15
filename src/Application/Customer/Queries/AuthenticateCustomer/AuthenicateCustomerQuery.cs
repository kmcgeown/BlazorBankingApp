

namespace Application.Customer.Queries.AuthenticateCustomer;

public record AuthenicateCustomerQuery(AuthCustomer authCustomer) : IRequest<CustomerDetails>;

public class AuthenicateCustomerQueryHandler : IRequestHandler<AuthenicateCustomerQuery, CustomerDetails>
{
    private readonly ICustomerRepository _customerRepository;

    public AuthenicateCustomerQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;   
    }

    public async Task<CustomerDetails> Handle(AuthenicateCustomerQuery query, CancellationToken cancellationToken)
    {
        return await _customerRepository.AuthenicateUser(query.authCustomer);
    }

}
