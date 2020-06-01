using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantsApi.Models.DbModels
{
    public class PlantState
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int Light { get; set; }
        public int Temperature { get; set; }
        public int EnvHumid{ get; set; }
        public int SoilMoist { get; set; }
        public int SoilEc { get; set; }
        public int Battery { get; set; }
        public int WaterRemained { get; set; }

        public int DeviceId { get; set; }
        public Device Device { get; set; }

        public static PlantState Clone(PlantState dto)
        {
            return new PlantState
            {
                Id = dto.Id,
                Time = dto.Time,
                Light = dto.Light,
                Temperature = dto.Temperature,
                EnvHumid = dto.EnvHumid,
                SoilMoist = dto.SoilMoist,
                SoilEc = dto.SoilEc,
                Battery = dto.Battery,
                WaterRemained = dto.WaterRemained,
                DeviceId = dto.DeviceId
            };
        }

        public static void Update(PlantState value, PlantState updatedValue)
        {
            value.Time = updatedValue.Time;
            value.Light = updatedValue.Light;
            value.Temperature = updatedValue.Temperature;
            value.EnvHumid = updatedValue.EnvHumid;
            value.SoilMoist = updatedValue.SoilMoist;
            value.SoilEc = updatedValue.SoilEc;
            value.Battery = updatedValue.Battery;
            value.WaterRemained = updatedValue.WaterRemained;
            value.DeviceId = updatedValue.DeviceId;
        }
    }

}
