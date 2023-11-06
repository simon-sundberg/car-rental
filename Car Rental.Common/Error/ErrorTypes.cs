﻿namespace Car_Rental.Common.Error;

public enum ErrorTypes
{
    CRITICAL_ERROR,
    CUSTOMER_DUPLICATE_SSN,
    CUSTOMER_FIRST_NAME_EMPTY,
    CUSTOMER_LAST_NAME_EMPTY,
    CUSTOMER_SSN_NOT_5_DIGITS,
    VEHICLE_ALREADY_BOOKED,
    VEHICLE_COSTDAY_NOT_POSITIVE,
    VEHICLE_COSTKM_NOT_POSITIVE,
    VEHICLE_DUPLICATE_REGNO,
    VEHICLE_MAKE_EMPTY,
    VEHICLE_ODOMETER_NOT_POSITIVE,
    VEHICLE_REGNO_WRONG_LENGTH,
    VEHICLE_RENTING_CUSTOMER_ID_NULL,
    VEHICLE_RENTING_DISTANCE_NULL_OR_NEGATIVE,
    VEHICLE_TYPE_NULL,
}
