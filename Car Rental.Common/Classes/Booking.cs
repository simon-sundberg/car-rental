using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{
    public int Id { get; init; }
    public IVehicle Vehicle { get; init; }
    public IPerson Customer { get; init; }
    public int KmRented { get; init; }
    public int? KmReturned { get; set; }
    public DateTime DateRented { get; init; }
    public DateTime? DateReturned { get; set; }
    public double? Cost { get; set; }
    public Booking(int id, IVehicle vehicle, IPerson customer, int kmRented, DateTime dateRented)
    {
        Id = id;
        Vehicle = vehicle;
        Customer = customer;
        KmRented = kmRented;
        DateRented = dateRented;
    }
    public void ReturnVehicle(int kmReturned, DateTime dateReturned)
    {
        KmReturned = kmReturned;
        DateReturned = dateReturned;

        int km = kmReturned - KmRented;
        int days = DateTime.Compare(DateRented, dateReturned) + 1;
        Cost = days * Vehicle.CostDay + km * Vehicle.CostKm;
    }
}
