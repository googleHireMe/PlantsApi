using PlantsApi.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantsApi.Interfaces
{
    public interface IDevicesRepository
    {
        public Device GetDevice(int id);
        public Device GetDevice(string serialNumber);
    }
}
