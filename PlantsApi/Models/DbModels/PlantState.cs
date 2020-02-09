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
        public int Temp { get; set; }
        public int EnvHumid{ get; set; }
        public int SoilMoist { get; set; }
        public int SoilEc { get; set; }

        public int PlantId { get; set; }
        public Plant Plant { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }

}
