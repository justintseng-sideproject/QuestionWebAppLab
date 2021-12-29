using Microsoft.EntityFrameworkCore;
using QuestionWebAppLab.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionWebAppLab.DbContexts
{
	public class QuestionDbContext : DbContext
	{
		public QuestionDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Question> Question { get; set; }
		
		public DbSet<QuestionCategory> QuestionCategory { get; set; }
		
		public DbSet<QuestioniOption> QuestioniOption { get; set; }
	}
}
