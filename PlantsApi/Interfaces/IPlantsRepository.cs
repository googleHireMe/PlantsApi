using System.Collections.Generic;
using PlantsApi.Models;

namespace PlantsApi.Repository
{
    public interface IPlantsRepository
    {
        Plant GetPlant(int id);
        IEnumerable<Plant> GetPlants();
        Plant CreatePlant(Plant plant);
        void UpdatePlant(Plant plant);
        void DeletePlant(int id);
    }
}
