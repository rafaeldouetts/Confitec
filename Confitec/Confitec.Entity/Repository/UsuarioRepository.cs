using Confitec.Entity.Context;
using Confitec.Entity.Entity;
using Confitec.Entity.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Entity.Repository
{
	public class UsuarioRepository : IUsuarioRepository
	{
		private readonly ConfitecContext _context;

		public UsuarioRepository(ConfitecContext context)
		{
			_context = context;
		}

		private ConfitecContext _appContext => (ConfitecContext)_context;

		public async Task<Usuario> Adicionar(Usuario usuario)
		{
			await _context.Usuarios.AddAsync(usuario);

			return usuario;
		}

		public Task<Usuario> Alterar(Usuario usuario)
		{
			_context.Usuarios.Update(usuario);

			return Task.FromResult(usuario);
		}

		public Task<Usuario> Excluir(Usuario usuario)
		{
			_context.Usuarios.Remove(usuario);

			return Task.FromResult(usuario);
		}

		public Task<List<Usuario>> Listar()
		{
			return _context.Usuarios
				.AsNoTracking()
				.ToListAsync();
		}

		public void Salvar()
		{
			_context.SaveChanges();
		}

		public async Task<Usuario> Selecionar(int id)
		{
			try
			{
				var teste = await _context.Usuarios
					.Where(x => x.Id == id)
					.FirstOrDefaultAsync();

				return teste;
			}
			catch (Exception e)
			{

				throw;
			}
		}
	}
}
