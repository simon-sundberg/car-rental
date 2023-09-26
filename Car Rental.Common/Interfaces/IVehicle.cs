namespace Car_Rental.Common.Interfaces;

public interface IVehicle
{
    public string RegNo { get; init; }
    public string Make { get; init; }
    public int Odometer { get; set; }
    public double CostKm { get; set; }
    public VehicleTypes Type { get; init; }

    public double CostDay { get; set; }
    public VehicleStatuses Status { get; set; }
}
