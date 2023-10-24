using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;
using System.Linq.Expressions;
using System.Reflection;

namespace Car_Rental.Data.Classes;

public class CollectionData : IData
{
    readonly List<Vehicle> _vehicles = new() { new Vehicle(5, "QQQ", "Volvo", 10000, 1, VehicleTypes.Combi, 200, VehicleStatuses.Available) };
    readonly List<IPerson> _persons = new();
    readonly List<IBooking> _bookings = new();
    public CollectionData() => SeedData();
    void SeedData()
    {
        Add<Vehicle>(new Vehicle(NextVehicleId, "ABC123", "Volvo", 10000, 1, VehicleTypes.Combi, 200, VehicleStatuses.Available));
        var CHECK = Get<Vehicle>().ToList();
        //AddVehicle("DEF456", "Saab", 20000, 1, VehicleTypes.Sedan, 100);
        //AddVehicle("GHI789", "Tesla", 1000, 3, VehicleTypes.Sedan, 100);
        //AddVehicle("JKL012", "Jeep", 5000, 1.5, VehicleTypes.Van, 300);
        //AddVehicle("MNO234", "Yamaha", 30000, 0.5, VehicleTypes.Motorcycle, 50);
        //AddCustomer("12345", "Doe", "John");
        //AddCustomer("98765", "Doe", "Jane");
        //Vehicle ghi789 = GetVehicle("GHI789") ?? throw new NullReferenceException(nameof(ghi789));
        //Vehicle jkl012 = GetVehicle("JKL012") ?? throw new NullReferenceException(nameof(jkl012));
        //IPerson john = GetCustomer("12345") ?? throw new NullReferenceException(nameof(john));
        //IPerson jane = GetCustomer("98765") ?? throw new NullReferenceException(nameof(jane));
        //AddBooking(ghi789, john);
        //AddBooking(jkl012, jane);
        //IBooking janesBooking = jkl012.Booking ?? throw new NullReferenceException(nameof(janesBooking));
        //janesBooking.KmDistance = 0;
        //janesBooking.ReturnVehicle();
    }
    public int NextVehicleId => _vehicles.Count.Equals(0) ? 1 : _vehicles.Max(v => v.Id) + 1;
    public int NextBookingId => _bookings.Count.Equals(0) ? 1 : _bookings.Max(b => b.Id) + 1;
    public int NextPersonId => _persons.Count.Equals(0) ? 1 : _persons.Max(p => p.Id) + 1;
    public IEnumerable<T> Get<T>(Expression<Func<T, bool>>? expression = null) where T : class
    {
        return expression is null
            ? GetCollectionAsQueryable<T>().ToList()
            : GetCollectionAsQueryable<T>().Where(expression.Compile()).ToList();
    }
    public T? Single<T>(Expression<Func<T, bool>> expression) where T : class
    {
        return GetCollectionAsQueryable<T>().SingleOrDefault(expression.Compile());
    }
    public void Add<T>(T item) where T : class
    {
        var collection = GetCollectionAsQueryable<T>();
        //var list = collection.ToList();
        //list.Add(item);
        //collection.ToList
        GetCollectionAsQueryable<T>().ToList().Add(item);
    }
    private IQueryable<T> GetCollectionAsQueryable<T>() where T : class
    {
        FieldInfo? collections = GetType()
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .Single(f => f.FieldType == typeof(List<T>)); // && f.IsInitOnly
        object? value = collections.GetValue(this) ?? throw new InvalidDataException();
        return ((List<T>)value).AsQueryable();
    }

    //public IBooking? GetBooking(string regNo) => _bookings.LastOrDefault(b => b.Vehicle.RegNo == regNo);
    //public IPerson? GetCustomer(string ssn) => _persons.SingleOrDefault(p => p.SSN == ssn);
    //public Vehicle? GetVehicle(string regNo) => _vehicles.SingleOrDefault(v => v.RegNo == regNo.ToUpper());
    //public List<Vehicle> GetVehicles() => _vehicles;
    //public List<Vehicle> GetVehicles(VehicleStatuses status)
    //=> _vehicles.FindAll(vehicle => vehicle.Status == status);
    //public List<IPerson> GetCustomers() => _persons;
    //public List<IBooking> GetBookings() => _bookings;
    //public void AddBooking(Vehicle vehicle, IPerson customer)
    //{
    //    if (vehicle.Status == VehicleStatuses.Booked)
    //        return;
    //    Booking booking = new Booking(NextBookingId, vehicle, customer);
    //    _bookings.Add(booking);
    //    vehicle.Booking = booking;
    //    vehicle.Status = VehicleStatuses.Booked;
    //}
    //public void AddCustomer(string ssn, string lastName, string firstName)
    //{
    //    if (Single<IPerson>(i => i.SSN == ssn) != null)
    //        return;
    //    _persons.Add(new Customer(NextPersonId, ssn, lastName, firstName));
    //}
    //public void AddVehicle(string regNo, string make, int odometer, double costKm, VehicleTypes type, double costDay)
    //{
    //    if (Single<Vehicle>(i => i.RegNo == regNo) != null)
    //        return;
    //    _vehicles.Add(new Car(NextVehicleId, regNo.ToUpper(), make, odometer, costKm, type, costDay, VehicleStatuses.Available));
    //}
}
