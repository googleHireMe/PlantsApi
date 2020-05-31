namespace PlantsApi.Interfaces
{
	public interface IPlantAssigmentsRepository
	{
		void LinkUserToPlant(int userId, int plantId, string SerialNumber);
		void DeleteLinkUserToPlant(int userId, int plantId);
	}
}
