using BookStoreApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper : TagHelper
    {
        // Dynamically create the page links

        private IUrlHelperFactory uhf;

        public PaginationTagHelper(IUrlHelperFactory temp) => uhf = temp;

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }

        public PageInfo PageModel { get; set; }

        public string PageAction { get; set; }

        public bool PageClassesEnabled { get; set; }

        public string PageClass { get; set; }

        public string PageClassNormal { get; set; }

        public string PageClassSelected { get; set; }

        public override void Process (TagHelperContext thc, TagHelperOutput tho)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            TagBuilder final = new TagBuilder("div"); // Build div

            for (int i = 1; i <= PageModel.TotalPages; i++) // Loop through number of pages
            {
                TagBuilder tb = new TagBuilder("a"); // build a tags

                tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i }); // add proper href

                // Add css if enabled
                if (PageClassesEnabled)
                {
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }

                // Append html
                tb.InnerHtml.Append(i.ToString());

                // Append to final
                final.InnerHtml.AppendHtml(tb);
            }

            // Set final content
            tho.Content.AppendHtml(final.InnerHtml);
        }
    }
}
