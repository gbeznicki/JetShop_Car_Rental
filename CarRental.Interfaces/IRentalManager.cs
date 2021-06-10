namespace CarRental.Interfaces
{
    public interface IRentalManager
    {
        public IRentResponse RentVehicle(IRentRequest rentRequest);
        public IReturnResponse ReturnVehicle(IReturnRequest returnRequest);
    }
}