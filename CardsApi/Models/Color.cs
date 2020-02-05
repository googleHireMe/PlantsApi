using System.ComponentModel.DataAnnotations.Schema;

namespace PlantsApi.Models
{
	public class Color
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }
		public string Description { get; set; }
		public string Value { get; set; }
	}
}
