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
			throw new NotImplementedException();
		}

		public IEnumerable<PlantState> GetPlantStates()
		{
			throw new NotImplementedException();
		}


		public PlantState CreatePlantState(PlantState plantState)
		{
			throw new NotImplementedException();
		}

		public void UpdatePlantState(PlantState plantState)
		{
			throw new NotImplementedException();
		}


		public void DeletePlantState(int id)
		{
			throw new NotImplementedException();
		}

	}
}
