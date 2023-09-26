using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Business.Classes;
public class BookingProcessor
{
    readonly List<IVehicle> _vehicles;
    public List<IVehicle> GetVehicles() => _vehicles;

    public BookingProcessor(IData data)
    {
        _vehicles = data.GetVehicles();
    }

}
