using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System.Linq.Expressions;

namespace Car_Rental.Data.Interfaces;

public interface IData
{
    int NextBookingId { get; }

    int NextPersonId { get; }

    int NextVehicleId { get; }

    string[] VehicleStatusNames => Enum.GetNames(typeof(VehicleStatuses));

    string[] VehicleTypeNames => Enum.GetNames(typeof(VehicleTypes));

    void Add<T>(T item)
        where T : class;

    void AddCustomer(IPerson form);

    void AddVehicle(Vehicle form);

    IEnumerable<T> Get<T>(Expression<Func<T, bool>>? expression = null)
        where T : class;

    void RentVehicle(int vehicleId, int customerId);

    void ReturnVehicle(int vehicleId);

    T? Single<T>(Expression<Func<T, bool>> expression)
        where T : class;
}
