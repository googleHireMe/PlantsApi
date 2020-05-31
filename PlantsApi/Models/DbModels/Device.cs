using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantsApi.Models.DbModels
{
    public class Device
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SerialNumber { get; set; }
    }
}
