using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Business.Classes;
public class BookingProcessor
{
    readonly IData _db;
    public AddVehicleForm AddVehicleForm = new();
    public bool AddVehicleButtonWasClicked { get; private set; }
    public BookingProcessor(IData db) => _db = db;
    public List<IVehicle> GetVehicles() => _db.GetVehicles();
    public List<IVehicle> GetVehicles(VehicleStatuses status) => _db.GetVehicles(status);
    public List<IPerson> GetCustomers() => _db.GetCustomers();
    public List<IBooking> GetBookings() => _db.GetBookings();
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