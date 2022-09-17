using Confitec.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Domain.Services.Interfaces
{
	public interface IUsuarioService
	{
		Task<UsuarioViewModel> Adicionar(AdicionarUsuarioViewModel usuario);
		Task<UsuarioViewModel> Atualizar(UsuarioViewModel view);
		List<UsuarioViewModel> Listar();
		Task Remover(int id);
	}
}
