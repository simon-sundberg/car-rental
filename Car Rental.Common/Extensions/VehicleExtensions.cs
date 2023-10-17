namespace Car_Rental.Common.Extensions;

public static class VehicleExtensions
{
    public static int Duration(this DateOnly startDate, DateOnly endDate)
        => endDate.DayNumber - startDate.DayNumber;
}
