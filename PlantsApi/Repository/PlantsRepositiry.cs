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

		public Plant CreatePlant(Plant plant)
		{
			throw new System.NotImplementedException();
		}

		public PlantState CreatePlantState(PlantState plantState)
		{
			throw new System.NotImplementedException();
		}

		public void DeleteLinkUserToPlant(int userId, int plantId)
		{
			throw new System.NotImplementedException();
		}

		public void DeletePlant(int id)
		{
			throw new System.NotImplementedException();
		}

		public void DeletePlantState(int id)
		{
			throw new System.NotImplementedException();
		}

		public Plant GetPlant(int id)
		{
			return db.Plants.SingleOrDefault(p => p.Id == id);
		}

		public IEnumerable<Plant> GetPlants()
		{
			return db.Plants;
		}

		public PlantState GetPlantState(int id)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<PlantState> GetPlantStateHistories()
		{
			throw new System.NotImplementedException();
		}

		public PlantState GetPlantStateHistory(int id)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<PlantState> GetPlantStates()
		{
			throw new System.NotImplementedException();
		}

		public User GetUser(int id)
		{
			throw new System.NotImplementedException();
		}

		public User GetUser(string guid)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<User> GetUsers()
		{
			throw new System.NotImplementedException();
		}

		public void LinkUserToPlant(int userId, int plantId)
		{
			throw new System.NotImplementedException();
		}

		public void UpdatePlant(Plant plant)
		{
			throw new System.NotImplementedException();
		}

		public void UpdatePlantState(PlantState plantState)
		{
			throw new System.NotImplementedException();
		}
	}
}
