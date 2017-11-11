using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using SixMan.ChiMa.Domain.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application
{
    public abstract class ChiMaEntityBaseDto
        : FullAuditedEntityDto<long>
         , IExtendableObject
    {
        public string ExtensionData { get; set; }
    }
}
