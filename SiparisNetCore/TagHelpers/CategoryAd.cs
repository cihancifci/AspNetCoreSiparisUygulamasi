using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SiparisNetCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisNetCore.TagHelpers
{
    [HtmlTargetElement("getirCategoryAd")]
    public class CategoryAd : TagHelper
    {
        private readonly IUrunRepository _urunRepository;
        public CategoryAd(IUrunRepository urunRepository)
        {
            _urunRepository = urunRepository;
        }
        public int urunId { get; set; } 
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //TagBuilder builder = new TagBuilder("ul");
            //StringBuilder builder2 = new StringBuilder();
            //builder2.Append()

            string data = "";
            var gelenCategory = _urunRepository.GetirCategory(urunId).Select(I => I.Ad);

            foreach (var item in gelenCategory)
            {
                data += item + " ";
            }

            output.Content.SetContent(data);
        }
    }
}
