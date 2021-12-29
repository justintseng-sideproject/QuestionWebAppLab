using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionWebAppLab.Entities
{

	public class Question
	{
		[Key,]
		public int Id { get; set; }

		[ForeignKey(nameof(QuestionCategory))]
		public int QuestionCategoryId { get; set; }

		public QuestionCategory QuestionCategory { get; set; }

		[Required]
		[StringLength(1000)]
		public string Content { get; set; }

		[Required]
		public int Orders { get; set; }

		[Required]
		public int Status { get; set; }
	}
}
