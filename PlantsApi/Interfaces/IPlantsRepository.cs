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

        PlantState GetPlantState(int id);
        IEnumerable<PlantState> GetPlantStates();
        PlantState CreatePlantState(PlantState plantState);
        void UpdatePlantState(PlantState plantState);
        void DeletePlantState(int id);

        User GetUser(int id);
        User GetUser(string guid);
        IEnumerable<User> GetUsers();

        void LinkUserToPlant(int userId, int plantId);
        void DeleteLinkUserToPlant(int userId, int plantId);

    }
}
