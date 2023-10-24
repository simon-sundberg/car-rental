using System.Linq.Expressions;

namespace Car_Rental.Data.Interfaces;
public interface IData
{
    /*
        Vehicle? GetVehicle(string regNo);
        List<Vehicle> GetVehicles();
        List<Vehicle> GetVehicles(VehicleStatuses status);
        IPerson? GetCustomer(string ssn);
        List<IPerson> GetCustomers();
        IBooking? GetBooking(string regNo);
        List<IBooking> GetBookings();
        void AddBooking(Vehicle vehicle, IPerson customer);
        void AddCustomer(string ssn, string lastName, string firstName);
        void AddVehicle(string regNo, string make, int odometer, double costKm, VehicleTypes type, double costDay);
    */

    T? Single<T>(Expression<Func<T, bool>> expression) where T : class;
    IEnumerable<T> Get<T>(Expression<Func<T, bool>>? expression = null) where T : class;
    void Add<T>(T item) where T : class;
    int NextBookingId { get; }
    int NextPersonId { get; }
    int NextVehicleId { get; }
    string[] VehicleStatusNames => Enum.GetNames(typeof(VehicleStatuses));
    string[] VehicleTypeNames => Enum.GetNames(typeof(VehicleTypes));
}
