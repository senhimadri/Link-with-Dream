#pragma checksum "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\AcademicQualification\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "21b695752898d8cab2089f9c06e5ff60676a4b1f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AcademicQualification_Details), @"mvc.1.0.view", @"/Views/AcademicQualification/Details.cshtml")]
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
#line 1 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\_ViewImports.cshtml"
using Link_with_Dream;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\_ViewImports.cshtml"
using Link_with_Dream.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21b695752898d8cab2089f9c06e5ff60676a4b1f", @"/Views/AcademicQualification/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2522447089cc2748aa8e4a09ddffdbdcd75f113", @"/Views/_ViewImports.cshtml")]
    public class Views_AcademicQualification_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Link_with_Dream.Models.AcademicQualification>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "UserProfile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AcademicQualification", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\AcademicQualification\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"col-md-8 offset-md-2\">\r\n        <div>\r\n            <h4>Academic Qualification</h4>\r\n            <hr />\r\n            <dl class=\"row\">\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 13 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\AcademicQualification\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.ExamName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 16 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\AcademicQualification\Details.cshtml"
               Write(Html.DisplayFor(model => model.ExamName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 19 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\AcademicQualification\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Subject));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 22 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\AcademicQualification\Details.cshtml"
               Write(Html.DisplayFor(model => model.Subject));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 25 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\AcademicQualification\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Institute));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 28 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\AcademicQualification\Details.cshtml"
               Write(Html.DisplayFor(model => model.Institute));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 31 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\AcademicQualification\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Board));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 34 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\AcademicQualification\Details.cshtml"
               Write(Html.DisplayFor(model => model.Board));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 37 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\AcademicQualification\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.PassingYear));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 40 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\AcademicQualification\Details.cshtml"
               Write(Html.DisplayFor(model => model.PassingYear));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 43 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\AcademicQualification\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Result));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 46 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\AcademicQualification\Details.cshtml"
               Write(Html.DisplayFor(model => model.Result));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 49 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\AcademicQualification\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.IsPublic));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 52 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\AcademicQualification\Details.cshtml"
               Write(Html.DisplayFor(model => model.IsPublic));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n            </dl>\r\n        </div>\r\n        <div>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "21b695752898d8cab2089f9c06e5ff60676a4b1f10433", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 57 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\AcademicQualification\Details.cshtml"
                                   WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "21b695752898d8cab2089f9c06e5ff60676a4b1f12646", async() => {
                WriteLiteral("Back to Profile");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n\r\n    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Link_with_Dream.Models.AcademicQualification> Html { get; private set; }
    }
}
#pragma warning restore 1591
