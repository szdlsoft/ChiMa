using System.Collections.Generic;
using SixMan.ChiMa.Application.Roles.Dto;

namespace SixMan.ChiMa.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
