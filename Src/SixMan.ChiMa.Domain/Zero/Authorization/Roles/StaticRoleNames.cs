namespace SixMan.ChiMa.Domain.Authorization.Roles
{
    public static class StaticRoleNames
    {
        public static class Host
        {
            public const string Admin = "Admin";
            /// <summary>
            /// 系统用户，用户客户端验证
            /// </summary>
            public const string System = "System";
        }

        public static class Tenants
        {
            public const string Admin = "Admin";
        }
    }
}
