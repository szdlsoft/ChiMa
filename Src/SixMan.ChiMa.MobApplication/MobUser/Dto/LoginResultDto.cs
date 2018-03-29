using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application
{
    public class LoginResultDto
    {
        public string AccessToken { get; set; }

        public string EncryptedAccessToken { get; set; }

        public int ExpireInSeconds { get; set; }

        public long UserId { get; set; }
    }
}
