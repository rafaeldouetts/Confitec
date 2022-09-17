using Confitec.Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Entity.Entity
{
	[Table("Usuarios")]
	public class Usuario
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Sobrenome { get; set; }
		public string Email { get; set; }
		public DateTime DataNascimento { get; set; }
		public EscolaridadeEnum Escolaridade { get; set; }
	}
}
