#pragma checksum "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Igraci\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e8085b833ffb2e06e6161eaef27c0e4128679d2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Igraci_Index), @"mvc.1.0.view", @"/Views/Igraci/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e8085b833ffb2e06e6161eaef27c0e4128679d2", @"/Views/Igraci/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c20e260e0beb9ae121c57154f906b7e91c388891", @"/Views/_ViewImports.cshtml")]
    public class Views_Igraci_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IGrouping<string, HLAN.Models.Igrac>>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "SearchString", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Igraci\Index.cshtml"
  
    ViewData["Title"] = "Igraci";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var klubovi = context.Klubovi.ToList();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Igra??i</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e8085b833ffb2e06e6161eaef27c0e4128679d25584", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e8085b833ffb2e06e6161eaef27c0e4128679d26834", async() => {
                WriteLiteral("\r\n    <div class=\"form-actions no-color\">\r\n        <p>\r\n            Preta??i po klubu: ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e8085b833ffb2e06e6161eaef27c0e4128679d27182", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "value", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 18 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Igraci\Index.cshtml"
AddHtmlAttributeValue("", 496, ViewData["CurrentFilter"], 496, 26, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
#nullable restore
#line 18 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Igraci\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = (new SelectList(klubovi,"Naziv","Naziv"));

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            <input type=\"submit\" value=\"Search\" class=\"btn btn-default\" /> |\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e8085b833ffb2e06e6161eaef27c0e4128679d29413", async() => {
                    WriteLiteral("Back to Full List");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        </p>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 25 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Igraci\Index.cshtml"
 foreach (var elem in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n");
#nullable restore
#line 28 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Igraci\Index.cshtml"
     foreach (var item in elem)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-5\">\r\n            <div class=\"card\" style=\"width: 18rem;\">\r\n                <img class=\"card-img-top\" src=\"...\" alt=\"Card image cap\">\r\n                <div class=\"card-body\">\r\n                    <h5 class=\"card-title\">");
#nullable restore
#line 34 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Igraci\Index.cshtml"
                                      Write(item.Ime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <h5 class=\"card-title\">");
#nullable restore
#line 35 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Igraci\Index.cshtml"
                                      Write(item.Prezime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <h5 class=\"card-title\">");
#nullable restore
#line 36 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Igraci\Index.cshtml"
                                      Write(item.Klub);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <h5 class=\"card-title\">");
#nullable restore
#line 37 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Igraci\Index.cshtml"
                                      Write(item.Pozicija);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    ");
#nullable restore
#line 38 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Igraci\Index.cshtml"
               Write(Html.ActionLink("Edit", "Edit", new { id = item.Id }, new { @class = "btn btn-secondary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n                    ");
#nullable restore
#line 39 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Igraci\Index.cshtml"
               Write(Html.ActionLink("Details", "", new { }, new { @class = "btn btn-primary", @data_toggle = "collapse", href = "#collapseExample", role = "button", @aria_expanded = "false", @aria_controls = "collapseExample", onclick = "appendDetails('" + item.Id + "');" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 40 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Igraci\Index.cshtml"
               Write(Html.ActionLink("Delete", "Delete", new { id = item.Id }, new { @class = "btn btn-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"collapse\" id=\"collapseExample\">\r\n                    <div class=\"card card-body\">\r\n                        <div");
            BeginWriteAttribute("class", " class=", 1976, "", 2013, 1);
#nullable restore
#line 44 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Igraci\Index.cshtml"
WriteAttributeValue("", 1983, "player-details-" + item.Id, 1983, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 51 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Igraci\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 53 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Igraci\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<script>\r\n    function appendDetails(id) {\r\n        var link = \'");
#nullable restore
#line 59 "C:\Users\Ante\Projekti\web\HLAN\zavrsni\HLAN\Views\Igraci\Index.cshtml"
               Write(Url.Action("Details", "Igraci", new { id = -1  }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
        link = link.replace(""-1"", id);

        $.ajax({
            url: link,
            type: ""POST"",
            dataType: ""JSON"",
            success: function (result) {
                var item = JSON.parse(result.details);
                var el = `
                    <div class=""d-flex flex-row"">
                        <div  class=""flex-column"">
                            <div class="""">
                                Ime:
                            </div>
                            <div class=""pr-2"">
                                ${item.Ime}
                            </div>
                            <div class="""">
                                Prezime:
                            </div>
                            <div class=""pr-2"">
                                ${item.Prezime}
                            </div>
                            <div class="""">
                                OIB:
                            </div>
                            <");
            WriteLiteral(@"div class=""pr-2"">
                                ${item.OIB}
                            </div>
                            <div class="""">
                                Telefon:
                            </div>
                            <div class=""pr-2"">
                                ${item.PhoneNumber}
                            </div>
                            <div class="""">
                                Email:
                            </div>
                            <div class=""pr-2"">
                                ${item.Email}
                            </div>
                        </div>
                        <div  class=""flex-column"" >
                            <div class="""">
                                Platio ??alanrinu:
                            </div>
                            <div class=""pr-2"">
                                ${item.Platio_clanarinu}
                            </div>
                            <div class="""">
            ");
            WriteLiteral(@"                    Broj:
                            </div>
                            <div class=""pr-2"">
                                ${item.Broj}
                            </div>
                            <div class="""">
                                Pozicija:
                            </div>
                            <div class=""pr-2"">
                                ${item.Pozicija}
                            </div>
                            <div class="""">
                                Klub:
                            </div>
                            <div class=""pr-2"">
                                ${item.Klub.Naziv}
                            </div>
                        </div>
                    </div>`;
                var selector = "".player-details-"" + item.Id;
                $(selector).empty();
                $(selector).append(el);   // Append new elements
            }
        });
    }
</script>
");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public HLAN.Models.EF.HLANContext context { get; private set; }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IGrouping<string, HLAN.Models.Igrac>>> Html { get; private set; }
    }
}
#pragma warning restore 1591
