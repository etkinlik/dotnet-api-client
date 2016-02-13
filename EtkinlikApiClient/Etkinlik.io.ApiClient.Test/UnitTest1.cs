using System;
using Etkinlik.io.ApiClient.Models.Requests;
using Etkinlik.io.ApiClient.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Etkinlik.io.ApiClient.Test
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //    ApiClient _client = new ApiClient("f84b2a1f11d17cdce09241e850a62be4");
        //    Assert.AreEqual(21, _client.turService.GetList().Count);
        //}
        [TestMethod]
        public void TestMethod2()
        {
            ApiClient _client = new ApiClient("f84b2a1f11d17cdce09241e850a62be4");
            Assert.AreEqual(3, _client.etkinlikService.GetList(new EtkinlikListeConfig().setAdet(3)).kayitlar.Count);
        }
    }
}
