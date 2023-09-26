using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Motorcycle : IVehicle
{
    public string RegNo { get; init; }
    public string Make { get; init; }
    public int Odometer { get; set; }
    public double CostKm { get; set; }
    public double CostDay { get; set; }
    public VehicleStatuses Status { get; set; }
    public VehicleTypes Type { get; init; }

    public Motorcycle(string regNo, string make, int odometer, double costKm, double costDay, VehicleStatuses status)
    {
        RegNo = regNo;
        Make = make;
        Odometer = odometer;
        CostKm = costKm;
        CostDay = costDay;
        Status = status;
        Type = VehicleTypes.Motorcycle;
    }
}
