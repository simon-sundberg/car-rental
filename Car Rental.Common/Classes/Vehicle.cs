using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Classes;

public class Vehicle
{
    public Vehicle() => Id = -1;

    public Vehicle(
        int id,
        string regNo,
        string make,
        int odometer,
        double costKm,
        VehicleTypes? type,
        double costDay
    ) =>
        (Id, RegNo, Make, Odometer, CostKm, CostDay, Type) = (
            id,
            regNo,
            make,
            odometer,
            costKm,
            costDay,
            type
        );

    public int? BookingId { get; set; }
    public double CostDay { get; set; }
    public double CostKm { get; set; }
    public int Id { get; init; }
    public string Make { get; set; } = string.Empty;
    public int Odometer { get; set; }
    public string RegNo { get; set; } = string.Empty;
    public VehicleStatuses Status { get; set; } = VehicleStatuses.Available;
    public VehicleTypes? Type { get; set; }
}
