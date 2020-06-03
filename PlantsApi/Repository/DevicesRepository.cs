using Microsoft.EntityFrameworkCore;
using PlantsApi.Database;
using PlantsApi.Interfaces;
using PlantsApi.Models.DbModels;
using PlantsApi.Models.Dtos;
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

        public ConditionIndicatorsDto GetConditionIndicators(DeviceInfoDto state)
        { 
            var plantInfo = db.Devices
                .Include(d => d.Plant)
                .Single(d => d.SerialNumber == state.SerialNumber)
                .Plant;

            var result = new ConditionIndicatorsDto
            {
                isEnvHumidOk = state.EnvHumid > plantInfo.MinEnvHumid && state.EnvHumid < plantInfo.MaxEnvHumid,
                isLightOk = state.Light > plantInfo.MinLightLux && state.Light < plantInfo.MaxLightLux,
                isSoilEcOk = state.SoilEc > plantInfo.MinSoilEc && state.SoilEc < plantInfo.MaxSoilEc,
                isSoilMoistOk = state.SoilMoist > plantInfo.MinSoilMoist && state.SoilMoist < plantInfo.MaxSoilMoist,
                isTempOk = state.Temp > plantInfo.MinTemperature && state.Temp < plantInfo.MaxTemperature
            };
            return result;
        }
    }
}
