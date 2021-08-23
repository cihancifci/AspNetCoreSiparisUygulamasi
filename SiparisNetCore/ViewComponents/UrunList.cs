using Microsoft.AspNetCore.Mvc;
using SiparisNetCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiparisNetCore.ViewComponents
{
    public class UrunList : ViewComponent
    {
        private readonly IUrunRepository _urunRepository;
        public UrunList(IUrunRepository urunRepository)
        {
            _urunRepository = urunRepository;
        }
        public IViewComponentResult Invoke()
        {
            return View(_urunRepository.GetirHepsi());
        }
    }
}
