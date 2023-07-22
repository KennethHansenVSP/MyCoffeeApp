using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoffeeApp.Shared.Models
{
    public class BuildingLevels
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Level { get; set; }
        public string LevelName { get; set; }
    }
}
