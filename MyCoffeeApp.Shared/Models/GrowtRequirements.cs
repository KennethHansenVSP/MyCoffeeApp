using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoffeeApp.Shared.Models
{
    public class GrowtRequirements
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int BuildingID { get; set; }
        public string BuildingName { get; set; }
        public int BuildingLevel { get; set; }
        public double Food { get; set; }
        public double Wood { get; set; }
        public double Stone { get; set; }
        public double Iron { get; set; }
        public double Azurite { get; set; }
        public string Dependencies { get; set; }
    }
}
