using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using avengerapi.Models;

namespace avengerapi.Services.AvengerService
{
    public interface IAvengerService
    {
        Task<List<Avenger>> GetAvengers();
        Task<Avenger> GetAvengerById(int id);
        Task<Avenger> AddAvenger(Avenger avenger);
        Task<Avenger> UpdateAvenger(Avenger avenger);
        Task<Avenger> DeleteAvenger(int id);

    }
}