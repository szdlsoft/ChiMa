using System;

namespace SixMan.ChiMa.Web.Startup
{
    public class PageNames
    {
        //首页
        public const string Home = "Home";
        //系统
        public const string System = "System";
        public const string About = "About";
        public const string Tenants = "Tenants";
        public const string Users = "Users";
        public const string Roles = "Roles";
        //菜品和食材
        public const string DishFood = "DishFood";
        public const string FoodMaterial = "FoodMateria";
        public const string FoodMaterialCategory = "FoodMateriaCategory";
        public const string Dish = "Dish";

        internal static string Category(string category)
        {
            return $"{category}Category";
        }
    }
}
