using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Vehicle
{
    public int Id { get; init; }
    public string RegNo { get; set; } = String.Empty;
    public string Make { get; set; } = String.Empty;
    public int Odometer { get; set; }
    public double CostKm { get; set; }
    public VehicleTypes? Type { get; set; }
    public double CostDay { get; set; }
    public VehicleStatuses Status { get; set; } = VehicleStatuses.Available;
    public int? BookingId { get; set; }

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
}
