#pragma checksum "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Upisnice\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0b89d15b8f38c13e9d8ba901ba7b2a5de042e8eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Upisnice_Details), @"mvc.1.0.view", @"/Views/Upisnice/Details.cshtml")]
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
#line 1 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\_ViewImports.cshtml"
using HLAN;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\_ViewImports.cshtml"
using HLAN.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b89d15b8f38c13e9d8ba901ba7b2a5de042e8eb", @"/Views/Upisnice/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c20e260e0beb9ae121c57154f906b7e91c388891", @"/Views/_ViewImports.cshtml")]
    public class Views_Upisnice_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HLAN.Models.Entitie.Upisnica>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Upisnice\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Upisnica</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 15 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Upisnice\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 18 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Upisnice\Details.cshtml"
       Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 21 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Upisnice\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.User.Ime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 24 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Upisnice\Details.cshtml"
       Write(Html.DisplayFor(model => model.User.Ime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 27 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Upisnice\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.User.Prezime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 30 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Upisnice\Details.cshtml"
       Write(Html.DisplayFor(model => model.User.Prezime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 33 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Upisnice\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.User.OIB));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 36 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Upisnice\Details.cshtml"
       Write(Html.DisplayFor(model => model.User.OIB));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 39 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Upisnice\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.User.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 42 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Upisnice\Details.cshtml"
       Write(Html.DisplayFor(model => model.User.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 45 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Upisnice\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.User.Adresa));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 48 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Upisnice\Details.cshtml"
       Write(Html.DisplayFor(model => model.User.Adresa));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 51 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Upisnice\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.User.Slika));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 54 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Upisnice\Details.cshtml"
       Write(Html.DisplayFor(model => model.User.Slika));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 57 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Upisnice\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.User.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 60 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Upisnice\Details.cshtml"
       Write(Html.DisplayFor(model => model.User.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 63 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Upisnice\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.User.Klub.Naziv));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 66 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Upisnice\Details.cshtml"
       Write(Html.DisplayFor(model => model.User.Klub.Naziv));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 69 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Upisnice\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PrihvaceniUvjeti));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-9\">\r\n            ");
#nullable restore
#line 72 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Upisnice\Details.cshtml"
       Write(Html.DisplayFor(model => model.PrihvaceniUvjeti));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 77 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Upisnice\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model?.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0b89d15b8f38c13e9d8ba901ba7b2a5de042e8eb10576", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IAuthorizationService AuthorizationService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HLAN.Models.Entitie.Upisnica> Html { get; private set; }
    }
}
#pragma warning restore 1591
