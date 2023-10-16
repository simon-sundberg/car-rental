using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Customer : IPerson
{
    public int Id { get; set; }
    public string SSN { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }

    public Customer()
    {
        Id = -1;
        SSN = string.Empty;
        LastName = string.Empty;
        FirstName = string.Empty;
    }
    public Customer(int id, string ssn, string lastName, string firstName)
    {
        Id = id;
        SSN = ssn;
        LastName = lastName;
        FirstName = firstName;
    }
}
