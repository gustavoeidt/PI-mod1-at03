#pragma checksum "C:\xampp\htdocs\PI-1\at03\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "335d5e57060a847bfcfb559ccdaeb3d86219cd07"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\xampp\htdocs\PI-1\at03\Views\_ViewImports.cshtml"
using at03;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\xampp\htdocs\PI-1\at03\Views\_ViewImports.cshtml"
using at03.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"335d5e57060a847bfcfb559ccdaeb3d86219cd07", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a95ad75cf612b6a14940cc053f3bdc3e7814067e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Noticia>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\xampp\htdocs\PI-1\at03\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <section class=\"col-9\">\r\n");
#nullable restore
#line 8 "C:\xampp\htdocs\PI-1\at03\Views\Home\Index.cshtml"
         foreach (Noticia item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <article>\r\n                <h2 class=\"amazon\">");
#nullable restore
#line 11 "C:\xampp\htdocs\PI-1\at03\Views\Home\Index.cshtml"
                              Write(item.titulo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                <p class=\"pb-1\"><small>");
#nullable restore
#line 12 "C:\xampp\htdocs\PI-1\at03\Views\Home\Index.cshtml"
                                  Write(item.data);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></p>\r\n                <p>");
#nullable restore
#line 13 "C:\xampp\htdocs\PI-1\at03\Views\Home\Index.cshtml"
              Write(item.texto);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </article>\r\n        <hr />\r\n");
#nullable restore
#line 16 "C:\xampp\htdocs\PI-1\at03\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        \r\n    </section>\r\n\r\n    <aside class=\"EerieBlack col-3\">\r\n        <a href=\"/Home/Anuncie\"><img class=\"w-100\" src=\"img/anuncie.jpg\" alt=\"Anuncie Aqui\"></a>\r\n    </aside>\r\n\r\n    </div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Noticia>> Html { get; private set; }
    }
}
#pragma warning restore 1591
