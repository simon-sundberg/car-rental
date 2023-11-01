using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Error;
using Car_Rental.Common.Extensions;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;
using System.Linq.Expressions;
using System.Reflection;
using static Car_Rental.Common.Error.ErrorTypes;

namespace Car_Rental.Data.Classes;

public class CollectionData : IData
{
    readonly List<Vehicle> _vehicles = new();
    readonly List<IPerson> _persons = new();
    readonly List<IBooking> _bookings = new();
    readonly ErrorTracker _et;

    public CollectionData(ErrorTracker et)
    {
        _et = et;
        ErrorInitializer.AddErrors(et);
        SeedData();
    }

    void SeedData()
    {
        _vehicles.Add(new Vehicle(1, "ABC123", "Volvo", 10000, 1, VehicleTypes.Combi, 200));
        _vehicles.Add(new Vehicle(2, "DEF456", "Saab", 20000, 1, VehicleTypes.Sedan, 100));
        _vehicles.Add(new Vehicle(3, "GHI789", "Tesla", 1000, 3, VehicleTypes.Sedan, 100));
        _vehicles.Add(new Vehicle(4, "JKL012", "Jeep", 5000, 1.5, VehicleTypes.Van, 300));
        _vehicles.Add(new Vehicle(5, "MNO234", "Yamaha", 30000, 0.5, VehicleTypes.Motorcycle, 50));
        _persons.Add(new Customer(1, "12345", "Doe", "John"));
        _persons.Add(new Customer(2, "98765", "Doe", "Jane"));
        RentVehicle(3, 1);
        RentVehicle(4, 2);
        _bookings[1].KmDistance = 0;
        _bookings[1].ReturnVehicle(_vehicles[3]);
    }

    public void AddVehicle(Vehicle form)
    {
        _et.InactivateError(VEHICLE_DUPLICATE_REGNO);
        form.CheckErrors(_et);
        List<Error> errors = _et.GetErrors(
            e => e.Active && e.Source == ErrorSources.AddVehicleForm
        );
        if (errors.Count > 0)
            throw new ArgumentException(String.Join(" & ", errors));
        if (Single<Vehicle>(v => v.RegNo == form.RegNo.ToUpper()) is not null)
        {
            _et.ActivateError(VEHICLE_DUPLICATE_REGNO);
            return;
        }
        Add<Vehicle>(
            new Vehicle(
                NextVehicleId,
                form.RegNo.ToUpper(),
                form.Make,
                form.Odometer,
                form.CostKm,
                form.Type,
                form.CostDay
            )
        );
    }

    public void AddCustomer(IPerson form)
    {
        _et.InactivateError(CUSTOMER_DUPLICATE_SSN);
        form.CheckErrors(_et);
        List<Error> errors = _et.GetErrors(
            e => e.Active && e.Source == ErrorSources.AddCustomerForm
        );
        if (errors.Count > 0)
            throw new ArgumentException(String.Join(" & ", errors));
        if (Single<IPerson>(v => v.SSN == form.SSN.ToUpper()) is not null)
        {
            _et.ActivateError(CUSTOMER_DUPLICATE_SSN);
            return;
        }
        Add<IPerson>(new Customer(NextPersonId, form.SSN, form.LastName, form.FirstName));
    }

    public void RentVehicle(int vehicleId, int customerId)
    {
        _et.InactivateError(VEHICLE_ALREADY_BOOKED);
        IPerson customer =
            Single<IPerson>(c => c.Id == customerId)
            ?? throw new InvalidOperationException("Customer not found for the given customerId");
        Vehicle vehicle =
            Single<Vehicle>(v => v.Id == vehicleId)
            ?? throw new InvalidOperationException("Vehicle not found for the given vehicleId");
        if (vehicle.Status == VehicleStatuses.Booked)
        {
            _et.ActivateError(VEHICLE_ALREADY_BOOKED);
            return;
        }
        Booking booking = new(NextBookingId, vehicle.Id, customer.Id, vehicle.Odometer);
        Add<IBooking>(booking);
        vehicle.BookingId = booking.Id;
        vehicle.Status = VehicleStatuses.Booked;
    }

    public void ReturnVehicle(int vehicleId)
    {
        _et.InactivateError(VEHICLE_RENTING_DISTANCE_NULL_OR_NEGATIVE);

        try
        {
            Vehicle vehicle =
    Single<Vehicle>(v => v.Id == vehicleId)
    ?? throw new InvalidOperationException("Vehicle not found for the given vehicleId.");
            IBooking booking =
                Single<IBooking>(b => b.Id == vehicle.BookingId)
                ?? throw new InvalidOperationException("Booking not found for the given vehicleId.");
            booking.ReturnVehicle(vehicle);
        }
        catch (InvalidOperationException)
        {
            //_et.ActivateError
        }
        catch (InvalidDataException)
        {
            _et.ActivateError(VEHICLE_RENTING_DISTANCE_NULL_OR_NEGATIVE);
        }
    }

    public int NextVehicleId => _vehicles.Count.Equals(0) ? 1 : _vehicles.Max(v => v.Id) + 1;
    public int NextBookingId => _bookings.Count.Equals(0) ? 1 : _bookings.Max(b => b.Id) + 1;
    public int NextPersonId => _persons.Count.Equals(0) ? 1 : _persons.Max(p => p.Id) + 1;

    public IEnumerable<T> Get<T>(Expression<Func<T, bool>>? expression = null)
        where T : class =>
        expression is null
            ? GetCollectionQueryable<T>().AsEnumerable()
            : GetCollectionQueryable<T>().Where(expression.Compile()).AsEnumerable();

    public T? Single<T>(Expression<Func<T, bool>> expression)
        where T : class => GetCollectionQueryable<T>().SingleOrDefault(expression.Compile());

    public void Add<T>(T item)
        where T : class => GetCollectionReference<T>().Add(item);

    private IQueryable<T> GetCollectionQueryable<T>()
        where T : class => GetCollectionReference<T>().AsQueryable();

    private List<T> GetCollectionReference<T>()
        where T : class
    {
        FieldInfo? collections = GetType()
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .Single(f => f.FieldType == typeof(List<T>));
        object? value = collections.GetValue(this) ?? throw new InvalidDataException();
        return (List<T>)value;
    }
}
