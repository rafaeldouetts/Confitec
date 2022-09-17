using Confitec.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Entity.Repository.Interfaces
{
	public interface IUsuarioRepository
	{
		Task<Usuario> Adicionar(Usuario usuario);
		Task<Usuario> Alterar(Usuario usuario);
		Task<List<Usuario>> Listar();
		Task<Usuario> Excluir(Usuario usuario);
		Task<Usuario> Selecionar(int id);
		void Salvar();
	}
}
