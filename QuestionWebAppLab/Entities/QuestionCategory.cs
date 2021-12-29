using System.ComponentModel.DataAnnotations;

namespace QuestionWebAppLab.Entities
{
	public class QuestionCategory
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Code { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[Required]
		public int Orders { get; set; }
	}
}
