using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.MonyunSms.isms {
    public  interface ISMS
        : Abp.Dependency.ISingletonDependency
    {
         string execute(Message message, int sendType, string IpAndPort, int authenticationMode, bool bKeepAlive);
    }
}
