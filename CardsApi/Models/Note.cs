using CardsApi.Models;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesApi.Models
{
	public class Note
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool Status { get; set; }
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime Date { get; set; }
		public int PriorityID { get; set; }
		public int ColorID { get; set; }

		public Priority Priority { get; set; }
		public Color Color { get; set; }
	}
}
