using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Data.Classes;

public class CollectionData : IData
{

    readonly List<IVehicle> _vehicles = new();
    readonly List<IPerson> _customers = new();
    public List<IVehicle> GetVehicles() => _vehicles;
    public List<IPerson> GetCustomers() => _customers;

    public CollectionData()
    {
        SeedData();
    }

    void SeedData()
    {
        _vehicles.Add(new Car("ABC123", "Volvo", 10000, 1, VehicleTypes.Combi, 200, VehicleStatuses.Available));
        _vehicles.Add(new Car("DEF456", "Saab", 20000, 1, VehicleTypes.Sedan, 100, VehicleStatuses.Available));
        _vehicles.Add(new Car("GHI789", "Tesla", 1000, 3, VehicleTypes.Sedan, 100, VehicleStatuses.Booked));
        _vehicles.Add(new Car("JKL012", "Jeep", 5000, 1.5, VehicleTypes.Van, 200, VehicleStatuses.Available));
        _vehicles.Add(new Motorcycle("MNO234", "Yamaha", 30000, 0.5, 200, VehicleStatuses.Available));

        _customers.Add(new Customer("12345", "Doe", "John"));
        _customers.Add(new Customer("98765", "Doe", "Jane"));
    }
}
