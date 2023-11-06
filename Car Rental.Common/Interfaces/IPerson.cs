namespace Car_Rental.Common.Interfaces;

public interface IPerson
{
    string FirstName { get; set; }
    int Id { get; init; }
    string LastName { get; set; }
    string SSN { get; set; }
}
