using Car_Rental.Common.Classes;

namespace Car_Rental.Common.Interfaces;

public interface IBooking
{
    int Id { get; init; }
    Vehicle Vehicle { get; init; }
    IPerson Customer { get; init; }
    int KmRented { get; init; }
    int? KmReturned { get; set; }
    DateTime DateRented { get; init; }
    DateTime? DateReturned { get; set; }
    double? Cost { get; set; }
    void ReturnVehicle(int kmReturned, DateTime dateReturned);
}
