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
    public string? RentingCustomerSSN;
    public bool Processing;
    public bool AddCustomerButtonWasClicked { get; private set; }
    public bool AddVehicleButtonWasClicked { get; private set; }
    public List<String> CustomerFormErrors => CustomerForm.GetErrors();
    public List<String> VehicleFormErrors => VehicleForm.GetErrors();
    public string[] VehicleStatusNames => _db.VehicleStatusNames;
    public string[] VehicleTypeNames => _db.VehicleTypeNames;
    public T? Single<T>(Expression<Func<T, bool>> expression) where T : class => _db.Single(expression);
    public IEnumerable<T> Get<T>(Expression<Func<T, bool>>? expression = null) where T : class => _db.Get(expression);
    //public IBooking? GetBooking(Expression<Func<IBooking, bool>> expression) => _db.Single(expression);
    //public Vehicle? GetVehicle(Expression<Func<Vehicle, bool>> expression) => _db.Single(expression);
    //public IEnumerable<IBooking> GetBookings() => _db.Get<IBooking>();
    //public IPerson? GetPerson(string ssn) => _db.Single<IPerson>(c => c.SSN == ssn);
    //public IEnumerable<IPerson> GetPersons() => _db.Get<IPerson>();
    //public IEnumerable<Vehicle> GetVehicles(VehicleStatuses? status = null) =>
    //status is null ? _db.Get<Vehicle>() : _db.Get<Vehicle>(v => v.Status == status);
    public void AddCustomer()
    {
        Customer form = CustomerForm;
        if (CustomerForm.GetErrors().Count > 0)
        {
            AddCustomerButtonWasClicked = true;
            return;
        }
        Customer customer = new Customer(_db.NextPersonId,
                                        form.SSN.Length > 0 ? form.SSN : throw new ArgumentException(nameof(form.SSN)),
                                        form.LastName.Length > 0 ? form.LastName : throw new ArgumentException(nameof(form.LastName)),
                                        form.FirstName.Length > 0 ? form.FirstName : throw new ArgumentException(nameof(form.FirstName)));
        _db.Add<Customer>(customer);
        AddCustomerButtonWasClicked = false;
    }
    public void AddVehicle()
    {
        Vehicle form = VehicleForm;
        if (VehicleForm.GetErrors().Count > 0)
        {
            AddVehicleButtonWasClicked = true;
            return;
        }
        //_db.AddVehicle(form.RegNo.Length > 0 ? form.RegNo : throw new ArgumentException(nameof(form.Odometer)),
        //               form.Make.Length > 0 ? form.Make : throw new ArgumentException(nameof(form.Make)),
        //               form.Odometer > 0 ? form.Odometer : throw new ArgumentException(nameof(form.Odometer)),
        //               form.CostKm > 0 ? form.CostKm : throw new ArgumentException(nameof(form.CostKm)),
        //               form.Type ?? throw new ArgumentNullException(nameof(form.Type)),
        //               form.CostDay > 0 ? form.CostDay : throw new ArgumentException(nameof(form.CostDay)));
        AddVehicleButtonWasClicked = false;
    }
    public async Task RentVehicle(Vehicle vehicle, string customerSSN)
    {
        //IPerson customer = _db.GetCustomer(customerSSN) ?? throw new ArgumentException("Didn't find a customer with the provided SSN.");
        Processing = true;
        await Task.Delay(2000);
        Processing = false;
        //_db.AddBooking(vehicle, customer);
    }
    public void ReturnVehicle(IBooking booking) => booking.ReturnVehicle();
}