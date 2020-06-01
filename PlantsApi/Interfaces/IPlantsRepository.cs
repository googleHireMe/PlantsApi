using System.Collections.Generic;
using PlantsApi.Models;
using PlantsApi.Models.DbModels;
using PlantsApi.Models.Dtos;

namespace PlantsApi.Repository
{
    public interface IPlantsRepository
    {
        Plant GetPlant(int id);
        IEnumerable<Plant> GetPlants();
        IEnumerable<Plant> SearchPlants(PlantsPagedQueryDto query);
    }
}
