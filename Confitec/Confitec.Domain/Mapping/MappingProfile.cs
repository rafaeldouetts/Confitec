using AutoMapper;
using Confitec.Domain.Domain;
using Confitec.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Domain.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<AdicionarUsuarioViewModel, Usuario>().ReverseMap();
			CreateMap<UsuarioViewModel, Usuario>().ReverseMap();
		}
	}
}
