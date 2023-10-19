using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Data.Classes;

public class CollectionData : IData
{
    readonly List<Vehicle> _vehicles = new();
    readonly List<IPerson> _persons = new();
    readonly List<IBooking> _bookings = new();
    public CollectionData()
    {
        SeedData();
    }
    void SeedData()
    {
        AddVehicle("ABC123", "Volvo", 10000, 1, VehicleTypes.Combi, 200);
        AddVehicle("DEF456", "Saab", 20000, 1, VehicleTypes.Sedan, 100);
        AddVehicle("GHI789", "Tesla", 1000, 3, VehicleTypes.Sedan, 100);
        AddVehicle("JKL012", "Jeep", 5000, 1.5, VehicleTypes.Van, 300);
        AddVehicle("MNO234", "Yamaha", 30000, 0.5, VehicleTypes.Motorcycle, 50);
        AddCustomer("195705031819", "Doe", "John");
        AddCustomer("199110182663", "Doe", "Jane");
        Vehicle ghi789 = GetVehicle("GHI789") ?? throw new NullReferenceException(nameof(ghi789));
        Vehicle jkl012 = GetVehicle("JKL012") ?? throw new NullReferenceException(nameof(jkl012));
        IPerson john = GetCustomer("195705031819") ?? throw new NullReferenceException(nameof(john));
        IPerson jane = GetCustomer("199110182663") ?? throw new NullReferenceException(nameof(jane));
        AddBooking(ghi789, john);
        AddBooking(jkl012, jane);
        IBooking janesBooking = jkl012.Booking ?? throw new NullReferenceException(nameof(janesBooking));
        janesBooking.KmDistance = 0;
        janesBooking.ReturnVehicle();
    }
    public int NextVehicleId => _vehicles.Count.Equals(0) ? 1 : _vehicles.Max(v => v.Id) + 1;
    public int NextBookingId => _bookings.Count.Equals(0) ? 1 : _bookings.Max(b => b.Id) + 1;
    public int NextPersonId => _persons.Count.Equals(0) ? 1 : _persons.Max(p => p.Id) + 1;

    public IBooking? GetBooking(string regNo) => _bookings.LastOrDefault(b => b.Vehicle.RegNo == regNo);
    public IPerson? GetCustomer(string ssn) => _persons.SingleOrDefault(p => p.SSN == ssn);
    public Vehicle? GetVehicle(string regNo) => _vehicles.SingleOrDefault(v => v.RegNo == regNo.ToUpper());
    public List<Vehicle> GetVehicles() => _vehicles;
    public List<Vehicle> GetVehicles(VehicleStatuses status)
        => _vehicles.FindAll(vehicle => vehicle.Status == status);
    public List<IPerson> GetCustomers() => _persons;
    public List<IBooking> GetBookings() => _bookings;
    public void AddBooking(Vehicle vehicle, IPerson customer)
    {
        if (vehicle.Status == VehicleStatuses.Booked)
            return;
        Booking booking = new Booking(NextBookingId, vehicle, customer);
        _bookings.Add(booking);
        vehicle.Booking = booking;
        vehicle.Status = VehicleStatuses.Booked;
    }
    public void AddCustomer(string ssn, string lastName, string firstName)
    {
        if (GetCustomer(ssn) != null)
            return;
        _persons.Add(new Customer(NextPersonId, ssn, lastName, firstName));
    }
    public void AddVehicle(string regNo, string make, int odometer, double costKm, VehicleTypes type, double costDay)
    {
        if (GetVehicle(regNo) != null)
            return;
        _vehicles.Add(new Car(NextVehicleId, regNo.ToUpper(), make, odometer, costKm, type, costDay, VehicleStatuses.Available));
    }
}
