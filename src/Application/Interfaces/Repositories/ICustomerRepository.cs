
using Application.Models;

namespace Application.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<CustomerDetails> AuthenicateUser(AuthCustomer authCustomer);
        Task<CustomerDetails> GetCustomerAccountDetails(string customerName);
        Task<bool> UpdateCustomerAccount(CustomerDetails customerDetails);
    }
}
