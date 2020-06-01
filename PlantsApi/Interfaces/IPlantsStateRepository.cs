using PlantsApi.Models;
using PlantsApi.Models.DbModels;
using PlantsApi.Models.Dtos;
using System.Collections.Generic;

namespace PlantsApi.Interfaces
{
	public interface IPlantsStateRepository
	{
		PlantStateResponceDto GetPlantState(int id);
		IEnumerable<PlantStateResponceDto> GetPlantStatesForUser(int userId);

		// created with first request from device
		PlantState CreateOrUpdatePlantState(PlantState plantState);
	}
}
