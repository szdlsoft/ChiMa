using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using SixMan.ChiMa.Domain.Authorization.Users;
using SixMan.ChiMa.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SixMan.ChiMa.Domain.Base
{
    public abstract class ChiMaEntityBase
        : FullAuditedEntity<long>
         , IExtendableObject
         , IImport
    {
        public string ExtensionData { get; set; }

        public void Import(Dictionary<string, string> row)
        {
            foreach (var key in row.Keys)
            {
                var pi = this.GetType().GetProperties().Where(p => p.Name == key).FirstOrDefault();
                if (pi != null)
                {
                    var value = GetValue(pi, row[key]);
                    if (value != null)
                    {
                        pi.SetValue(this, value);
                    }
                }
            }
        }

        /// <summary>
        /// 只支持string 和double? int? long?类型
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        private object GetValue(PropertyInfo pi, string v)
        {
            if (pi.PropertyType == typeof(string))
            {
                return v;
            }
            if (pi.PropertyType == typeof(double?))
            {
                return double.Parse(v);
            }
            if (pi.PropertyType == typeof(int?))
            {
                return int.Parse(v);
            }
            if (pi.PropertyType == typeof(long?))
            {
                return long.Parse(v);
            }

            return null;
        }
    }

    /// <summary>
    /// 少量固定数据的基类
    /// </summary>
    public abstract class ChiMaSmallEntityBase
        : Entity
    {
    }

    /// <summary>
    /// 海量量固定数据的基类
    /// </summary>
    public abstract class ChiMaLargeEntityBase
        : Entity<long>
    {
    }
}
