namespace Application.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<CustomerDetails> AuthenicateUser(AuthCustomer authCustomer);
        Task<CustomerDetails> GetCustomerAccountDetails(string customerName);
        Task<bool> CreateNewCustomerAccount(Account account, int customerId);
    }
}
