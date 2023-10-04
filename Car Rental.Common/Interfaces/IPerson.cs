namespace Car_Rental.Common.Interfaces;

public interface IPerson
{
    int Id { get; init; }
    string SSN { get; init; }
    string LastName { get; set; }
    string FirstName { get; set; }
}
