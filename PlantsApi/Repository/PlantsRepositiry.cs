using Microsoft.EntityFrameworkCore;
using PlantsApi.Database;
using PlantsApi.Models;
using PlantsApi.Models.DbModels;
using PlantsApi.Models.ViewModels;
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
			return db.Plants.SingleOrDefault(p => p.Id == id);
		}

		public IEnumerable<Plant> GetPlants()
		{
			return db.Plants;
		}

		public Plant CreatePlant(Plant plant)
		{
			db.Add(plant);
			db.SaveChanges();
			return plant;
		}
		public void UpdatePlant(Plant plant)
		{
			var toUpdate = db.Plants.SingleOrDefault(p => p.Id == plant.Id);
			Plant.Update(toUpdate, plant);
			db.SaveChanges();
		}

		public void DeletePlant(int id)
		{
			var toRemove = db.Plants.First(p => p.Id == id);
			db.Remove(toRemove);
			db.SaveChanges();
		}

		public IEnumerable<Plant> SearchPlants(PlantsPagedQueryDto query)
		{
			if (!string.IsNullOrEmpty(query.Filter))
			{
                return db.Plants
					.Where(p => p.Name.Contains(query.Filter))
					.OrderBy(p => p.Name);
            }
			else
			{
				return db.Plants.OrderBy(p => p.Name);
			}
		}

	}
}
