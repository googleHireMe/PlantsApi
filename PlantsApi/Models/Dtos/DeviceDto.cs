using PlantsApi.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantsApi.Models.Dtos
{
    public class DeviceDto
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public int? PlantId { get; set; }

        public DeviceDto(Device device)
        {
            Id = device.Id;
            SerialNumber = device.SerialNumber;
            PlantId = device.PlantId;
        }
    }
}
