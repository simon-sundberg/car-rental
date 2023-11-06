using System.Data;
using static Car_Rental.Common.Error.ErrorTypes;

namespace Car_Rental.Common.Error;

public static class ErrorInitializer
{
    public static void AddErrors(ErrorTracker eh)
    {
        List<Error> errors = new();
        errors.AddRange(CustomerErrors);
        errors.AddRange(CustomerFormErrors);
        errors.AddRange(VehicleErrors);
        errors.AddRange(VehicleFormErrors);
        errors.AddRange(GeneralErrors);
        foreach (Error error in errors)
            eh.AddError(error);
    }

    static List<Error> GeneralErrors =>
        new()
        {
            new Error(
                CRITICAL_ERROR,
                "Something went wrong. Please contact the administrator.",
                ErrorProjects.None,
                ErrorSources.None,
                true
            ),
        };

    static List<Error> CustomerErrors =>
        new()
        {
            new Error(
                CUSTOMER_DUPLICATE_SSN,
                "A customer with the given SSN already exists",
                ErrorProjects.Data,
                ErrorSources.AddCustomer
            ),
        };

    static List<Error> CustomerFormErrors =>
        new()
        {
            new Error(
                CUSTOMER_SSN_NOT_5_DIGITS,
                "SSN must contain 5 digits",
                ErrorProjects.App,
                ErrorSources.AddCustomerForm
            ),
            new Error(
                CUSTOMER_LAST_NAME_EMPTY,
                "Last Name is required",
                ErrorProjects.App,
                ErrorSources.AddCustomerForm
            ),
            new Error(
                CUSTOMER_FIRST_NAME_EMPTY,
                "First Name is required",
                ErrorProjects.App,
                ErrorSources.AddCustomerForm
            ),
        };

    static List<Error> VehicleErrors =>
        new()
        {
            new Error(
                VEHICLE_DUPLICATE_REGNO,
                "A vehicle with the given RegNo already exists",
                ErrorProjects.Data,
                ErrorSources.AddVehicle
            ),
            new Error(
                VEHICLE_ALREADY_BOOKED,
                "Vehicle is already booked",
                ErrorProjects.Data,
                ErrorSources.RentVehicle
            ),
            new Error(
                VEHICLE_RENTING_DISTANCE_NULL_OR_NEGATIVE,
                "Distance must be a non-negative number",
                ErrorProjects.Data,
                ErrorSources.ReturnVehicle
            ),
            new Error(
                VEHICLE_RENTING_CUSTOMER_ID_NULL,
                "Renting customer is required",
                ErrorProjects.Data,
                ErrorSources.RentVehicle
            ),
        };

    static List<Error> VehicleFormErrors =>
        new()
        {
            new Error(
                VEHICLE_REGNO_WRONG_LENGTH,
                "RegNo must be 6 characters long",
                ErrorProjects.App,
                ErrorSources.AddVehicleForm
            ),
            new Error(
                VEHICLE_MAKE_EMPTY,
                "Make is required",
                ErrorProjects.App,
                ErrorSources.AddVehicleForm
            ),
            new Error(
                VEHICLE_ODOMETER_NOT_POSITIVE,
                "Odometer must be a positive number",
                ErrorProjects.App,
                ErrorSources.AddVehicleForm
            ),
            new Error(
                VEHICLE_COSTKM_NOT_POSITIVE,
                "Cost / Km must be a positive number",
                ErrorProjects.App,
                ErrorSources.AddVehicleForm
            ),
            new Error(
                VEHICLE_TYPE_NULL,
                "Type is required",
                ErrorProjects.App,
                ErrorSources.AddVehicleForm
            ),
            new Error(
                VEHICLE_COSTDAY_NOT_POSITIVE,
                "Cost / Day must be a positive number",
                ErrorProjects.App,
                ErrorSources.AddVehicleForm
            ),
        };
}
