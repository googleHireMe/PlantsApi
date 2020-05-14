using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantsApi.Models.ViewModels
{
    public class DeviceInfoDto
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public int PlantId { get; set; }
        public int Light { get; set; }
        public int Temp { get; set; }
        public int EnvHumid { get; set; }
        public int SoilMoist { get; set; }
        public int SoilEc { get; set; }

        public static PlantState MapToPlantState(DeviceInfoDto dto, int userId)
        {
            return new PlantState
            {
                Time = DateTime.Now,
                Light = dto.Light,
                Temperature = dto.Temp,
                EnvHumid = dto.EnvHumid,
                SoilMoist = dto.SoilMoist,
                SoilEc = dto.SoilEc,
                PlantId = dto.PlantId,
                UserId = userId
            };
        }
    }
}
