using EtkinlikIO.ApiClient.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using EtkinlikIO.ApiClient;
using EtkinlikIO.ApiClient.Models.Reponses;
using EtkinlikIO.ApiClient.Models.Requests;
using Etkinlikio.ApiClient.Test.Models;

namespace Etkinlikio.ApiClient.Test.Controllers
{
    public class ApiTestController : Controller
    {
        EtkinlikIO.ApiClient.ApiClient client = 
            new EtkinlikIO.ApiClient.ApiClient("7fb992c135adff01cdc6c33f9903d064");

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Etkinlik()
        {
            EtkinlikListeResponse response = client.EtkinlikService.GetList();
            ViewBag.sayfalama = response.sayfalama;
            return View(response.kayitlar);
        }

        [HttpPost]
        public ActionResult Etkinlik(EtkinlikFilter model)
        {
            EtkinlikListeConfig config = new EtkinlikListeConfig();

            if (model.adet != 0) config.setAdet(model.adet);
            if (model.kategoriId != 0) config.setKategoriId(model.kategoriId);
            if (model.mekanId != 0) config.setMekanId(model.mekanId);
            if (model.sayfa != 0) config.setSayfa(model.sayfa);
            if (model.sehirId != 0) config.setSehirId(model.sehirId);
            if (model.turId != 0) config.setTurId(model.turId);

            EtkinlikListeResponse response = client.EtkinlikService.GetList(config);
            ViewBag.sayfalama = response.sayfalama;
            return View(response.kayitlar);
        }

        public ActionResult Kategori()
        {
            List<Kategori> kategoriler = client.KategoriService.GetList();
            return View(kategoriler);
        }

        public ActionResult KategoriEtkinlik(int id)
        {
            EtkinlikListeConfig config = new EtkinlikListeConfig();
            config.setKategoriId(id);

            EtkinlikListeResponse response = client.EtkinlikService.GetList(config);
            ViewBag.sayfalama = response.sayfalama;
            return View("Etkinlik", response.kayitlar);
        }

        public ActionResult Sehir()
        {
            List<Sehir> sehirler = client.SehirService.GetList();
            return View(sehirler);
        }

        public ActionResult SehirEtkinlik(int id)
        {
            EtkinlikListeConfig config = new EtkinlikListeConfig();
            config.setSehirId(id);

            EtkinlikListeResponse response = client.EtkinlikService.GetList(config);
            ViewBag.sayfalama = response.sayfalama;
            return View("Etkinlik", response.kayitlar);
        }

        public ActionResult Tur()
        {
            List<Tur> turler = client.TurService.GetList();
            return View(turler);
        }

        public ActionResult TurEtkinlik(int id)
        {
            EtkinlikListeConfig config = new EtkinlikListeConfig();
            config.setTurId(id);

            EtkinlikListeResponse response = client.EtkinlikService.GetList(config);
            ViewBag.sayfalama = response.sayfalama;
            return View("Etkinlik",response.kayitlar);
        }

        public ActionResult Ilce(int id)
        {
            List<Ilce> ilceler = client.IlceService.GetListBySehirId(id);
            return View(ilceler);
        }

        public ActionResult Semt(int id)
        {
            List<Semt> semtler = client.SemtService.GetListByIlceId(id);
            return View(semtler);
        }


	}
}