using Car_Rental.Common.Interfaces;

namespace Car_Rental.Data.Interfaces;
public interface IData
{
    public List<IVehicle> GetVehicles();
    public List<IVehicle> GetVehicles(VehicleStatuses status);
    public List<IPerson> GetCustomers();
    public List<IBooking> GetBookings();
}
