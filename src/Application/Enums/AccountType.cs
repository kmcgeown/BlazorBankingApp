

namespace Application.Enums;

public enum AccountType
{
    [Display(Name = "Current Account")]
    Current,
    [Display(Name = "Savings Account")]
    Savings,
    [Display(Name = "Loan Account")]
    Loan,
    [Display(Name = "ISA Account")]
    ISA
}
