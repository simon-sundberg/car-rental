﻿using Car_Rental.Common.Extensions;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{
    public int Id { get; init; }
    public Vehicle Vehicle { get; init; }
    public IPerson Customer { get; init; }
    public int KmRented { get; init; }
    public int? KmDistance { get; set; }
    public int? KmReturned { get; private set; }
    public DateOnly DateRented { get; init; }
    public DateOnly? DateReturned { get; set; }
    public double? Cost { get; set; }
    public Booking(int id, Vehicle vehicle, IPerson customer)
    {
        Id = id;
        Vehicle = vehicle;
        Customer = customer;
        KmRented = Vehicle.Odometer;
        DateRented = DateOnly.FromDateTime(DateTime.Today);
    }
    public void ReturnVehicle()
    {
        int kmDistance = KmDistance ?? throw new ArgumentNullException(nameof(KmDistance));
        if (kmDistance < 0)
            throw new ArgumentException(nameof(kmDistance));
        DateOnly today = DateOnly.FromDateTime(DateTime.Today);
        int days = today.Duration(DateRented) + 1;
        Cost = days * Vehicle.CostDay + kmDistance * Vehicle.CostKm;
        DateReturned = today;
        KmReturned = KmRented + kmDistance;
        Vehicle.Status = VehicleStatuses.Available;
        Vehicle.Odometer += kmDistance;
        Vehicle.Booking = null;
    }
}
