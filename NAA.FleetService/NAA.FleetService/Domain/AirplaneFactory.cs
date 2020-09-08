using System;
using System.Collections.Generic;
using System.Linq;
using NAA.FleetService.Protos;

namespace NAA.FleetService.Domain
{
    public class AirplaneFactory : IAirplaneFactory
    {
        public Airplane Entity(AddAirplaneRequest request)
        {
            return new Airplane(Guid.NewGuid(), request.Manufacturer, request.Model, request.Registration);
        }

        public AllAirplanesResponse Entities(IEnumerable<Airplane> airplanes)
        {
            return new AllAirplanesResponse { Entities = { airplanes.Select(Entity) } };
        }

        public AirplaneResponse Entity(Airplane airplane)
        {
            return new AirplaneResponse
            {
                Id = airplane.Id.ToString(),
                Manufacturer = airplane.Manufacturer,
                Model = airplane.Model,
                Registration = airplane.Registration
            };
        }
    }
}
