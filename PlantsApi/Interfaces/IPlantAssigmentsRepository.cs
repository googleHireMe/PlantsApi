namespace PlantsApi.Interfaces
{
	public interface IPlantAssigmentsRepository
	{
		void LinkUserToPlant(int userId, int plantId);
		void DeleteLinkUserToPlant(int userId, int plantId);
	}
}
