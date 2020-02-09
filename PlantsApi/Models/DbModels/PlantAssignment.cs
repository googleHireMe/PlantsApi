namespace PlantsApi.Models
{
    public class PlantAssignment
    {
        public int PlantId { get; set; }
        public int UserId { get; set; }
        public Plant Plant { get; set; }
        public User User { get; set; }

        public PlantAssignment(int userId, int plantId)
        {
            this.UserId = userId;
            this.PlantId = plantId;
        }
    }
}
