#pragma checksum "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f63332862448e2aaf18dfabbd54dd5e6c7722e4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ContentPosts_Index), @"mvc.1.0.view", @"/Views/ContentPosts/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f63332862448e2aaf18dfabbd54dd5e6c7722e4", @"/Views/ContentPosts/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2522447089cc2748aa8e4a09ddffdbdcd75f113", @"/Views/_ViewImports.cshtml")]
    public class Views_ContentPosts_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Link_with_Dream.Models.ContentPost>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f63332862448e2aaf18dfabbd54dd5e6c7722e44774", async() => {
                WriteLiteral("Create New");
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
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Heading));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Image));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.PostTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.User));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Company));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Group));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 37 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.CGPoster));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 40 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.PostType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 43 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DeadLine));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 46 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.JobType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 49 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Area));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 52 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.XMStartTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 55 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.XMEndTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 61 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 64 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Heading));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 67 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 70 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Image));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 73 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.PostTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 76 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.User.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 79 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Company.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 82 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Group.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 85 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.CGPoster.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 88 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.PostType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 91 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.DeadLine));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 94 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.JobType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 97 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Area));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 100 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.XMStartTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 103 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.XMEndTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f63332862448e2aaf18dfabbd54dd5e6c7722e416479", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 106 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
                                       WriteLiteral(item.Id);

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
            WriteLiteral(" |\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f63332862448e2aaf18dfabbd54dd5e6c7722e418689", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 107 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
                                          WriteLiteral(item.Id);

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
            WriteLiteral(" |\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f63332862448e2aaf18dfabbd54dd5e6c7722e420905", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 108 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
                                         WriteLiteral(item.Id);

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
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 111 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ContentPosts\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Link_with_Dream.Models.ContentPost>> Html { get; private set; }
    }
}
#pragma warning restore 1591
