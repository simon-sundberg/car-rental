using Car_Rental.Common.Enums;
using Car_Rental.Common.Extensions;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{
    public Booking(int id, int vehicleId, int customerId, int kmRented)
    {
        Id = id;
        VehicleId = vehicleId;
        CustomerId = customerId;
        KmRented = kmRented;
        DateRented = DateOnly.FromDateTime(DateTime.Today);
    }

    public double? Cost { get; private set; }
    public int CustomerId { get; init; }
    public DateOnly DateRented { get; init; }
    public DateOnly? DateReturned { get; private set; }
    public int Id { get; init; }
    public int? KmDistance { get; set; }
    public int KmRented { get; init; }
    public int? KmReturned { get; private set; }
    public int VehicleId { get; init; }

    public void ReturnVehicle(Vehicle vehicle)
    {
        if (KmDistance is null || KmDistance < 0)
            throw new NullReferenceException("Distance input value is null or negative.");

        int kmDistance = (int)KmDistance;
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
