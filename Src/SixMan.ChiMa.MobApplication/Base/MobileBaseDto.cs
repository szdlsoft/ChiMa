using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application
{
    public class MobileBaseDto
        : EntityDto<long>
    {
    }

    public class MobileDescriptionBaseDto
        : MobileBaseDto
    {
        public const int MaxDescriptionLength = 256;
        public const int MinDescriptionLength = 2;
        public string Description { get; set; }
    }

    public class MobileMultiMediaBaseDto
       : MobileDescriptionBaseDto
    {
        public string Photo { get; set; }
        public string Audio { get; set; }
        public string Video { get; set; }
    }
}
