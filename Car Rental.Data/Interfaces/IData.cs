﻿using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Data.Interfaces;
public interface IData
{
    List<Vehicle> GetVehicles();
    List<Vehicle> GetVehicles(VehicleStatuses status);
    List<IPerson> GetCustomers();
    List<IBooking> GetBookings();
    void AddCustomer(string ssn, string lastName, string firstName);
    void AddVehicle(string regNo, string make, int odometer, double costKm, VehicleTypes type, double costDay);
}
