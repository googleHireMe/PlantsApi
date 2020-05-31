using Microsoft.EntityFrameworkCore;
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
	public class PlantsStateRepository : IPlantsStateRepository
	{
		private readonly PlantsContext db;

		public PlantsStateRepository(PlantsContext db)
		{
			this.db = db;
		}


		public PlantState GetPlantState(int id)
		{
			var result = db.PlantStates
				.Include(ps => ps.Plant)
				.SingleOrDefault(ps => ps.Id == id);
			result.User = null;
			return result;
		}

        public IEnumerable<PlantState> GetPlantStatesForUser(int userId)
        {
            var result = db.PlantStates
                        .Include(ps => ps.Plant)
                        .Where(ps => ps.UserId == userId)
                        .ToList();
			result.ForEach(ps => ps.User = null);
			return result;
        }

        public IEnumerable<PlantState> GetPlantStates()
		{
			return db.PlantStates;
		}


		public PlantState CreatePlantState(PlantState plantState)
		{
			db.PlantStates.Add(plantState);
			db.SaveChanges();
			return plantState;
		}

		public void UpdatePlantState(PlantState plantState)
		{
			// TODO: impl update
			throw new NotImplementedException();
		}


		public void DeletePlantState(int id)
		{
			var toDelete = db.PlantStates.Single(ps => ps.Id == id);
			db.Remove(toDelete);
			db.SaveChanges();
		}

	}
}
