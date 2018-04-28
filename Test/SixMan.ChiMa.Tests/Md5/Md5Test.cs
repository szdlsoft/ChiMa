using SixMan.ChiMa.MonyunSms;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SixMan.ChiMa.Tests.Md5
{
    public class Md5Test
        : ChiMaTestBase
    {
        [Fact]
        public void MD5Encrypt_Test()
        {

            Assert.Equal("26dad7f364507df18f3841cc9c4ff94d", Md5Helper.MD5Encrypt("J10003000000001111110803192020", 32));

        }
    }
}
