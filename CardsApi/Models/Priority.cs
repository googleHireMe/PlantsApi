using System.ComponentModel.DataAnnotations.Schema;

namespace PlantsApi.Models
{
	public class Priority
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }
		public string Description { get; set; }
		public int Value { get; set; }
	}
}
