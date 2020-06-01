using PlantsApi.Database;
using PlantsApi.Interfaces;
using PlantsApi.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantsApi.Repository
{
    public class DevicesRepository : IDevicesRepository
    {
        private readonly PlantsContext db;

        public DevicesRepository(PlantsContext db)
        {
            this.db = db;
        }

        public Device GetDevice(int id)
        {
            var device = db.Devices.FirstOrDefault(d => d.Id == id);
            return device;
        }

        public Device GetDevice(string serialNumber)
        {
            var device = db.Devices.FirstOrDefault(d => d.SerialNumber == serialNumber);
            return device;
        }

        public void CreatePlantState()
        {

        }
    }
}
