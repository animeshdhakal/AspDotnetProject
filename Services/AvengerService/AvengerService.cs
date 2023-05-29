using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using avengerapi.Data;
using avengerapi.Models;
using Microsoft.EntityFrameworkCore;

namespace avengerapi.Services.AvengerService
{
    public class AvengerService : IAvengerService
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AvengerService(IMapper mapper, DataContext context)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<Avenger> AddAvenger(Avenger avenger)
        {
            // avenger.Id = await _context.Avengers.MaxAsync(x => x.Id) + 1;


            _context.Avengers.Add(avenger);
            await _context.SaveChangesAsync();

            return avenger;
        }

        public async Task<Avenger> DeleteAvenger(int id)
        {
            try
            {
                var character = await _context.Avengers.FirstOrDefaultAsync(x => x.Id == id);

                if (character == null)
                    throw new Exception("Character not found");

                _context.Avengers.Remove(character);

                await _context.SaveChangesAsync();

                return character;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Avenger> GetAvengerById(int id)
        {
            return await _context.Avengers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Avenger>> GetAvengers()
        {
            return await _context.Avengers.ToListAsync();
        }

        public async Task<Avenger> UpdateAvenger(Avenger avenger)
        {
            _context.Avengers.Update(avenger);
            await _context.SaveChangesAsync();

            return avenger;
        }
    }
}