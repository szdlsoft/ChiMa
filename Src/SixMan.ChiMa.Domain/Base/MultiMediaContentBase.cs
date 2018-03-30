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
        [StringLength(LengthConstants.MaxContentLength)]
        public string Content { get; set; }
    }
}
