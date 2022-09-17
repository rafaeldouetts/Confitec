using Confitec.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Entity.Context
{
	public class ConfitecContext : DbContext
	{

		public ConfitecContext(DbContextOptions<ConfitecContext> options)
			: base(options)
		{
		}

		public DbSet<Usuario> Usuarios { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
		{
			const string strConnection = "Data Source=DESKTOP-1RSBIR4\\SQLEXPRESS;Initial Catalog=Confitec;Trusted_Connection=True;MultipleActiveResultSets=True;";

			optionBuilder.UseSqlServer(strConnection);
		}
	}
}
