namespace Car_Rental.Common.Classes;

public class Car : Vehicle
{
    public Car(int id, string regNo, string make, int odometer, double costKm, VehicleTypes type, double costDay, VehicleStatuses status)
        : base(id, regNo, make, odometer, costKm, type, costDay, status)
    {

    }
}
