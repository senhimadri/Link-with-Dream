#pragma checksum "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ManageGroupPeople\YoursentRequestGroup.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "db21a6d0490f3736a66131f553e2146acb84af51"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ManageGroupPeople_YoursentRequestGroup), @"mvc.1.0.view", @"/Views/ManageGroupPeople/YoursentRequestGroup.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db21a6d0490f3736a66131f553e2146acb84af51", @"/Views/ManageGroupPeople/YoursentRequestGroup.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2522447089cc2748aa8e4a09ddffdbdcd75f113", @"/Views/_ViewImports.cshtml")]
    public class Views_ManageGroupPeople_YoursentRequestGroup : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Link_with_Dream.Models.GroupPeople>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "GroupManagement", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GroupAbout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-info btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("float:right;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ManageGroupPeople\YoursentRequestGroup.cshtml"
  
    ViewData["Title"] = "YoursentRequestGroup";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h3>List of the groups that you sent request to be a member</h3>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n\r\n            <th>\r\n                ");
#nullable restore
#line 14 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ManageGroupPeople\YoursentRequestGroup.cshtml"
           Write(Html.DisplayNameFor(model => model.Group.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ManageGroupPeople\YoursentRequestGroup.cshtml"
           Write(Html.DisplayNameFor(model => model.Group.MenbersType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                Action\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 26 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ManageGroupPeople\YoursentRequestGroup.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 30 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ManageGroupPeople\YoursentRequestGroup.cshtml"
               Write(Html.DisplayFor(modelItem => item.Group.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 33 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ManageGroupPeople\YoursentRequestGroup.cshtml"
               Write(Html.DisplayFor(modelItem => item.Group.MenbersType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <div class=\"row\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "db21a6d0490f3736a66131f553e2146acb84af517245", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 37 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ManageGroupPeople\YoursentRequestGroup.cshtml"
                                                                                      WriteLiteral(item.Group.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 41 "E:\My Projects\16-05-2020-ASP.NET Core 3.1_Link with Dream\Link_with_Dream\Link_with_Dream\Views\ManageGroupPeople\YoursentRequestGroup.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Link_with_Dream.Models.GroupPeople>> Html { get; private set; }
    }
}
#pragma warning restore 1591