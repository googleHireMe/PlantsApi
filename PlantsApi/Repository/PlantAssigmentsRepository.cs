using PlantsApi.Database;
using PlantsApi.Interfaces;
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


		public void LinkUserToPlant(int userId, int plantId)
		{
			throw new NotImplementedException();
		}

		public void DeleteLinkUserToPlant(int userId, int plantId)
		{
			throw new NotImplementedException();
		}
	}
}
