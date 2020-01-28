using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CardsApi.Models
{
	public class Priority
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }
		public string Description { get; set; }
		public int Value { get; set; }
	}
}
