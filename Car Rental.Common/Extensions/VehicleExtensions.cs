﻿using Car_Rental.Common.Classes;
using Car_Rental.Common.Error;
using static Car_Rental.Common.Error.ErrorTypes;

namespace Car_Rental.Common.Extensions;

public static class VehicleExtensions
{
    public static int Duration(this DateOnly startDate, DateOnly endDate) =>
        endDate.DayNumber - startDate.DayNumber;

    public static void CheckErrors(this Vehicle vehicle, ErrorTracker eh)
    {
        if (vehicle.RegNo.Length != 6)
            eh.ActivateError(VEHICLE_REGNO_WRONG_LENGTH);
        if (vehicle.Make.Length == 0)
            eh.ActivateError(VEHICLE_MAKE_EMPTY);
        if (vehicle.Odometer <= 0)
            eh.ActivateError(VEHICLE_ODOMETER_NOT_POSITIVE);
        if (vehicle.CostKm <= 0)
            eh.ActivateError(VEHICLE_COSTKM_NOT_POSITIVE);
        if (vehicle.Type is null)
            eh.ActivateError(VEHICLE_TYPE_NULL);
        if (vehicle.CostDay <= 0)
            eh.ActivateError(VEHICLE_COSTDAY_NOT_POSITIVE);
    }
}
