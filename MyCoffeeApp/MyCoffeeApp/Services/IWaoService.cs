using MyCoffeeApp.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCoffeeApp.Services
{
    public interface IWaoService
    {
        Task<IEnumerable<Buildings>> GetBuildings();
        Task<Buildings> GetBuilding(int id);
        Task<IEnumerable<GrowtRequirements>> GetGrowtRequirements(int id, int level = 0);
        Task<IEnumerable<BuildingLevels>> GetBuildingLevels();
    }
}