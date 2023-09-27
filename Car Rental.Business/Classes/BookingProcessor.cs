using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Business.Classes;
public class BookingProcessor
{
    readonly List<IVehicle> _vehicles;
    readonly List<IPerson> _customers;
    readonly List<IBooking> _bookings;
    public List<IVehicle> GetVehicles() => _vehicles;
    public List<IPerson> GetCustomers() => _customers;
    public List<IBooking> GetBookings() => _bookings;

    public BookingProcessor(IData data)
    {
        _vehicles = data.GetVehicles();
        _customers = data.GetCustomers();
        _bookings = data.GetBookings();
    }

}
