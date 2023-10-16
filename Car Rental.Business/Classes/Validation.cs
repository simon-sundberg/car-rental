using Car_Rental.Common.Interfaces;

namespace Car_Rental.Business.Classes;

internal static class Validation
{
    internal static List<string> GetCustomerFormErrors(IPerson form)
    {
        List<string> errors = new();
        string cleanedSSN = form.SSN.Replace(" ", "").Replace("-", "");
        if (cleanedSSN.Length != 12 || !double.TryParse(cleanedSSN, out _))
            errors.Add("SSN must contain 12 digits");
        if (!(form.LastName?.Length > 0))
            errors.Add("Last Name is required");
        if (!(form.FirstName?.Length > 0))
            errors.Add("First Name is required");
        return errors;
    }
    internal static List<string> GetVehicleFormErrors(IVehicle form)
    {
        List<string> errors = new();
        if (form.RegNo?.Length != 6)
            errors.Add("RegNo must be 6 characters long");
        if (!(form.Make?.Length > 0))
            errors.Add("Make is required");
        if (!(form.Odometer >= 0))
            errors.Add("Odometer must be a positive number");
        if (!(form.CostKm >= 0))
            errors.Add("Cost / Km must be a positive number");
        if (!(form.CostDay >= 0))
            errors.Add("Cost / Day must be a positive number");
        return errors;
    }
}
