using MyCoffeeApp.Services;
using MyCoffeeApp.Shared.Models;
using SQLite;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly:Dependency(typeof(WaoService))]
namespace MyCoffeeApp.Services
{
    public class WaoService : IWaoService
    {
        SQLiteAsyncConnection db;
        

        async Task Init()
        {
            if (db != null)
                return;

            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "WAOHelper.db");

            db = new SQLiteAsyncConnection(databasePath);
            //await db.DropTableAsync<BuildingLevels>();
            //await db.DropTableAsync<Buildings>();
            //await db.DropTableAsync<GrowtRequirements>();
            await db.CreateTableAsync<BuildingLevels>();
            await db.CreateTableAsync<Buildings>();
            await db.CreateTableAsync<GrowtRequirements>();
            await InsertData();
        }

        public async Task<IEnumerable<Buildings>> GetBuildings()
        {
            await Init();

            var building = await db.Table<Buildings>().ToListAsync();
            return building;
        }

        public async Task<Buildings> GetBuilding(int id)
        {
            await Init();

            var building = await db.Table<Buildings>()
                .FirstOrDefaultAsync(c => c.Id == id);

            return building;
        }

        public async Task<IEnumerable<GrowtRequirements>> GetGrowtRequirements(int id, int level = 0)
        {
            await Init();
            List<GrowtRequirements> growtrequirements;
            if (level == 0)
                growtrequirements = await db.Table<GrowtRequirements>().Where(c => c.BuildingID == id).ToListAsync();
            else
                growtrequirements = await db.Table<GrowtRequirements>().Where(c => c.BuildingID == id & c.BuildingLevel == level).ToListAsync();
            return growtrequirements;
        }

        public async Task<IEnumerable<BuildingLevels>> GetBuildingLevels()
        {
            await Init();

            var buildingLevels = await db.Table<BuildingLevels>().ToListAsync();
            return buildingLevels;
        }
        public async Task InsertData()
        {
            if ((await db.Table<BuildingLevels>().CountAsync()) == 0)
            {
                //only insert the data if it doesn't already exist
                var newBuilding = new BuildingLevels
                {
                    Level = 0,
                    LevelName = "All",
                };
                await db.InsertAsync(newBuilding);
                newBuilding = new BuildingLevels
                {
                    Level = 31,
                    LevelName = "31",
                };
                await db.InsertAsync(newBuilding);
                newBuilding = new BuildingLevels
                {
                    Level = 32,
                    LevelName = "32",
                };
                await db.InsertAsync(newBuilding);
                newBuilding = new BuildingLevels
                {
                    Level = 33,
                    LevelName = "33",
                };
                await db.InsertAsync(newBuilding);
                newBuilding = new BuildingLevels
                {
                    Level = 34,
                    LevelName = "34",
                };
                await db.InsertAsync(newBuilding);
                newBuilding = new BuildingLevels
                {
                    Level = 35,
                    LevelName = "35",
                };
                await db.InsertAsync(newBuilding);
                newBuilding = new BuildingLevels
                {
                    Level = 36,
                    LevelName = "36",
                };
                await db.InsertAsync(newBuilding);
                newBuilding = new BuildingLevels
                {
                    Level = 37,
                    LevelName = "37",
                };
                await db.InsertAsync(newBuilding);
                newBuilding = new BuildingLevels
                {
                    Level = 38,
                    LevelName = "38",
                };
                await db.InsertAsync(newBuilding);
                newBuilding = new BuildingLevels
                {
                    Level = 39,
                    LevelName = "39",
                };
                await db.InsertAsync(newBuilding);
                newBuilding = new BuildingLevels
                {
                    Level = 40,
                    LevelName = "40",
                };
                await db.InsertAsync(newBuilding);
            }

            if ((await db.Table<Buildings>().CountAsync()) == 0)
            {
                //only insert the data if it doesn't already exist
                var newBuilding = new Buildings
                {
                    Name = "Castle"
                };
                await db.InsertAsync(newBuilding);
                newBuilding = new Buildings
                {
                    Name = "Wall"
                };
                await db.InsertAsync(newBuilding);
                newBuilding = new Buildings
                {
                    Name = "Barracks"
                };
                await db.InsertAsync(newBuilding);
                newBuilding = new Buildings
                {
                    Name = "Drill Ground"
                };
                await db.InsertAsync(newBuilding);
                newBuilding = new Buildings
                {
                    Name = "Embassy"
                };
                await db.InsertAsync(newBuilding);
                newBuilding = new Buildings
                {
                    Name = "Depot"
                };
                await db.InsertAsync(newBuilding);
                newBuilding = new Buildings
                {
                    Name = "Hospital"
                };
                await db.InsertAsync(newBuilding);
                newBuilding = new Buildings
                {
                    Name = "Blacksmith"
                };
                await db.InsertAsync(newBuilding);
                newBuilding = new Buildings
                {
                    Name = "College"
                };
                await db.InsertAsync(newBuilding);
            }
            if ((await db.Table<GrowtRequirements>().CountAsync()) == 0)
            {
                //only insert the data if it doesn't already exist
                var newRequirement = new GrowtRequirements
                {
                    BuildingID = 1,
                    BuildingName = "Castle",
                    BuildingLevel = 31,
                    Food = 182.3,
                    Wood = 182.3,
                    Stone = 39.52,
                    Iron = 19.76,
                    Azurite = 4810,
                    Dependencies = "Wall and Blacksmith"
                };
                await db.InsertAsync(newRequirement);
                newRequirement = new GrowtRequirements
                {
                    BuildingID = 1,
                    BuildingLevel = 32,
                    BuildingName = "Castle",
                    Food = 216.72,
                    Wood = 216.72,
                    Stone = 50.88,
                    Iron = 19.76,
                    Azurite = 8620,
                    Dependencies = "Wall and Drill Grounds"
                };
                await db.InsertAsync(newRequirement);
                newRequirement = new GrowtRequirements
                {
                    BuildingID = 1,
                    BuildingLevel = 33,
                    BuildingName = "Castle",
                    Food = 216.72,
                    Wood = 216.72,
                    Stone = 50.88,
                    Iron = 19.76,
                    Azurite = 8620,
                    Dependencies = "Wall and Drill Grounds"
                };
                await db.InsertAsync(newRequirement);
                newRequirement = new GrowtRequirements
                {
                    BuildingID = 1,
                    BuildingLevel = 34,
                    BuildingName = "Castle",
                    Food = 216.72,
                    Wood = 216.72,
                    Stone = 50.88,
                    Iron = 19.76,
                    Azurite = 8620,
                    Dependencies = "Wall and Drill Grounds"
                };
                await db.InsertAsync(newRequirement);
                newRequirement = new GrowtRequirements
                {
                    BuildingID = 1,
                    BuildingLevel = 35,
                    BuildingName = "Castle",
                    Food = 216.72,
                    Wood = 216.72,
                    Stone = 50.88,
                    Iron = 19.76,
                    Azurite = 8620,
                    Dependencies = "Wall and Drill Grounds"
                };
                await db.InsertAsync(newRequirement);
                newRequirement = new GrowtRequirements
                {
                    BuildingID = 1,
                    BuildingLevel = 36,
                    BuildingName = "Castle",
                    Food = 216.72,
                    Wood = 216.72,
                    Stone = 50.88,
                    Iron = 19.76,
                    Azurite = 8620,
                    Dependencies = "Wall and Drill Grounds"
                };
                await db.InsertAsync(newRequirement);
                newRequirement = new GrowtRequirements
                {
                    BuildingID = 1,
                    BuildingLevel = 37,
                    BuildingName = "Castle",
                    Food = 216.72,
                    Wood = 216.72,
                    Stone = 50.88,
                    Iron = 19.76,
                    Azurite = 8620,
                    Dependencies = "Wall and Drill Grounds"
                };
                await db.InsertAsync(newRequirement);
                newRequirement = new GrowtRequirements
                {
                    BuildingID = 1,
                    BuildingLevel = 38,
                    BuildingName = "Castle",
                    Food = 216.72,
                    Wood = 216.72,
                    Stone = 50.88,
                    Iron = 19.76,
                    Azurite = 8620,
                    Dependencies = "Wall and Drill Grounds"
                };
                await db.InsertAsync(newRequirement);
                newRequirement = new GrowtRequirements
                {
                    BuildingID = 1,
                    BuildingLevel = 39,
                    BuildingName = "Castle",
                    Food = 216.72,
                    Wood = 216.72,
                    Stone = 50.88,
                    Iron = 19.76,
                    Azurite = 8620,
                    Dependencies = "Wall and Drill Grounds"
                };
                await db.InsertAsync(newRequirement);
                newRequirement = new GrowtRequirements
                {
                    BuildingID = 1,
                    BuildingLevel = 40,
                    BuildingName = "Castle",
                    Food = 216.72,
                    Wood = 216.72,
                    Stone = 50.88,
                    Iron = 19.76,
                    Azurite = 8620,
                    Dependencies = "Wall and Drill Grounds"
                };
                await db.InsertAsync(newRequirement);
            }
        }
    }
}
