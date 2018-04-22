using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.DomainService
{
    public interface ICrawlerDataStoreFactory
        : Abp.Dependency.ISingletonDependency
    {
        /// <summary>
        /// 可以在子目录中
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        ICrawlerDataStore Create(params string[] paths);
    }
}
