using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Customer : IPerson
{
    public Customer() => Id = -1;

    public Customer(int id, string ssn, string lastName, string firstName) =>
        (Id, SSN, LastName, FirstName) = (id, ssn, lastName, firstName);

    public string FirstName { get; set; } = string.Empty;
    public int Id { get; init; }
    public string LastName { get; set; } = string.Empty;
    public string SSN { get; set; } = string.Empty;
}
