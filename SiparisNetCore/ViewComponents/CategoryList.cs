using Microsoft.AspNetCore.Mvc;
using SiparisNetCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiparisNetCore.ViewComponents
{
    public class CategoryList : ViewComponent

    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryList(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            return View(_categoryRepository.GetirHepsi());
        }
    }
}
