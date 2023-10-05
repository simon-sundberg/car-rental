using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Car : IVehicle
{
    public int Id { get; init; }
    public string RegNo { get; init; }
    public string Make { get; init; }
    public int Odometer { get; set; }
    public double CostKm { get; set; }
    public VehicleTypes Type { get; init; }
    public double CostDay { get; set; }
    public VehicleStatuses Status { get; set; }
    public Car(int id, string regNo, string make, int odometer, double costKm, VehicleTypes type, double costDay, VehicleStatuses status)
    {
        Id = id;
        RegNo = regNo;
        Make = make;
        Odometer = odometer;
        CostKm = costKm;
        CostDay = costDay;
        Status = status;
        Type = type;
    }
}
