namespace Car_Rental.Common.Interfaces;

public interface IVehicle
{
    int Id { get; init; }
    string RegNo { get; init; }
    string Make { get; init; }
    int Odometer { get; set; }
    double CostKm { get; set; }
    VehicleTypes Type { get; init; }
    double CostDay { get; set; }
    VehicleStatuses Status { get; set; }
}
