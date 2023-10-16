using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Business.Classes;
public class BookingProcessor
{
    readonly IData _db;
    public bool AddCustomerButtonWasClicked { get; private set; }
    public bool AddVehicleButtonWasClicked { get; private set; }
    public BookingProcessor(IData db) => _db = db;
    public List<Vehicle> GetVehicles() => _db.GetVehicles();
    public List<Vehicle> GetVehicles(VehicleStatuses status) => _db.GetVehicles(status);
    public List<IPerson> GetCustomers() => _db.GetCustomers();
    public List<IBooking> GetBookings() => _db.GetBookings();
    public static List<String> GetCustomerFormErrors(IPerson form) => Validation.GetCustomerFormErrors(form);
    public static List<String> GetVehicleFormErrors(Vehicle form) => Validation.GetVehicleFormErrors(form);
    public void OnAddCustomerSubmit(IPerson form)
    {
        if (Validation.GetCustomerFormErrors(form).Count > 0)
        {
            AddCustomerButtonWasClicked = true;
            return;
        }
        _db.AddCustomer(form.SSN.Length > 0 ? form.SSN : throw new ArgumentException(nameof(form.SSN)),
                        form.LastName.Length > 0 ? form.LastName : throw new ArgumentException(nameof(form.LastName)),
                        form.FirstName.Length > 0 ? form.FirstName : throw new ArgumentException(nameof(form.FirstName)));
        AddCustomerButtonWasClicked = false;
    }
    public void OnAddVehicleSubmit(Vehicle form)
    {
        if (Validation.GetVehicleFormErrors(form).Count > 0)
        {
            AddVehicleButtonWasClicked = true;
            return;
        }
        _db.AddVehicle(form.RegNo.Length > 0 ? form.RegNo : throw new ArgumentException(nameof(form.Odometer)),
                       form.Make.Length > 0 ? form.Make : throw new ArgumentException(nameof(form.Make)),
                       form.Odometer > 0 ? form.Odometer : throw new ArgumentException(nameof(form.Odometer)),
                       form.CostKm > 0 ? form.CostKm : throw new ArgumentException(nameof(form.CostKm)),
                       form.Type,
                       form.CostDay > 0 ? form.CostDay : throw new ArgumentException(nameof(form.CostDay)));
        AddVehicleButtonWasClicked = false;
    }
}