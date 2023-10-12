using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Business.Classes;
public class BookingProcessor
{
    readonly IData _db;
    public AddVehicleForm AddVehicleData = new();
    public BookingProcessor(IData db) => _db = db;
    public List<IVehicle> GetVehicles() => _db.GetVehicles();
    public List<IVehicle> GetVehicles(VehicleStatuses status) => _db.GetVehicles(status);
    public List<IPerson> GetCustomers() => _db.GetCustomers();
    public List<IBooking> GetBookings() => _db.GetBookings();

    public bool DisplayAddVehicleErrors { get; private set; } = false;
    public void OnAddVehicleSubmit()
    {
        var data = AddVehicleData;
        if (GetAddVehicleFormErrors().Count == 0)
        {
            _db.AddVehicle(
                data.RegNo ?? throw new ArgumentNullException(nameof(data.Odometer)),
                data.Make ?? throw new ArgumentNullException(nameof(data.Make)),
                data.Odometer ?? throw new ArgumentNullException(nameof(data.Odometer)),
                data.CostKm ?? throw new ArgumentNullException(nameof(data.CostKm)),
                data.Type ?? throw new ArgumentNullException(nameof(data.Type)),
                data.CostDay ?? throw new ArgumentNullException(nameof(data.CostDay))
                );
        }
        else
        {
            DisplayAddVehicleErrors = true;
        }
    }
    public List<string> GetAddVehicleFormErrors()
    {
        var data = AddVehicleData;
        List<string> errors = new();
        if (data.RegNo?.Length != 6)
            errors.Add("RegNo must be 6 characters long");
        if (!(data.Make?.Length > 0))
            errors.Add("Make is required");
        if (!(data.Odometer >= 0))
            errors.Add("Odometer must be a positive number");
        if (!(data.CostKm >= 0))
            errors.Add("Cost / Km must be a positive number");
        if (data.Type is null)
            errors.Add("Type is required");
        if (!(data.CostDay >= 0))
            errors.Add("Cost / Day must be a positive number");
        return errors;
    }
}