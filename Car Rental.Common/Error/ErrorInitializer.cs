using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Error;

public static class ErrorInitializer
{
    public static void AddErrors(ErrorTracker eh)
    {
        List<Error> errors = new();
        errors.AddRange(DataErrors);
        errors.AddRange(CustomerFormErrors);
        errors.AddRange(VehicleFormErrors);
        foreach (Error error in errors)
            eh.AddError(error);
    }

    static List<Error> CustomerFormErrors =>
        new()
        {
            new Error(
                ErrorProjects.App,
                ErrorSources.AddCustomerForm,
                ErrorTypes.CUSTOMER_SSN_NOT_5_DIGITS,
                "SSN must contain 5 digits"
            ),
            new Error(
                ErrorProjects.App,
                ErrorSources.AddCustomerForm,
                ErrorTypes.CUSTOMER_LAST_NAME_EMPTY,
                "Last Name is required"
            ),
            new Error(
                ErrorProjects.App,
                ErrorSources.AddCustomerForm,
                ErrorTypes.CUSTOMER_FIRST_NAME_EMPTY,
                "First Name is required"
            ),
        };

    static List<Error> VehicleFormErrors =>
        new()
        {
            new Error(
                ErrorProjects.App,
                ErrorSources.AddVehicleForm,
                ErrorTypes.VEHICLE_REGNO_WRONG_LENGTH,
                "RegNo must be 6 characters long"
            ),
            new Error(
                ErrorProjects.App,
                ErrorSources.AddVehicleForm,
                ErrorTypes.VEHICLE_MAKE_EMPTY,
                "Make is required"
            ),
            new Error(
                ErrorProjects.App,
                ErrorSources.AddVehicleForm,
                ErrorTypes.VEHICLE_ODOMETER_NOT_POSITIVE,
                "Odometer must be a positive number"
            ),
            new Error(
                ErrorProjects.App,
                ErrorSources.AddVehicleForm,
                ErrorTypes.VEHICLE_COSTKM_NOT_POSITIVE,
                "Cost / Km must be a positive number"
            ),
            new Error(
                ErrorProjects.App,
                ErrorSources.AddVehicleForm,
                ErrorTypes.VEHICLE_TYPE_NULL,
                "Type is required"
            ),
            new Error(
                ErrorProjects.App,
                ErrorSources.AddVehicleForm,
                ErrorTypes.VEHICLE_COSTDAY_NOT_POSITIVE,
                "Cost / Day must be a positive number"
            ),
        };

    static List<Error> DataErrors =>
        new()
        {
            new Error(
                ErrorProjects.Data,
                ErrorSources.AddVehicle,
                ErrorTypes.VEHICLE_DUPLICATE_REGNO,
                "A vehicle with the given RegNo already exists"
            ),
            new Error(
                ErrorProjects.Data,
                ErrorSources.AddCustomer,
                ErrorTypes.CUSTOMER_DUPLICATE_SSN,
                "A customer with the given SSN already exists"
            ),
            new Error(
                ErrorProjects.Data,
                ErrorSources.RentVehicle,
                ErrorTypes.VEHICLE_ALREADY_BOOKED,
                "Vehicle is already booked"
            ),
            new Error(
                ErrorProjects.Data,
                ErrorSources.ReturnVehicle,
                ErrorTypes.VEHICLE_RENTING_DISTANCE_NULL_OR_NEGATIVE,
                "Distance must be a non-negative number"
            )
        };
}
