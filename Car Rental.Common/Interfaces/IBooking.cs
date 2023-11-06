using Car_Rental.Common.Classes;

namespace Car_Rental.Common.Interfaces;

public interface IBooking
{
    double? Cost { get; }
    int CustomerId { get; init; }
    DateOnly DateRented { get; init; }
    DateOnly? DateReturned { get; }
    int Id { get; init; }
    int? KmDistance { get; set; }
    int KmRented { get; init; }
    int? KmReturned { get; }
    int VehicleId { get; init; }
    void ReturnVehicle(Vehicle vehicle);
}
