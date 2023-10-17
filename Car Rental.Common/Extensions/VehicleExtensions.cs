using Car_Rental.Common.Classes;

namespace Car_Rental.Common.Extensions;

public static class VehicleExtensions
{
    public static int Duration(this DateOnly startDate, DateOnly endDate)
        => endDate.DayNumber - startDate.DayNumber;
    public static List<string> GetErrors(this Vehicle vehicle)
    {
        List<string> errors = new();
        if (vehicle.RegNo.Length != 6)
            errors.Add("RegNo must be 6 characters long");
        if (vehicle.Make.Length == 0)
            errors.Add("Make is required");
        if (vehicle.Odometer <= 0)
            errors.Add("Odometer must be a positive number");
        if (vehicle.CostKm <= 0)
            errors.Add("Cost / Km must be a positive number");
        if (vehicle.CostDay <= 0)
            errors.Add("Cost / Day must be a positive number");
        return errors;
    }
}
