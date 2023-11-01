using Car_Rental.Common.Error;
using Car_Rental.Common.Interfaces;
using static Car_Rental.Common.Error.ErrorTypes;

namespace Car_Rental.Common.Extensions;

public static class CustomerExtensions
{
    public static void CheckErrors(this IPerson customer, ErrorTracker eh)
    {
        eh.InactivateErrors(ErrorSources.AddCustomerForm);
        string cleanedSSN = customer.SSN.Replace(" ", "").Replace("-", "");
        if (cleanedSSN.Length != 5 || !double.TryParse(cleanedSSN, out _))
            eh.ActivateError(CUSTOMER_SSN_NOT_5_DIGITS);
        if (!(customer.LastName?.Length > 0))
            eh.ActivateError(CUSTOMER_LAST_NAME_EMPTY);
        if (!(customer.FirstName?.Length > 0))
            eh.ActivateError(CUSTOMER_FIRST_NAME_EMPTY);
    }
}
