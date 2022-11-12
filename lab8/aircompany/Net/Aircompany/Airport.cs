using Aircompany.Models;
using Aircompany.Planes;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public List<Plane> Planes { get; protected set; }

        public Airport(IEnumerable<Plane> planes)
        {
            Planes = planes.ToList();
        }

        public List<PassengerPlane> GetPassengersPlanes()
        {
            return Planes
                .Where(t => t.GetType() == typeof(PassengerPlane))
                .Cast<PassengerPlane>()
                .ToList();
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            return Planes
                .Where(t => t.GetType() == typeof(MilitaryPlane))
                .Cast<MilitaryPlane>()
                .ToList();
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return GetPassengersPlanes().Aggregate((w, x) => w.PassengersCapacity > x.PassengersCapacity ? w : x);
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return GetMilitaryPlanes()
                .Where(plane => plane.Type == MilitaryTypes.Transport)
                .ToList();
        }

        public Airport SortByMaxFlightDistance()
        {
            return new Airport(Planes.OrderBy(w => w.MaxFlightDistance));
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport(Planes.OrderBy(w => w.MaxSpeed));
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(Planes.OrderBy(w => w.MaxLoadCapacity));
        }

        public override string ToString()
        {
            return "Airport{planes=" + string.Join(", ", Planes.Select(x => x.Model)) + '}';
        }
    }
}
