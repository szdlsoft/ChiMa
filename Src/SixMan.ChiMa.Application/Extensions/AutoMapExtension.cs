using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Application.Extensions
{
    public static class AutoMapExtension
    {
        public static TDto ToDto<TEntity, TDto>(this TEntity entity)
        {
            return Mapper.Map<TDto>(entity);
        }
    }
}
