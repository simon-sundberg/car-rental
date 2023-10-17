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
        _vehicles.Add(new Car(NextVehicleId, "ABC123", "Volvo", 10000, 1, VehicleTypes.Combi, 200, VehicleStatuses.Available));
        _vehicles.Add(new Car(NextVehicleId, "DEF456", "Saab", 20000, 1, VehicleTypes.Sedan, 100, VehicleStatuses.Available));
        _vehicles.Add(new Car(NextVehicleId, "GHI789", "Tesla", 1000, 3, VehicleTypes.Sedan, 100, VehicleStatuses.Booked));
        _vehicles.Add(new Car(NextVehicleId, "JKL012", "Jeep", 5000, 1.5, VehicleTypes.Van, 300, VehicleStatuses.Available));
        _vehicles.Add(new Motorcycle(NextVehicleId, "MNO234", "Yamaha", 30000, 0.5, 50, VehicleStatuses.Available));

        _persons.Add(new Customer(NextPersonId, "195705031819", "Doe", "John"));
        _persons.Add(new Customer(NextPersonId, "199110182663", "Doe", "Jane"));

        _bookings.Add(new Booking(NextBookingId, _vehicles[2], _persons[0], 1000));
        _bookings.Add(new Booking(NextBookingId, _vehicles[3], _persons[1], 5000));
        _bookings[1].ReturnVehicle(0);
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
        _bookings.Add(new Booking(NextBookingId, vehicle, customer, vehicle.Odometer));
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
