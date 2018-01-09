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
        [StringLength(DescriptionBase.MaxDescriptionLength)]
        public string Unit { get; set; }
        /// <summary>
        /// 主材？
        /// </summary>
        public bool IsMain { get; set; }

        /// <summary>
        /// 可食率
        /// </summary>
        public int? EdiblePercent { get; set; }
        /// <summary>
        /// 水份
        /// </summary>
        public double? Water { get; set; }
        /// <summary>
        /// 能量_卡路里
        /// </summary>
        public double? EnergyKcal { get; set; }
        /// <summary>
        /// 能量_焦耳
        /// </summary>
        public double? EnergyKj { get; set; }        
        /// <summary>
        /// 蛋白质
        /// </summary>
        public double? Protein { get; set; }
        /// <summary>
        /// 脂肪
        /// </summary>
        public double? Fat { get; set; }
        /// <summary>
        /// 碳水化合物
        /// </summary>
        public double? CHO { get; set; }
        /// <summary>
        /// 膳食纤维
        /// </summary>
        public double? Fibrin { get; set; }
        /// <summary>
        /// 胆固醇
        /// </summary>
        public double? Cholesterol { get; set; }
        /// <summary>
        /// 灰分
        /// </summary>
        public double? ASH { get; set; }
        /// <summary>
        /// 维生素A
        /// </summary>
        public double? VitaminA { get; set; }
        /// <summary>
        /// 胡萝卜素
        /// </summary>
        public double? Carotene { get; set; }
        /// <summary>
        /// 视黄素
        /// </summary>
        public double? Retinol { get; set; }
        /// <summary>
        /// 硫胺素
        /// </summary>
        public double? Thiamin { get; set; }
        /// <summary>
        /// 维生素b2
        /// </summary>
        public double? Riboflavin { get; set; }


        /// <summary>
        /// 尼克酸
        /// </summary>
        public double? Niacin { get; set; }
        /// <summary>
        /// 维生素C
        /// </summary>
        public double? VitaminC { get; set; }
        /// <summary>
        /// 维生素E
        /// </summary>
        public double? VitaminE { get; set; }
        /// <summary>
        /// 钙
        /// </summary>
        public double? CA { get; set; }
        /// <summary>
        /// 磷
        /// </summary>
        public double? P { get; set; }
        /// <summary>
        /// 钾
        /// </summary>
        public double? K { get; set; }
        /// <summary>
        /// 纳
        /// </summary>
        public double? NA { get; set; }
        /// <summary>
        /// 镁
        /// </summary>
        public double? MG { get; set; }
        /// <summary>
        /// 铁
        /// </summary>
        public double? FE { get; set; }
        /// <summary>
        /// 锌
        /// </summary>
        public double? ZN { get; set; }
        /// <summary>
        /// 硒
        /// </summary>
        public double? SE { get; set; }
        /// <summary>
        /// 铜
        /// </summary>
        public double? CU { get; set; }
        /// <summary>
        /// 锰
        /// </summary>
        public double? MN { get; set; } 

        /// <summary>
        /// 时令
        /// </summary>
        [StringLength(50)]
        public string Season { get; set; }

        public ICollection<FoodMaterialHealthAffect> FoodMaterialHealthAffects { get; set; }
        public ICollection<DishBom> DishBoms { get; set; }


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
