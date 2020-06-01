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
	public class PlantsStateRepository : IPlantsStateRepository
	{
		private readonly PlantsContext db;

		public PlantsStateRepository(PlantsContext db)
		{
			this.db = db;
		}


		public PlantStateResponceDto GetPlantState(int id)
		{
			var plantState = db.PlantStates
				.Include(ps => ps.Device)
				.SingleOrDefault(ps => ps.Id == id);
			var result = new PlantStateResponceDto
			{
				Plant = new PlantDto(plantState.Device.Plant),
				PlantState = new PlantStateDto(plantState.Device.PlantState)
			};
			return result;
		}

		public IEnumerable<PlantStateResponceDto> GetPlantStatesForUser(int userId)
		{
			var user = db.Users
				.Include(u => u.Devices).ThenInclude(d => d.Plant)
				.Include(u => u.Devices).ThenInclude(d => d.PlantState)
				.FirstOrDefault(u => u.Id == userId);

			var result = user.Devices
				.Where(d => d.Plant != null && d.PlantState != null)
				.Select(d =>
					new PlantStateResponceDto
					{
						Plant = new PlantDto(d.Plant),
						PlantState = new PlantStateDto(d.PlantState)
					})
				.ToList();

			return result;
		}

        public PlantState CreateOrUpdatePlantState(PlantState plantState)
        {
            var existingPlantState = db.PlantStates
                .SingleOrDefault(ps => ps.DeviceId == plantState.DeviceId);
            if (existingPlantState == null)
            {
                db.PlantStates.Add(plantState);
            }
            else
            {
                PlantState.Update(existingPlantState, plantState);
            }
            db.SaveChanges();
            return plantState;
        }

	}
}
