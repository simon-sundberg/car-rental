using Car_Rental.Common.Classes;
using Car_Rental.Common.Error;
using Car_Rental.Common.Extensions;
using Car_Rental.Data.Interfaces;
using System.Linq.Expressions;

namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    readonly IData _db;
    readonly ErrorTracker _et;

    public BookingProcessor(IData db, ErrorTracker et)
    {
        _db = db;
        _et = et;
    }

    public Customer CustomerForm = new();
    public Vehicle VehicleForm = new();
    public int? RentingCustomerId;
    public bool Processing;
    public string[] VehicleStatusNames => _db.VehicleStatusNames;
    public string[] VehicleTypeNames => _db.VehicleTypeNames;

    public T? Single<T>(Expression<Func<T, bool>> expression)
        where T : class => _db.Single(expression);

    public IEnumerable<T> Get<T>(Expression<Func<T, bool>>? expression = null)
        where T : class => _db.Get(expression);

    public void AddCustomer()
    {
        CustomerForm.CheckErrors(_et);
        List<Error> errors = _et.GetErrors(
            e => e.Active && e.Source == ErrorSources.AddCustomerForm
        );
        if (errors.Count == 0)
            _db.AddCustomer(CustomerForm);
    }

    public void AddVehicle()
    {
        VehicleForm.CheckErrors(_et);
        List<Error> errors = _et.GetErrors(
            e => e.Active && e.Source == ErrorSources.AddVehicleForm
        );
        if (errors.Count == 0)
            _db.AddVehicle(VehicleForm);
    }

    public async Task RentVehicle(int vehicleId, int customerId)
    {
        Processing = true;
        await Task.Delay(10000);
        Processing = false;
        _db.RentVehicle(vehicleId, customerId);
    }

    public void ReturnVehicle(int vehicleId)
    {
        _db.ReturnVehicle(vehicleId);
    }
}
