using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantsApi.Models
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

        public int PlantId { get; set; }
        public Plant Plant { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

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
                PlantId = dto.PlantId,
                UserId = dto.UserId
            };
        }
    }

}
