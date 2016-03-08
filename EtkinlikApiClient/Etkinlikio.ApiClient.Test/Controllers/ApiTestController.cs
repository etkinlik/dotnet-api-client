using EtkinlikIO.ApiClient.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using EtkinlikIO.ApiClient;
using EtkinlikIO.ApiClient.Models.Requests;
using Etkinlikio.ApiClient.Test.Models;
using EtkinlikIO.ApiClient.Models.Reponses;

namespace Etkinlikio.ApiClient.Test.Controllers
{
    public class ApiTestController : Controller
    {
        EtkinlikIO.ApiClient.ApiClient client =
            new EtkinlikIO.ApiClient.ApiClient("TOKEN-GIRILECEK-ALAN");

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
            if (model.kategoriIds != null) config.setKategoriIds(model.kategoriIds);
            if (model.mekanIds != null) config.setMekanIds(model.mekanIds);
            if (model.sayfa != 0) config.setSayfa(model.sayfa);
            if (model.sehirIds != null) config.setSehirIds(model.sehirIds);
            if (model.turIds != null) config.setTurIds(model.turIds);

            EtkinlikListeResponse response = client.EtkinlikService.GetList(config);
            ViewBag.sayfalama = response.sayfalama;
            return View(response.kayitlar);
        }

        public ActionResult Kategori()
        {
            List<Kategori> kategoriler = client.KategoriService.GetList();
            return View(kategoriler);
        }

        public ActionResult KategoriEtkinlik(string id)
        {
            EtkinlikListeConfig config = new EtkinlikListeConfig();
            config.setKategoriIds(id);

            EtkinlikListeResponse response = client.EtkinlikService.GetList(config);
            ViewBag.sayfalama = response.sayfalama;
            return View("Etkinlik", response.kayitlar);
        }

        public ActionResult Sehir()
        {
            List<Sehir> sehirler = client.SehirService.GetList();
            return View(sehirler);
        }

        public ActionResult SehirEtkinlik(string ids)
        {
            EtkinlikListeConfig config = new EtkinlikListeConfig();
            config.setSehirIds(ids);

            EtkinlikListeResponse response = client.EtkinlikService.GetList(config);
            ViewBag.sayfalama = response.sayfalama;
            return View("Etkinlik", response.kayitlar);
        }

        public ActionResult Tur()
        {
            List<Tur> turler = client.TurService.GetList();
            return View(turler);
        }

        public ActionResult TurEtkinlik(string id)
        {
            EtkinlikListeConfig config = new EtkinlikListeConfig();
            config.setTurIds(id);

            EtkinlikListeResponse response = client.EtkinlikService.GetList(config);
            ViewBag.sayfalama = response.sayfalama;
            return View("Etkinlik", response.kayitlar);
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