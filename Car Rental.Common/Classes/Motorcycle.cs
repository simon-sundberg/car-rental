using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Classes;

public class Motorcycle : Vehicle
{
    public Motorcycle(
        int id,
        string regNo,
        string make,
        int odometer,
        double costKm,
        double costDay
    )
        : base(id, regNo, make, odometer, costKm, VehicleTypes.Motorcycle, costDay) { }
}
