namespace Car_Rental.Common.Interfaces;

public interface IPerson
{
    int Id { get; set; }
    string SSN { get; set; }
    string LastName { get; set; }
    string FirstName { get; set; }
}
