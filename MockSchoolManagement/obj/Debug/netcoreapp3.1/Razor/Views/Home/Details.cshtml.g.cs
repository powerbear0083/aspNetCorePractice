#pragma checksum "D:\aspNetCore\MoscSchoolManagement\MockSchoolManagement\MockSchoolManagement\Views\Home\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2eb11e060ba3e3b1b97d10175e1f9ddf8410d845"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Details), @"mvc.1.0.view", @"/Views/Home/Details.cshtml")]
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
#line 1 "D:\aspNetCore\MoscSchoolManagement\MockSchoolManagement\MockSchoolManagement\Views\_ViewImports.cshtml"
using MockSchoolManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\aspNetCore\MoscSchoolManagement\MockSchoolManagement\MockSchoolManagement\Views\_ViewImports.cshtml"
using MockSchoolManagement.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2eb11e060ba3e3b1b97d10175e1f9ddf8410d845", @"/Views/Home/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0d1aa863c24a80b799eb669bf0f018b768b39f6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MockSchoolManagement.ViewModels.HomeDetailsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<h1>");
#nullable restore
#line 4 "D:\aspNetCore\MoscSchoolManagement\MockSchoolManagement\MockSchoolManagement\Views\Home\Details.cshtml"
Write(Model.PageTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
            WriteLiteral("<ul>\r\n    <li>\r\n        Name: ");
#nullable restore
#line 8 "D:\aspNetCore\MoscSchoolManagement\MockSchoolManagement\MockSchoolManagement\Views\Home\Details.cshtml"
         Write(Model.Student.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </li>\r\n    <li>\r\n        Mail: ");
#nullable restore
#line 11 "D:\aspNetCore\MoscSchoolManagement\MockSchoolManagement\MockSchoolManagement\Views\Home\Details.cshtml"
         Write(Model.Student.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </li>\r\n    <li>\r\n        Major: ");
#nullable restore
#line 14 "D:\aspNetCore\MoscSchoolManagement\MockSchoolManagement\MockSchoolManagement\Views\Home\Details.cshtml"
          Write(Model.Student.Major);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </li>\r\n</ul>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        console.log(\"details\")\r\n    </script>\r\n");
            }
            );
            WriteLiteral(" ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MockSchoolManagement.ViewModels.HomeDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
