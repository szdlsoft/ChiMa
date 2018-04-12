using SixMan.ChiMa.Domain.Base;
using SixMan.ChiMa.Domain.Dish;
using SixMan.ChiMa.Domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SixMan.ChiMa.Domain.Food
{
    /// <summary>
    /// 食材
    /// </summary>
    public class FoodMaterial 
        : MultiMediaBase
    {
        /// <summary>
        /// 导入id
        /// 可用于菜品导入关联
        /// </summary>
        public long? ImportId { get; set; }

        public FoodMaterialCategory FoodMaterialCategory { get; set; }
        public long? FoodMaterialCategoryId { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public double? Price { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [StringLength(LengthConstants.MaxDescriptionLength)]
        public string Unit { get; set; }
        /// <summary>
        /// 主材？
        /// </summary>
        public bool IsMain { get; set; }

        /// <summary>
        /// 存储方式
        /// </summary>
        [StringLength(LengthConstants.MaxDescriptionLength)]
        public string StorageMode { get; set; }

        /// <summary>
        /// 可食率
        /// </summary>
        public int? EdiblePercent { get; set; }

        /// <summary>
        /// 英文名（拼音）
        /// </summary>
        [StringLength(50)]
        public string EnglishName { get; set; }
        /// <summary>
        /// 来源页
        /// </summary>
        [StringLength(200)]
        public string SourceUrl { get; set; }

        /// <summary>
        /// 时令
        /// </summary>
        [StringLength(50)]
        public string Season { get; set; }
        /// <summary>
        /// 健康影响
        /// </summary>
        public ICollection<FoodMaterialHealthAffect> FoodMaterialHealthAffects { get; set; }
        /// <summary>
        /// 做法，相关菜品
        /// </summary>
        public ICollection<DishBom> DishBoms { get; set; }

        /// <summary>
        /// 营养含量
        /// </summary>
        public ICollection<FoodMaterialNutrition> FoodMaterialNutritions { get; set; }


        ///// <summary>
        ///// 导入数据
        ///// </summary>
        ///// <param name="row"></param>
        //public void Import(Dictionary<string, string> row)
        //{
        //    foreach(var key in row.Keys)
        //    {
        //        var pi = this.GetType().GetProperties().Where(p => p.Name == key).FirstOrDefault();
        //        if( pi != null)
        //        {
        //            var value = GetValue(pi, row[key]);
        //            if( value != null)
        //            {
        //                pi.SetValue(this, value);
        //            }
        //        }
        //    }
        //}
        ///// <summary>
        ///// 只支持string 和double? int?类型
        ///// </summary>
        ///// <param name="pi"></param>
        ///// <param name="v"></param>
        ///// <returns></returns>
        //private object GetValue(PropertyInfo pi, string v)
        //{
        //    if(pi.PropertyType == typeof(string))
        //    {
        //        return v;
        //    }
        //    if(pi.PropertyType == typeof(double?))
        //    {
        //        return double.Parse(v);
        //    }
        //    if (pi.PropertyType == typeof(int?))
        //    {
        //        return int.Parse(v);
        //    }

        //    return null;
        //}
    }
}
