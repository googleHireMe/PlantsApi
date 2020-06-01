using System;
using PlantsApi.Models.DbModels;


namespace PlantsApi.Models.Dtos
{
    public class PlantStateDto
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int Light { get; set; }
        public int Temperature { get; set; }
        public int EnvHumid { get; set; }
        public int SoilMoist { get; set; }
        public int SoilEc { get; set; }
        public int Battery { get; set; }
        public int WaterRemained { get; set; }

        public int DeviceId { get; set; }
        public Device Device { get; set; }

        public PlantStateDto(PlantState plantState)
        {
            Id = plantState.Id;
            Time = plantState.Time;
            Light = plantState.Light;
            Temperature = plantState.Temperature;
            EnvHumid = plantState.EnvHumid;
            SoilMoist = plantState.SoilMoist;
            SoilEc = plantState.SoilEc;
            Battery = plantState.Battery;
            WaterRemained = plantState.WaterRemained;
            DeviceId = plantState.DeviceId;
        }
    }
}
