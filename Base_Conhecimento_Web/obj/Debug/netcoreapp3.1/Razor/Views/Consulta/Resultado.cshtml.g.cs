#pragma checksum "C:\Users\gus_f\Desktop\Base\Base_Conhecimento_New\Base_Conhecimento_Web\Views\Consulta\Resultado.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d2fa2a85b1e2be757746a7deaf9b2c77667a8cc0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Consulta_Resultado), @"mvc.1.0.view", @"/Views/Consulta/Resultado.cshtml")]
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
#line 1 "C:\Users\gus_f\Desktop\Base\Base_Conhecimento_New\Base_Conhecimento_Web\Views\_ViewImports.cshtml"
using Base_Conhecimento;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\gus_f\Desktop\Base\Base_Conhecimento_New\Base_Conhecimento_Web\Views\_ViewImports.cshtml"
using Base_Conhecimento.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2fa2a85b1e2be757746a7deaf9b2c77667a8cc0", @"/Views/Consulta/Resultado.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47dc62e9458ca1dc792351c6f4fd775123ebb3ea", @"/Views/_ViewImports.cshtml")]
    public class Views_Consulta_Resultado : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Base_Conhecimento.Solucao>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", new global::Microsoft.AspNetCore.Html.HtmlString("Voltar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\gus_f\Desktop\Base\Base_Conhecimento_New\Base_Conhecimento_Web\Views\Consulta\Resultado.cshtml"
  
    ViewData["Title"] = "Soluões Encontradas";


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3>Soluções Encontradas</h3>\r\n\r\n\r\n");
#nullable restore
#line 11 "C:\Users\gus_f\Desktop\Base\Base_Conhecimento_New\Base_Conhecimento_Web\Views\Consulta\Resultado.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <ul>\r\n        <li>\r\n            Solução ");
#nullable restore
#line 15 "C:\Users\gus_f\Desktop\Base\Base_Conhecimento_New\Base_Conhecimento_Web\Views\Consulta\Resultado.cshtml"
               Write(Html.DisplayFor(modelItem => item.solucaoID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 16 "C:\Users\gus_f\Desktop\Base\Base_Conhecimento_New\Base_Conhecimento_Web\Views\Consulta\Resultado.cshtml"
       Write(Html.Raw(item.descricao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 17 "C:\Users\gus_f\Desktop\Base\Base_Conhecimento_New\Base_Conhecimento_Web\Views\Consulta\Resultado.cshtml"
       Write(Html.ActionLink("Ver solução completa", "Solucao", new { sol = item.solucaoID }, new { @class = "label label-warning" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <hr />\r\n        </li>\r\n    </ul>\r\n");
#nullable restore
#line 21 "C:\Users\gus_f\Desktop\Base\Base_Conhecimento_New\Base_Conhecimento_Web\Views\Consulta\Resultado.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"form-group\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d2fa2a85b1e2be757746a7deaf9b2c77667a8cc06068", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Base_Conhecimento.Solucao>> Html { get; private set; }
    }
}
#pragma warning restore 1591
