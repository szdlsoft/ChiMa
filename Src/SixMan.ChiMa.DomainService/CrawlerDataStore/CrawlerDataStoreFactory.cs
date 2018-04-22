using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.DomainService
{
    public class CrawlerDataStoreFactory
        : ICrawlerDataStoreFactory
    {
        public ICrawlerDataStore Create(params string[] paths)
        {
            return new CrawlerDataStoreDefault(paths);
        }
    }
}
