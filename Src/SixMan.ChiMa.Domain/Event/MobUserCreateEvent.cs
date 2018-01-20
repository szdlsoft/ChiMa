using Abp.Events.Bus;
using SixMan.ChiMa.Domain.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Domain
{
    public class MobUserCreateEvent 
        : EventData
    {
        public User User { get; set; }
        public long? FamilyId { get; set; }
    }
}
