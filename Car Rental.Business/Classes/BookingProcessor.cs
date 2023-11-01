using Car_Rental.Common.Classes;
using Car_Rental.Common.Error;
using Car_Rental.Common.Extensions;
using Car_Rental.Common.Interfaces;
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
    public bool DisplayCustomerDatabaseErrors { get; private set; }
    public bool DisplayCustomerFormErrors { get; private set; }
    public bool DisplayVehicleDatabaseErrors { get; private set; }
    public bool DisplayVehicleFormErrors { get; private set; }

    //public void DetermineErrorDisplay()
    //{
    //DisplayCustomerDatabaseErrors = DatabaseErrors.Count > 0;
    //DisplayCustomerFormErrors = CustomerFormErrors.Count > 0;
    //DisplayVehicleErrors = VehicleFormErrors.Count > 0 || DatabaseErrors.Count > 0;
    //}

    //public List<string> CustomerFormErrors => CustomerForm.GetErrors();
    //public List<string> VehicleFormErrors => VehicleForm.GetErrors();
    //public ErrorTracker DatabaseErrors => _db.Errors;
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
        await Task.Delay(2000);
        Processing = false;
        _db.RentVehicle(vehicleId, customerId);
    }

    public void ReturnVehicle(int vehicleId)
    {
        _db.ReturnVehicle(vehicleId);
    }
}
