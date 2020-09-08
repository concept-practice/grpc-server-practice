using System.Collections.Generic;
using NAA.FleetService.Protos;

namespace NAA.FleetService.Domain
{
    public interface IAirplaneFactory
    {
        Airplane Entity(AddAirplaneRequest request);

        AllAirplanesResponse Entities(IEnumerable<Airplane> airplanes);

        AirplaneResponse Entity(Airplane airplane);
    }
}
