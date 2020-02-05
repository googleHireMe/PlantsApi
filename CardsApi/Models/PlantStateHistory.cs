using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantsApi.Models
{
    public class PlantStateHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int Light { get; set; }
        public int Temp { get; set; }
        public int EnvHumid{ get; set; }
        public int SoilMoist { get; set; }
        public int SoilEc { get; set; }

        public int PlantID { get; set; }
        public Plant Plant { get; set; }
    }

}
