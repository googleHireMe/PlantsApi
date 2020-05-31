using System.Collections.Generic;
using PlantsApi.Models;
using PlantsApi.Models.DbModels;
using PlantsApi.Models.ViewModels;

namespace PlantsApi.Repository
{
    public interface IPlantsRepository
    {
        Plant GetPlant(int id);
        IEnumerable<Plant> GetPlants();
        Plant CreatePlant(Plant plant);
        void UpdatePlant(Plant plant);
        void DeletePlant(int id);
        IEnumerable<Plant> SearchPlants(PlantsPagedQueryDto query);
    }
}
