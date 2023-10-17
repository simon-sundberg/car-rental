using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Data.Interfaces;
public interface IData
{
    Vehicle? GetVehicle(string regNo);
    List<Vehicle> GetVehicles();
    List<Vehicle> GetVehicles(VehicleStatuses status);
    IPerson? GetCustomer(string ssn);
    List<IPerson> GetCustomers();
    IBooking? GetBooking(string regNo);
    List<IBooking> GetBookings();
    string[] VehicleStatusNames => Enum.GetNames(typeof(VehicleStatuses));
    string[] VehicleTypeNames => Enum.GetNames(typeof(VehicleTypes));
    void AddBooking(Vehicle vehicle, IPerson customer);
    void AddCustomer(string ssn, string lastName, string firstName);
    void AddVehicle(string regNo, string make, int odometer, double costKm, VehicleTypes type, double costDay);
}
