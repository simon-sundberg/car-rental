namespace Car_Rental.Common.Interfaces;

public interface IPerson
{
    int Id { get; init; }
    string SSN { get; set; }
    string LastName { get; set; }
    string FirstName { get; set; }
}
