using Microsoft.EntityFrameworkCore;
using PlantsApi.Database;
using PlantsApi.Interfaces;
using PlantsApi.Models;
using PlantsApi.Models.DbModels;
using PlantsApi.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantsApi.Repository
{
	public class AssigmentsRepository : IAssigmentsRepository
	{
		private readonly PlantsContext db;

		public AssigmentsRepository(PlantsContext db)
		{
			this.db = db;
		}

		public List<DeviceDto> GetUserDevices(int userId)
		{
			var userDevices = db.Users.Include(u => u.Devices)
				.Single(u => u.Id == userId)
				.Devices;
			return userDevices.Select(d => new DeviceDto(d)).ToList();
		}

		public void LinkDeviceToUser(int userId, string serialNumber)
		{
			var device = db.Devices.Single(d => d.SerialNumber == serialNumber);
			device.UserId = userId;
			db.SaveChanges();
		}

		public void LinkPlantToDevice(string serialNumber, int plantId)
		{
			var device = db.Devices.Single(d => d.SerialNumber == serialNumber);
			device.PlantId = plantId;
			db.SaveChanges();
		}

		public void UnlinkDeviceFromUser(int userId, string serialNumber)
		{
			var device = db.Devices.Single(d => d.SerialNumber == serialNumber);
			device.UserId = null;
			db.SaveChanges();
		}

		public void UnlinkPlantFromDevice(string serialNumber)
		{
			var device = db.Devices.Single(d => d.SerialNumber == serialNumber);
			device.PlantId = null;
			db.SaveChanges();
		}

		public bool HasUserAccessToDevice(int userId, string serialNumber)
		{
			var device = db.Devices.Single(d => d.SerialNumber == serialNumber);
			return device.UserId == userId;
		}
	}
}
