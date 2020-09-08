using System;
using System.Threading.Tasks;
using Grpc.Core;
using NAA.FleetService.Domain;
using NAA.FleetService.Infrastructure;
using NAA.FleetService.Protos;

namespace NAA.FleetService.Services
{
    public class AirplaneHandler : AirplaneService.AirplaneServiceBase
    {
        private readonly IAirplaneRepository _repository;
        private readonly IAirplaneFactory _factory;

        public AirplaneHandler(IAirplaneRepository repository, IAirplaneFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public override async Task<AirplaneResponse> AddAirplane(AddAirplaneRequest request, ServerCallContext context)
        {
            var airplane = _factory.Entity(request);

            await _repository.AddAirplaneAsync(airplane);

            return _factory.Entity(airplane);
        }

        public override async Task<Unit> DeleteAirplane(DeleteAirplaneRequest request, ServerCallContext context)
        {
            await _repository.DeleteAirplaneAsync(Guid.Parse(request.Id));

            return new Unit();
        }

        public override async Task<AirplaneResponse> GetAirplaneById(GetAirplaneByIdRequest request, ServerCallContext context)
        {
            var airplane = await _repository.GetAirplaneByIdAsync(Guid.Parse(request.Id));

            return _factory.Entity(airplane);
        }

        public override async Task<AllAirplanesResponse> AllAirplanes(AllAirplanesRequest request, ServerCallContext context)
        {
            var airplanes = await _repository.AllAirplanesAsync();

            return _factory.Entities(airplanes);
        }
    }
}
