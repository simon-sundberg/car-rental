using Car_Rental.Common.Classes;

namespace Car_Rental.Common.Interfaces;

public interface IBooking
{
    int Id { get; init; }
    int VehicleId { get; init; }
    int CustomerId { get; init; }
    int KmRented { get; init; }
    int? KmDistance { get; set; }
    int? KmReturned { get; }
    DateOnly DateRented { get; init; }
    DateOnly? DateReturned { get; }
    double? Cost { get; }

    void ReturnVehicle(Vehicle vehicle);
}
