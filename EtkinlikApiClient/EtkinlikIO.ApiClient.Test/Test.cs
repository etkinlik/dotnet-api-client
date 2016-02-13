using NUnit.Framework;
using System;

namespace EtkinlikIO.ApiClient.Test
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void TestCase ()
		{
			ApiClient client = new ApiClient("f84b2a1f11d17cdce09241e850a62be4");
			Assert.AreEqual(3, client.EtkinlikService.GetList(new EtkinlikIO.ApiClient.Models.Requests.EtkinlikListeConfig().setAdet(3)).kayitlar.Count);
		}
	}
}

