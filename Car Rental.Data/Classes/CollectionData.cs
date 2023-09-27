using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Data.Classes;

public class CollectionData : IData
{

    readonly List<IVehicle> _vehicles = new();
    readonly List<IPerson> _customers = new();
    readonly List<IBooking> _bookings = new();
    public List<IVehicle> GetVehicles() => _vehicles;
    public List<IPerson> GetCustomers() => _customers;

    public List<IBooking> GetBookings() => _bookings;

    public CollectionData()
    {
        SeedData();
    }

    void SeedData()
    {
        _vehicles.Add(new Car("ABC123", "Volvo", 10000, 1, VehicleTypes.Combi, 200, VehicleStatuses.Available));
        _vehicles.Add(new Car("DEF456", "Saab", 20000, 1, VehicleTypes.Sedan, 100, VehicleStatuses.Available));
        _vehicles.Add(new Car("GHI789", "Tesla", 1000, 3, VehicleTypes.Sedan, 100, VehicleStatuses.Booked));
        _vehicles.Add(new Car("JKL012", "Jeep", 5000, 1.5, VehicleTypes.Van, 300, VehicleStatuses.Available));
        _vehicles.Add(new Motorcycle("MNO234", "Yamaha", 30000, 0.5, 50, VehicleStatuses.Available));

        _customers.Add(new Customer("12345", "Doe", "John"));
        _customers.Add(new Customer("98765", "Doe", "Jane"));

        _bookings.Add(new Booking(_vehicles[2], _customers[0], 1000, new DateTime(2023, 9, 9)));
        _bookings.Add(new Booking(_vehicles[3], _customers[1], 5000, new DateTime(2023, 9, 9)));

        _bookings[1].ReturnVehicle(5000, new DateTime(2023, 9, 9));
    }
}
