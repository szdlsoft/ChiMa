using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.DomainService
{
    public interface ICrawlerDataStore
    : Abp.Dependency.ISingletonDependency
    {
        bool Exist(ICrawlerObject obj);
        void Save(ICrawlerObject obj);
        List<T> GetByPrefix<T>(string prefix, Action<T, string> OnAfterDeserialize);
        List<T> GetAll<T>();
        // img 处理

    }
}
