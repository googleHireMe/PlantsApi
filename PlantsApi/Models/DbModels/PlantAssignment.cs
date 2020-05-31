namespace PlantsApi.Models.DbModels
{
    public class PlantAssignment
    {
        public int PlantId { get; set; }
        public int UserId { get; set; }
        public int DeviceId { get; set; }
        public Plant Plant { get; set; }
        public User User { get; set; }
        public Device Device { get; set; }

        public PlantAssignment(int userId, int plantId, int deviceId)
        {
            this.UserId = userId;
            this.PlantId = plantId;
            this.DeviceId = deviceId;
        }
    }
}
