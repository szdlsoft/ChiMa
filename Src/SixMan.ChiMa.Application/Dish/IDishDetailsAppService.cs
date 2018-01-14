using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application.Dish
{
    /// <summary>
    /// 移动版本
    /// </summary>
    public interface IDishDetailsAppService
        : IReadAppService<DishDetailsDto>
    {
        CookeryDto CreateCookery(CookeryCreateDto Cookery);
        CookeryNoteDto CreateCookeryNote(CookeryNoteCreateDto CookeryNote);

    }
}
