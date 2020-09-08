using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NAA.FleetService.Domain;

namespace NAA.FleetService.Infrastructure
{
    public interface IAirplaneRepository
    {
        Task<List<Airplane>> AllAirplanesAsync();

        Task AddAirplaneAsync(Airplane airplane);

        Task DeleteAirplaneAsync(Guid id);

        Task<Airplane> GetAirplaneByIdAsync(Guid id);
    }
}
