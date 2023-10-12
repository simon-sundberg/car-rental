namespace Car_Rental.Business.Classes;

public class AddVehicleForm
{
    public string? RegNo { get; set; }
    public string? Make { get; set; }
    public int? Odometer { get; set; }
    public double? CostKm { get; set; }
    public VehicleTypes? Type { get; set; }
    public double? CostDay { get; set; }
    public VehicleStatuses? Status { get; set; }
}
