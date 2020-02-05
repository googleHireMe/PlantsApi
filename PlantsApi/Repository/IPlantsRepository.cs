using System.Collections.Generic;
using PlantsApi.Models;

namespace PlantsApi.Repository
{
    public interface IPlantsRepository
    {
        Plant GetPlant(int id);
        IEnumerable<Plant> GetPlants();

        PlantStateHistory GetPlantStateHistory(int id);
        IEnumerable<PlantStateHistory> GetPlantStateHistories();

    }
}
