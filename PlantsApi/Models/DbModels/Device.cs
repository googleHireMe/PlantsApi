using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantsApi.Models.DbModels
{
    public class Device
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SerialNumber { get; set; }

        public int? PlantId { get; set; }
        public Plant Plant { get; set; }
        public PlantState PlantState { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
