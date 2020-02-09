using Microsoft.EntityFrameworkCore;
using PlantsApi.Database;
using PlantsApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlantsApi.Repository
{
	public class PlantsRepositiry : IPlantsRepository
	{
		private readonly PlantsContext db;

		public PlantsRepositiry(PlantsContext db)
		{
			this.db = db;
		}

		public Plant GetPlant(int id)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<Plant> GetPlants()
		{
			throw new System.NotImplementedException();
		}

		public Plant CreatePlant(Plant plant)
		{
			throw new System.NotImplementedException();
		}
		public void UpdatePlant(Plant plant)
		{
			throw new System.NotImplementedException();
		}

		public void DeletePlant(int id)
		{
			throw new System.NotImplementedException();
		}

	}
}
