using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionWebAppLab.Entities
{
	public class QuestioniOption
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[ForeignKey(nameof(Question))]
		public int QuestionId { get; set; }

		public Question Question { get; set; }

		[Required]
		[StringLength(1000)]
		public string Content { get; set; }

		[Required]
		[StringLength(1000)]
		public string Feedback { get; set; }

		[Required]
		public int Orders { get; set; }

		[Required]
		public bool IsAnswer { get; set; }
	}
}
