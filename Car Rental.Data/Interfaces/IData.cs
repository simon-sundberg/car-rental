using Car_Rental.Common.Interfaces;

namespace Car_Rental.Data.Interfaces;
public interface IData
{
    List<IVehicle> GetVehicles();
    List<IVehicle> GetVehicles(VehicleStatuses status);
    List<IPerson> GetCustomers();
    List<IBooking> GetBookings();
}
