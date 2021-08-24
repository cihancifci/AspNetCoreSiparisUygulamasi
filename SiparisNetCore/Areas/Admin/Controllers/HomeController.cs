using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiparisNetCore.Entities;
using SiparisNetCore.Interfaces;
using SiparisNetCore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SiparisNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUrunRepository _urunRepository;

        public HomeController(IUrunRepository urunRepository)
        {
            _urunRepository = urunRepository;
        }
        public IActionResult Index()
        {
            return View(_urunRepository.GetirHepsi());
        }
        public IActionResult Ekle()
        {
            return View(new UrunEkleModel());
        }

        [HttpPost]
        public IActionResult Ekle(UrunEkleModel model)
        {
            if (ModelState.IsValid)
            {
                Urun urun = new Urun();
                if (model.resim != null)
                {
                    var uzanti = Path.GetExtension(model.resim.FileName);
                    var yeniResimAd = Guid.NewGuid() + uzanti;
                    var yuklenecekYer = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/img/" +yeniResimAd);

                    var stream = new FileStream(yuklenecekYer,FileMode.Create);
                    model.resim.CopyTo(stream);

                    urun.Resim = yeniResimAd;
                }
                
                urun.Ad = model.ad;
                urun.Fiyat = model.fiyat;
                _urunRepository.Ekle(urun);

                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View();
        }
    }
}
