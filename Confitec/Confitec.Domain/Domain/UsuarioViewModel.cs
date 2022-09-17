using Confitec.Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Domain.Domain
{
	public class UsuarioViewModel
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Sobrenome { get; set; }
		public string Email { get; set; }
		public DateTime DataNascimento { get; set; }
		public EscolaridadeEnum Escolaridade { get; set; }
	}

	public class AdicionarUsuarioViewModel
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string Nome { get; set; }

		[Required]
		public string Sobrenome { get; set; }

		[Required]
		[DateRangeAttribute]
		public DateTime DataNascimento { get; set; }

		[Required]
		public EscolaridadeEnum Escolaridade { get; set; }
	}

	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
	internal sealed class DateRangeAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
		{

			if ((DateTime)value > DateTime.Now.Date)
				return false;

			return true;
		}
	}

		public class AtualizarUsuarioViewModel
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		[EmailAddress]
		public string Email { get; set; }
		public string Nome { get; set; }
		public string Sobrenome { get; set; }
		public DateTime DataNascimento { get; set; }
		public EscolaridadeEnum Escolaridade { get; set; }
	}
}
