using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Business.Classes;
public class BookingProcessor
{
    readonly IData _db;
    public AddVehicleForm AddVehicleForm = new();
    public AddCustomerForm AddCustomerForm = new();
    public bool AddCustomerButtonWasClicked { get; private set; }
    public bool AddVehicleButtonWasClicked { get; private set; }
    public BookingProcessor(IData db) => _db = db;
    public List<IVehicle> GetVehicles() => _db.GetVehicles();
    public List<IVehicle> GetVehicles(VehicleStatuses status) => _db.GetVehicles(status);
    public List<IPerson> GetCustomers() => _db.GetCustomers();
    public List<IBooking> GetBookings() => _db.GetBookings();
    public void OnAddCustomerSubmit()
    {
        AddCustomerForm form = AddCustomerForm;
        if (form.GetValidationErrors().Count > 0)
        {
            AddCustomerButtonWasClicked = true;
            return;
        }
        _db.AddCustomer(Convert.ToDouble(form.SSN),
                        form.LastName ?? throw new ArgumentNullException(nameof(form.LastName)),
                        form.FirstName ?? throw new ArgumentNullException(nameof(form.FirstName)));
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