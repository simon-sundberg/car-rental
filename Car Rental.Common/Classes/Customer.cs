using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Customer : IPerson
{
    public int Id { get; init; }
    public string SSN { get; init; }
    public string LastName { get; set; }
    public string FirstName { get; set; }

    public Customer(int id, string ssn, string lastName, string firstName)
    {
        Id = id;
        SSN = ssn;
        LastName = lastName;
        FirstName = firstName;
    }
}
