namespace PlantsApi.Models
{
    public class PlantAssignment
    {
        public int PlantID { get; set; }
        public int UserID { get; set; }
        public Plant Plant { get; set; }
        public User User { get; set; }
    }
}
