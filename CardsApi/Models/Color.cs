using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CardsApi.Models
{
	public class Color
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }
		public string Description { get; set; }
		public string Value { get; set; }
	}
}
