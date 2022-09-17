using Confitec.Domain.Domain;
using Confitec.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confitec.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
		private readonly IUsuarioService _UsuarioService;

		public UsuarioController(IUsuarioService usuarioService)
		{
			_UsuarioService = usuarioService;
		}

		[HttpPost]
		public async Task<IActionResult> Adicionar([FromBody] AdicionarUsuarioViewModel view)
		{
			try
			{
				if (!ModelState.IsValid)
					return BadRequest(ModelState);

				var result =  await _UsuarioService.Adicionar(view);
				
				return Ok(result);
			}
			catch
			{

				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpGet]
		public async Task<IActionResult> Listar()
		{
			try
			{
				var result = _UsuarioService.Listar();

				return Ok(result);
			}
			catch
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Remover(int id)
		{
			try
			{
				await _UsuarioService.Remover(id);
				
				return Ok(id);
			}
			catch
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpPut]
		public async Task<ActionResult> Atualizar(UsuarioViewModel view)
		{
			try
			{
				var result = await _UsuarioService.Atualizar(view);

				if (result == null)
					return BadRequest();

				return Ok(result);
			}
			catch
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

	}
}
