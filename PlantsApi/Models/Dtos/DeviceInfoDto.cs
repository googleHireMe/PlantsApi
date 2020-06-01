using PlantsApi.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantsApi.Models.Dtos
{
    public class DeviceInfoDto
    {
        public int Light { get; set; }
        public int Temp { get; set; }
        public int EnvHumid { get; set; }
        public int SoilMoist { get; set; }
        public int SoilEc { get; set; }
        public int Battery { get; set; }
        public int WaterRemained { get; set; }
        public string SerialNumber { get; set; }

        public static PlantState MapToPlantState(DeviceInfoDto dto, int deviceId)
        {
            return new PlantState
            {
                Time = DateTime.Now,
                Light = dto.Light,
                Temperature = dto.Temp,
                EnvHumid = dto.EnvHumid,
                SoilMoist = dto.SoilMoist,
                SoilEc = dto.SoilEc,
                Battery = dto.Battery,
                WaterRemained = dto.WaterRemained,
                DeviceId = deviceId
            };
        }
    }
}
