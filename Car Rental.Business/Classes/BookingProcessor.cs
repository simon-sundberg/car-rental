using Car_Rental.Common.Classes;
using Car_Rental.Common.Error;
using Car_Rental.Common.Extensions;
using Car_Rental.Data.Interfaces;
using System.Linq.Expressions;

namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    public Customer CustomerForm = new();
    public bool Processing;
    public int? RentingCustomerId;
    public Vehicle VehicleForm = new();
    private readonly IData _db;
    private readonly ErrorTracker _et;

    public BookingProcessor(IData db, ErrorTracker et)
    {
        _db = db;
        _et = et;
    }

    public string[] VehicleStatusNames => _db.VehicleStatusNames;
    public string[] VehicleTypeNames => _db.VehicleTypeNames;

    public void AddCustomer() => _db.AddCustomer(CustomerForm);

    public void AddVehicle() => _db.AddVehicle(VehicleForm);

    public IEnumerable<T> Get<T>(Expression<Func<T, bool>>? expression = null)
        where T : class => _db.Get(expression);

    public async Task RentVehicle(int vehicleId, int customerId)
    {
        Processing = true;
        await Task.Delay(10000);
        Processing = false;
        _db.RentVehicle(vehicleId, customerId);
    }

    public void ReturnVehicle(int vehicleId) => _db.ReturnVehicle(vehicleId);

    public T? Single<T>(Expression<Func<T, bool>> expression)
        where T : class => _db.Single(expression);
}
