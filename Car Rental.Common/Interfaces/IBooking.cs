using Car_Rental.Common.Classes;

namespace Car_Rental.Common.Interfaces;

public interface IBooking
{
    int Id { get; init; }
    Vehicle Vehicle { get; init; }
    IPerson Customer { get; init; }
    int KmRented { get; init; }
    int? KmDistance { get; set; }
    int? KmReturned { get; }
    DateOnly DateRented { get; init; }
    DateOnly? DateReturned { get; set; }
    double? Cost { get; set; }
    void ReturnVehicle();
}
