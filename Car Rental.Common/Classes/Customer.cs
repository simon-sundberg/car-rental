using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Customer : IPerson
{
    public string SSN { get; init; }
    public string LastName { get; set; }
    public string FirstName { get; set; }

    public Customer(string ssn, string lastName, string firstName)
    {
        SSN = ssn;
        LastName = lastName;
        FirstName = firstName;
    }
}
