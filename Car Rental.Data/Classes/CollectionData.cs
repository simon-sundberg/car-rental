﻿using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Data.Classes;

public class CollectionData : IData
{
    readonly List<IVehicle> _vehicles = new();
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

        _persons.Add(new Customer(NextPersonId, "12345", "Doe", "John"));
        _persons.Add(new Customer(NextPersonId, "98765", "Doe", "Jane"));

        _bookings.Add(new Booking(NextBookingId, _vehicles[2], _persons[0], 1000, new DateTime(2023, 9, 9)));
        _bookings.Add(new Booking(NextBookingId, _vehicles[3], _persons[1], 5000, new DateTime(2023, 9, 9)));
        _bookings[1].ReturnVehicle(5000, new DateTime(2023, 9, 9));
    }
    public List<IVehicle> GetVehicles() => _vehicles;
    public List<IVehicle> GetVehicles(VehicleStatuses status)
        => _vehicles.FindAll(vehicle => vehicle.Status == status);
    public List<IPerson> GetCustomers() => _persons;
    public List<IBooking> GetBookings() => _bookings;

    public int NextVehicleId => _vehicles.Count.Equals(0) ? 1 : _vehicles.Max(v => v.Id) + 1;
    public int NextBookingId => _bookings.Count.Equals(0) ? 1 : _bookings.Max(b => b.Id) + 1;
    public int NextPersonId => _persons.Count.Equals(0) ? 1 : _persons.Max(p => p.Id) + 1;

}
