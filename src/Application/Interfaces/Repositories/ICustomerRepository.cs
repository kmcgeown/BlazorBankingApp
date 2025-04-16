namespace Application.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<CustomerDetails> AuthenicateUser(AuthCustomer authCustomer);
        Task<CustomerDetails> GetCustomerAccountDetails(string customerName);
        Task<bool> UpdateCustomerAccount(Account account, int customerId);
    }
}
