using PlantsApi.Models.DbModels;
using PlantsApi.Models.Dtos;

namespace PlantsApi.Interfaces
{
    public interface IDevicesRepository
    {
        public Device GetDevice(int id);
        public Device GetDevice(string serialNumber);
        public ConditionIndicatorsDto GetConditionIndicators(DeviceInfoDto state);
    }
}
