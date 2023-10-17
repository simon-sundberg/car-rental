using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Extensions;

public static class CustomerExtensions
{
    public static List<string> GetErrors(this IPerson customer)
    {
        List<string> errors = new();
        string cleanedSSN = customer.SSN.Replace(" ", "").Replace("-", "");
        if (cleanedSSN.Length != 12 || !double.TryParse(cleanedSSN, out _))
            errors.Add("SSN must contain 12 digits");
        if (!(customer.LastName?.Length > 0))
            errors.Add("Last Name is required");
        if (!(customer.FirstName?.Length > 0))
            errors.Add("First Name is required");
        return errors;
    }
}
