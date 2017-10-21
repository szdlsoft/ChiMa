using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using SixMan.ChiMa.Domain.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Domain.Base
{
    public abstract class ChiMaEntityBase
        : FullAuditedEntity<long>
         , IExtendableObject
    {
        public string ExtensionData { get; set; }
    }
}
