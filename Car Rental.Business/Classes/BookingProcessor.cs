using Car_Rental.Common.Classes;
using Car_Rental.Common.Extensions;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;
using System.Linq.Expressions;

namespace Car_Rental.Business.Classes;
public class BookingProcessor
{
    readonly IData _db;
    public BookingProcessor(IData db) => _db = db;
    public Customer CustomerForm = new();
    public Vehicle VehicleForm = new();
    public int? RentingCustomerId;
    public bool Processing;
    public bool AddCustomerButtonWasClicked { get; private set; }
    public bool AddVehicleButtonWasClicked { get; private set; }
    public List<String> CustomerFormErrors => CustomerForm.GetErrors();
    public List<String> VehicleFormErrors => VehicleForm.GetErrors();
    public string[] VehicleStatusNames => _db.VehicleStatusNames;
    public string[] VehicleTypeNames => _db.VehicleTypeNames;
    public T? Single<T>(Expression<Func<T, bool>> expression) where T : class => _db.Single(expression);
    public IEnumerable<T> Get<T>(Expression<Func<T, bool>>? expression = null) where T : class => _db.Get(expression);
    public void AddCustomer()
    {
        if (CustomerForm.GetErrors().Count > 0)
        {
            AddCustomerButtonWasClicked = true;
            return;
        }
        _db.AddCustomer(CustomerForm);
        AddCustomerButtonWasClicked = false;
    }
    public void AddVehicle()
    {
        if (VehicleForm.GetErrors().Count > 0)
        {
            AddVehicleButtonWasClicked = true;
            return;
        }
        _db.AddVehicle(VehicleForm);
        AddVehicleButtonWasClicked = false;
    }
    public async Task RentVehicle(int vehicleId, int customerId)
    {
        Processing = true;
        await Task.Delay(2000);
        Processing = false;
        _db.RentVehicle(vehicleId, customerId);
    }
    public void ReturnVehicle(int vehicleId) => _db.ReturnVehicle(vehicleId);
}