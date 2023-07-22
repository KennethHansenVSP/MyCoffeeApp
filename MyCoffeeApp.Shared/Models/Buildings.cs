using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoffeeApp.Shared.Models
{
    public class Buildings
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
