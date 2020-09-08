using System;

namespace NAA.FleetService.Domain
{
    public class Airplane
    {
        public Guid Id { get; }

        public string Manufacturer { get; }

        public string Model { get; }

        public string Registration { get; }

        public Airplane(Guid id, string manufacturer, string model, string registration)
        {
            Id = id;
            Manufacturer = manufacturer;
            Model = model;
            Registration = registration;
        }
    }
}
