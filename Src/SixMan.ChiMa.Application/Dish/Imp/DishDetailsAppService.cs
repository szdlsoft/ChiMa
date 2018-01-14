using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace SixMan.ChiMa.Application.Dish.Imp
{
    public class DishDetailsAppService
        : IDishDetailsAppService
    {
        public CookeryDto CreateCookery(CookeryCreateDto Cookery)
        {
            throw new NotImplementedException();
        }

        public CookeryNoteDto CreateCookeryNote(CookeryNoteCreateDto CookeryNote)
        {
            throw new NotImplementedException();
        }

        public DishDetailsDto Get(IEntityDto<long> input)
        {
            throw new NotImplementedException();
        }
    }
}
