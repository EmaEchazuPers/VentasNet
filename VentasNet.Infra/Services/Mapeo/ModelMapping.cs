using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;

namespace VentasNet.Infra.Services.Mapeo
{
    public static class ModelMapping
    {
        private static readonly IMapper mapper;
        static ModelMapping()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<VwUsuario, Usuario>(MemberList.None).ReverseMap();
                    
            });

            mapper = mapperConfig.CreateMapper();
        }

        public static Cliente ToModel(this ClienteReq model)
        {
            if(model == null) 
            {
                return null;
            }

            return mapper.Map<ClienteReq,Cliente>(model);
        }

        public static ClienteReq ToReq(this Cliente model)
        {
            if (model == null)
            {
                return null;
            }

            return mapper.Map<Cliente,ClienteReq > (model);
        }

        public static ProductoReq ToReq(this Producto model)
        {
            if (model == null)
            {
                return null;
            }

            return mapper.Map<Producto, ProductoReq>(model);
        }
        public static Producto ToModel(this ProductoReq model)
        {
            if (model == null)
            {
                return null;
            }

            return mapper.Map<ProductoReq, Producto>(model);
        }
    }
}
