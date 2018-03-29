using SixMan.ChiMa.Domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SixMan.ChiMa.Domain.Base
{
    public class MultiMediaContentBase
        : MultiMediaBase
        , IContent
    {
        public const int MaxContentLength = 4096;
        [StringLength(MaxUrlLength)]
        public string Content { get; set; }
    }
}
