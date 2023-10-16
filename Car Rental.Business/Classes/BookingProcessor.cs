using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Business.Classes;
public class BookingProcessor
{
    readonly IData _db;
    public AddVehicleForm AddVehicleForm = new();
    public bool AddCustomerButtonWasClicked { get; private set; }
    public bool AddVehicleButtonWasClicked { get; private set; }
    public BookingProcessor(IData db) => _db = db;
    public List<IVehicle> GetVehicles() => _db.GetVehicles();
    public List<IVehicle> GetVehicles(VehicleStatuses status) => _db.GetVehicles(status);
    public List<IPerson> GetCustomers() => _db.GetCustomers();
    public List<IBooking> GetBookings() => _db.GetBookings();
    public static List<String> GetCustomerFormErrors(IPerson form) => Validation.GetCustomerFormErrors(form);
    public static List<String> GetVehicleFormErrors(IVehicle form) => Validation.GetVehicleFormErrors(form);
    public void OnAddCustomerSubmit(IPerson form)
    {
        if (Validation.GetCustomerFormErrors(form).Count > 0)
        {
            AddCustomerButtonWasClicked = true;
            return;
        }
        _db.AddCustomer(form.SSN.Length > 0 ? form.SSN : throw new ArgumentException(nameof(form.SSN)),
                        form.LastName ?? throw new ArgumentException(nameof(form.LastName)),
                        form.FirstName ?? throw new ArgumentException(nameof(form.FirstName)))
        ;
        AddCustomerButtonWasClicked = false;
    }
    public void OnAddVehicleSubmit()
    {
        AddVehicleForm form = AddVehicleForm;
        if (form.GetValidationErrors().Count > 0)
        {
            AddVehicleButtonWasClicked = true;
            return;
        }
        _db.AddVehicle(form.RegNo ?? throw new ArgumentNullException(nameof(form.Odometer)),
                       form.Make ?? throw new ArgumentNullException(nameof(form.Make)),
                       form.Odometer ?? throw new ArgumentNullException(nameof(form.Odometer)),
                       form.CostKm ?? throw new ArgumentNullException(nameof(form.CostKm)),
                       form.Type ?? throw new ArgumentNullException(nameof(form.Type)),
                       form.CostDay ?? throw new ArgumentNullException(nameof(form.CostDay)));
        AddVehicleButtonWasClicked = false;
    }
}