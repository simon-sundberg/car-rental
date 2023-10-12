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
    public List<string> GetValidationErrors()
    {
        List<string> errors = new();
        if (RegNo?.Length != 6)
            errors.Add("RegNo must be 6 characters long");
        if (!(Make?.Length > 0))
            errors.Add("Make is required");
        if (!(Odometer >= 0))
            errors.Add("Odometer must be a positive number");
        if (!(CostKm >= 0))
            errors.Add("Cost / Km must be a positive number");
        if (Type is null)
            errors.Add("Type is required");
        if (!(CostDay >= 0))
            errors.Add("Cost / Day must be a positive number");
        return errors;
    }
}
