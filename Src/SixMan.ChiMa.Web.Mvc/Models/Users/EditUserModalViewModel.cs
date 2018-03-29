using System.Collections.Generic;
using System.Linq;
using SixMan.ChiMa.Application.Roles.Dto;
using SixMan.ChiMa.Application.Users.Dto;

namespace SixMan.ChiMa.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
        }
    }
}