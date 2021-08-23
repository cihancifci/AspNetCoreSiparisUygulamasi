﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiparisNetCore.Entities;
using SiparisNetCore.Interfaces;
using SiparisNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiparisNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUrunRepository _urunRepository;
        public HomeController(IUrunRepository urunRepository, SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            _urunRepository = urunRepository;
        }
        public IActionResult Index()
        {
            return View(_urunRepository.GetirHepsi());
        }

        public IActionResult UrunDetay(int id)
        {
            return View(_urunRepository.IdIleGetir(id));
        }

        public IActionResult GirisYap(int id)
        {
            return View(new KullaniciGirisModel());
        }
        [HttpPost]
        public IActionResult GirisYap(KullaniciGirisModel model)
        {
            if (ModelState.IsValid)
            {
                var signInResult = _signInManager.PasswordSignInAsync(model.kullaniciAd, model.sifre, model.beniHatirla, false).Result;
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
            }
            return View(model);
        }
    }
}
