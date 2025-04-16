// <summary>
/// Assume data is coming from database.
/// </summary>
using Application.Enums;
using Application.Interfaces.Repositories;
using Application.Models;

namespace Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    public Task<CustomerDetails> AuthenicateUser(AuthCustomer authCustomer)
    {
        var random = new Random();
        var customerDetails = new CustomerDetails();
        if (authCustomer != null)
        {
            customerDetails.Name = authCustomer.Name;
            customerDetails.CreditRating =
                authCustomer.Name == "Bob" ? 15
                : authCustomer.Name == "Jim" ? 45
                : authCustomer.Name == "Jim" ? 80
                : 0;
            customerDetails.CustomerId = random.Next(10000, 19999);
        }

        return Task.FromResult(customerDetails);
    }

    public Task<CustomerDetails> GetCustomerAccountDetails(string customerName)
    {
        var random = new Random();
        var customerDetails = new CustomerDetails();

        if (!string.IsNullOrEmpty(customerName))
        {
            string lowerCaseName = customerName.ToLowerInvariant();
            int creditRating = lowerCaseName switch
            {
                "bob" => 15,
                "jim" => 45,
                "anne" => 80,
                _ => random.Next(0, 100),
            };

            customerDetails = new CustomerDetails
            {
                Name = customerName,
                CreditRating = creditRating,
                CustomerId = random.Next(10000, 19999),
            };
        }
        var result = GenerateRandomAccounts(customerDetails);

        return result;
    }

    public Task<bool> CreateNewCustomerAccount(Account account, int customerId)
    {
        //Fake DB update
        return Task.FromResult(true);
    }

    private Task<CustomerDetails> GenerateRandomAccounts(CustomerDetails customerDetails)
    {
        var random = new Random();
        decimal minBalance = 0.00m;
        decimal maxBalance = 50000.00m;
        customerDetails.Accounts ??= new List<Account>();
        var accountTypes = Enum.GetValues(typeof(AccountType)).Cast<AccountType>().ToArray();
        for (int i = 0; i < accountTypes.Length; i++)
        {
            AccountType randomType = accountTypes[random.Next(0, accountTypes.Length)];
            double randomFraction = random.NextDouble();
            decimal range = maxBalance - minBalance;
            decimal randomBalanceOffset = (decimal)(randomFraction * (double)range);
            decimal randomBalance = minBalance + randomBalanceOffset;
            randomBalance =
                randomType == AccountType.Loan
                    ? Math.Round((decimal)random.NextDouble() * 10000, 2)
                    : Math.Round(randomBalance, 2);
            decimal randomOutStandingBalance =
                randomType == AccountType.Loan
                    ? Math.Round((decimal)random.NextDouble() * 10000, 2)
                    : minBalance;
            int randomAccountId = random.Next(100000, 999999);

            var newAccount = new Account
            {
                AccountId = randomAccountId,
                Type = randomType,
                Balance = randomBalance,
                OutstandingBalance = randomOutStandingBalance,
                Status = AccountStatus.Open,
            };

            customerDetails.Accounts.Add(newAccount);
        }
        return Task.FromResult(customerDetails);
    }
}
