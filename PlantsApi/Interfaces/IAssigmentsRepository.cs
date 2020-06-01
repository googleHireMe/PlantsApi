using PlantsApi.Models.Dtos;
using System.Collections.Generic;

namespace PlantsApi.Interfaces
{
	public interface IAssigmentsRepository
	{
		List<DeviceDto> GetUserDevices(int userId);
		void LinkDeviceToUser(int userId, string serialNumber);
		void LinkPlantToDevice(string serialNumber, int plantId);
		void UnlinkDeviceFromUser(int userId, string serialNumber);
		void UnlinkPlantFromDevice(string serialNumber);
		bool HasUserAccessToDevice(int userId, string serialNumber);
	}
}
