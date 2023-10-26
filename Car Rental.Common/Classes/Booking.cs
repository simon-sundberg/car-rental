using Car_Rental.Common.Enums;
using Car_Rental.Common.Extensions;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{
    public int Id { get; init; }
    public int VehicleId { get; init; }
    public int CustomerId { get; init; }
    public int KmRented { get; init; }
    public DateOnly DateRented { get; init; }
    public int? KmDistance { get; set; }
    public int? KmReturned { get; private set; }
    public DateOnly? DateReturned { get; private set; }
    public double? Cost { get; private set; }
    public Booking(int id, int vehicleId, int customerId, int kmRented)
    {
        Id = id;
        VehicleId = vehicleId;
        CustomerId = customerId;
        KmRented = kmRented;
        DateRented = DateOnly.FromDateTime(DateTime.Today);
    }
    public void ReturnVehicle(Vehicle vehicle)
    {
        int kmDistance = KmDistance ?? throw new InvalidOperationException("Distance input value was null when returning vehicle.");
        if (kmDistance < 0)
            throw new InvalidOperationException("Distance input value was negative when returning vehicle.");
        DateOnly date = DateOnly.FromDateTime(DateTime.Today);
        int days = date.Duration(DateRented) + 1;
        Cost = days * vehicle.CostDay + kmDistance * vehicle.CostKm;
        DateReturned = date;
        KmReturned = KmRented + kmDistance;
        vehicle.Status = VehicleStatuses.Available;
        vehicle.Odometer += kmDistance;
        vehicle.BookingId = null;
        KmDistance = null;
    }
}
