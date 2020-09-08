using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NAA.FleetService.Domain;

namespace NAA.FleetService.Infrastructure
{
    public class AirplaneRepository : IAirplaneRepository
    {
        private readonly AirplaneContext _context;

        public AirplaneRepository(AirplaneContext context)
        {
            _context = context;
        }

        public async Task<List<Airplane>> AllAirplanesAsync()
        {
            return await _context.Airplanes.ToListAsync();
        }

        public async Task AddAirplaneAsync(Airplane airplane)
        {
            await _context.Airplanes.AddAsync(airplane);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAirplaneAsync(Guid id)
        {
            var airplane = await _context.Airplanes.FindAsync(id);

            _context.Airplanes.Remove(airplane);

            await _context.SaveChangesAsync();
        }

        public async Task<Airplane> GetAirplaneByIdAsync(Guid id)
        {
            return await _context.Airplanes.FindAsync(id);
        }
    }
}
