using AutoMapper;
using Confitec.Domain.Domain;
using Confitec.Domain.Services.Interfaces;
using Confitec.Entity.Entity;
using Confitec.Entity.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Domain.Services
{
	public class UsuarioService : IUsuarioService
	{
		private readonly IUsuarioRepository _usuarioRepository;
		private readonly IMapper _mapper;

		public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
		{
			_usuarioRepository = usuarioRepository;
			_mapper = mapper;
		}

		public async Task<UsuarioViewModel> Adicionar(AdicionarUsuarioViewModel view)
		{
			var entity = _mapper.Map<Usuario>(view);

			await _usuarioRepository.Adicionar(entity);
			
			_usuarioRepository.Salvar();

			return _mapper.Map<UsuarioViewModel>(entity);
		}

		public async Task<UsuarioViewModel> Atualizar(UsuarioViewModel view)
		{
			try
			{
				var usuario = await _usuarioRepository.Selecionar(view.Id);

				if (usuario == null) return null;

				usuario.Nome = view.Nome;
				usuario.Sobrenome = view.Sobrenome;
				usuario.Email = view.Email;
				usuario.Escolaridade = view.Escolaridade;
				usuario.DataNascimento = view.DataNascimento;

				await _usuarioRepository.Alterar(usuario);
			
				_usuarioRepository.Salvar();

				return _mapper.Map<UsuarioViewModel>(usuario);
			}
			catch (Exception e)
			{
				throw;
			}
		}

		public List<UsuarioViewModel> Listar()
		{
			var entity = _usuarioRepository.Listar();

			return _mapper.Map<List<UsuarioViewModel>>(entity.Result);
		}

		public async Task Remover(int id)
		{
			var usuario = await _usuarioRepository.Selecionar(id);

			await _usuarioRepository.Excluir(usuario);
			
			_usuarioRepository.Salvar();
		}
	}
}
