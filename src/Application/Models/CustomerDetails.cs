﻿
namespace Application.Models;

public class CustomerDetails
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int CreditRating { get; set; }
    public List<Account> Accounts { get; set; } = new List<Account>();
}
