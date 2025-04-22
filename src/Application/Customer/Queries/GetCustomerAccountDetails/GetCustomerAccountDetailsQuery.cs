using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace Application.Customer.Queries.GetCustomerAccountDetails;

public record GetCustomerAccountDetailsQuery(string CustomerName) : IRequest<CustomerDetails>;

public class GetCustomerAccountDetailsQueryHandler
    : IRequestHandler<GetCustomerAccountDetailsQuery, CustomerDetails>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ILogger<GetCustomerAccountDetailsQueryHandler> _logger;

    public GetCustomerAccountDetailsQueryHandler(
        ICustomerRepository customerRepository,
        ILogger<GetCustomerAccountDetailsQueryHandler> logger
    )
    {
        _customerRepository = customerRepository;
        _logger = logger;
    }

    public async Task<CustomerDetails> Handle(
        GetCustomerAccountDetailsQuery query,
        CancellationToken cancellationToken
    )
    {
        _logger.LogInformation(query.CustomerName, JsonSerializer.Serialize(query.CustomerName));

        return await _customerRepository.GetCustomerAccountDetails(query.CustomerName);
    }
}
