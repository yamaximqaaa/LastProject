
namespace Abstractions.Airport
{
    public interface IAirport
    {
        void PlaneTookOff(int planeNum_);
        void EmergencyInformationOutput();
        void FindSomePlane();
        void FindNearestPlane();
        void Print();
    }
}
