using PlantsApi.Database;
using PlantsApi.Interfaces;
using PlantsApi.Models;
using PlantsApi.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantsApi.Repository
{
	public class PlantAssigmentsRepository : IPlantAssigmentsRepository
	{
		private readonly PlantsContext db;

		public PlantAssigmentsRepository(PlantsContext db)
		{
			this.db = db;
		}


		public void LinkUserToPlant(int userId, int plantId, string serialNumber)
		{
			// TODO: Use serial number
			var deviceId = db.Devices.First(d => d.SerialNumber == serialNumber).Id;
			var entity = new PlantAssignment(userId, plantId, deviceId);
			db.PlantAssignments.Add(entity);
			db.SaveChanges();
		}

		public void DeleteLinkUserToPlant(int userId, int plantId)
		{
			var toDelete = db.PlantAssignments.SingleOrDefault(pa => pa.UserId == userId && pa.PlantId == plantId);
			db.Remove(toDelete);
			db.SaveChanges();
		}
	}
}
