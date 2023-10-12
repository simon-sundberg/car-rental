namespace Car_Rental.Business.Classes;

public class AddCustomerForm
{
    public string? SSN { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public List<string> GetValidationErrors()
    {
        List<string> errors = new();
        bool ssnIsNumeric = double.TryParse(SSN, out _);
        bool ssnIsTenOrTwelveCharactersLong = SSN?.ToString().Length == 10 || SSN?.ToString().Length == 12;
        if (!ssnIsNumeric || !ssnIsTenOrTwelveCharactersLong)
            errors.Add("SSN must consist of 10 or 12 numbers (without dashes or spaces)");
        if (!(LastName?.Length > 0))
            errors.Add("Last Name is required");
        if (!(FirstName?.Length > 0))
            errors.Add("First Name is required");
        return errors;
    }
}
