using PlantsApi.Database;
using PlantsApi.Interfaces;
using PlantsApi.Models;
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
			return db.PlantStates.SingleOrDefault(ps => ps.Id == id);
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
