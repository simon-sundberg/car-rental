namespace Car_Rental.Common.Classes;

public class Motorcycle : Vehicle
{
    public Motorcycle(int id, string regNo, string make, int odometer, double costKm, double costDay, VehicleStatuses status)
        : base(id, regNo, make, odometer, costKm, VehicleTypes.Motorcycle, costDay, status)
    {

    }
}
