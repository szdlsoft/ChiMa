using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Domain
{
    public interface IInitCreate<T>
    {
        T InitCreate();
    }
}
