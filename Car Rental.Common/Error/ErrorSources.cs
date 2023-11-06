using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Error;

public enum ErrorSources
{
    None,
    AddVehicleForm,
    AddCustomerForm,
    ReturnVehicle,
    RentVehicle,
    AddCustomer,
    AddVehicle
}
