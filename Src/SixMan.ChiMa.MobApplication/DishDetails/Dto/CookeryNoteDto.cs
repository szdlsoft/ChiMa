using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application.Dish
{
    [AutoMap(typeof(SixMan.ChiMa.Domain.Dish.CookeryNote))]
    public class CookeryNoteDto
        : MobileDescriptionBaseDto
    {
    }
}
