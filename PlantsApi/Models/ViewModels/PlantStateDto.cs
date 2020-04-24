using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantsApi.Models.ViewModels
{
    public class PlantStateDto
    {
        public int Id { get; set; }
        public int Light { get; set; }
        public int Temp { get; set; }
        public int EnvHumid { get; set; }
        public int SoilMoist { get; set; }
        public int SoilEc { get; set; }
        public int PlantId { get; set; }
        public int UserId { get; set; }
    }
}
