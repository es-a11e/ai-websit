#pragma checksum "D:\Route Back-End\zz\Project Graduation\project V 17\project V 17\PL\Views\Personal\ReportedChildren.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0df6913c9904c38d5f699b2c0a730f304fd64d51e3ba3806c08118752c053714"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Personal_ReportedChildren), @"mvc.1.0.view", @"/Views/Personal/ReportedChildren.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Route Back-End\zz\Project Graduation\project V 17\project V 17\PL\Views\_ViewImports.cshtml"
using PL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Route Back-End\zz\Project Graduation\project V 17\project V 17\PL\Views\_ViewImports.cshtml"
using PL.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Route Back-End\zz\Project Graduation\project V 17\project V 17\PL\Views\_ViewImports.cshtml"
using DAL.Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"0df6913c9904c38d5f699b2c0a730f304fd64d51e3ba3806c08118752c053714", @"/Views/Personal/ReportedChildren.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"0a6e6afb651c388271110a3fd4bf8c20eccf798310a6a55ef50f5d365b860c2e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Personal_ReportedChildren : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IQueryable<PersonsViewModel>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("rounded w-75 h-auto  "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Chield"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Personal", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditReportedChildren", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Route Back-End\zz\Project Graduation\project V 17\project V 17\PL\Views\Personal\ReportedChildren.cshtml"
  
    ViewData["Title"] = "Reported Children";

#line default
#line hidden
#nullable disable
            WriteLiteral("<section class=\"container\">\r\n\r\n    <h1 class=\"my-3\">Reported Children</h1>\r\n");
#nullable restore
#line 8 "D:\Route Back-End\zz\Project Graduation\project V 17\project V 17\PL\Views\Personal\ReportedChildren.cshtml"
     if (Model.Count() > 0)
    {
        

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <table>
            <thead class=""table table-striped table-hover bg-light mt-4"">
                <tr>
                    <td class=""table table-striped table-hover bg-light mt-4"">Image</td>
                    <td class=""table table-striped table-hover bg-light mt-4"">NationalPerson_Id</td>
                    <td class=""table table-striped table-hover bg-light mt-4"">Name</td>
                    <td class=""table table-striped table-hover bg-light mt-4"">Father</td>
                    <td class=""table table-striped table-hover bg-light mt-4"">Mother</td>
                    <td class=""table table-striped table-hover bg-light mt-4"">HomePhoneNumber</td>
                    <td class=""table table-striped table-hover bg-light mt-4"">Gender</td>
                    <td class=""table table-striped table-hover bg-light mt-4"">Address</td>
                    <td class=""table table-striped table-hover bg-light mt-4"">DateOfBirth</td>
                    <td class=""table table-striped table-hover bg-li");
            WriteLiteral("ght mt-4\"> Missing</td>\r\n\r\n\r\n\r\n\r\n");
            WriteLiteral("                    <td class=\"table table-striped table-hover bg-light mt-4\">Edit</td>\r\n");
            WriteLiteral("                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 34 "D:\Route Back-End\zz\Project Graduation\project V 17\project V 17\PL\Views\Personal\ReportedChildren.cshtml"
                 foreach (var entity in Model)
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            <div class=\"text-center\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0df6913c9904c38d5f699b2c0a730f304fd64d51e3ba3806c08118752c0537147779", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1841, "~/Files/Chiledrens_Images/", 1841, 26, true);
#nullable restore
#line 40 "D:\Route Back-End\zz\Project Graduation\project V 17\project V 17\PL\Views\Personal\ReportedChildren.cshtml"
AddHtmlAttributeValue("", 1867, entity.ImageName, 1867, 17, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </td>\r\n                        <td class=\"text-center\"> ");
#nullable restore
#line 43 "D:\Route Back-End\zz\Project Graduation\project V 17\project V 17\PL\Views\Personal\ReportedChildren.cshtml"
                                            Write(entity.NationalPerson_Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-center\"> ");
#nullable restore
#line 44 "D:\Route Back-End\zz\Project Graduation\project V 17\project V 17\PL\Views\Personal\ReportedChildren.cshtml"
                                            Write(entity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-center\"> ");
#nullable restore
#line 45 "D:\Route Back-End\zz\Project Graduation\project V 17\project V 17\PL\Views\Personal\ReportedChildren.cshtml"
                                            Write(entity.Father.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-center\"> ");
#nullable restore
#line 46 "D:\Route Back-End\zz\Project Graduation\project V 17\project V 17\PL\Views\Personal\ReportedChildren.cshtml"
                                            Write(entity.Mother.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-center\"> ");
#nullable restore
#line 47 "D:\Route Back-End\zz\Project Graduation\project V 17\project V 17\PL\Views\Personal\ReportedChildren.cshtml"
                                            Write(entity.HomePhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n               \r\n                        <td class=\"text-center\">\r\n");
#nullable restore
#line 50 "D:\Route Back-End\zz\Project Graduation\project V 17\project V 17\PL\Views\Personal\ReportedChildren.cshtml"
                             if (entity.Gender == true)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <p> Is a Male<i class=\"fa-solid fa-child-reaching\"></i></p>\r\n");
#nullable restore
#line 53 "D:\Route Back-End\zz\Project Graduation\project V 17\project V 17\PL\Views\Personal\ReportedChildren.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <p> Is Female<i class=\"fa-solid fa-child-dress\"></i></p>\r\n");
#nullable restore
#line 57 "D:\Route Back-End\zz\Project Graduation\project V 17\project V 17\PL\Views\Personal\ReportedChildren.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td class=\"text-center\"> ");
#nullable restore
#line 61 "D:\Route Back-End\zz\Project Graduation\project V 17\project V 17\PL\Views\Personal\ReportedChildren.cshtml"
                                            Write(entity.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-center\"> ");
#nullable restore
#line 62 "D:\Route Back-End\zz\Project Graduation\project V 17\project V 17\PL\Views\Personal\ReportedChildren.cshtml"
                                            Write(entity.DateOfBirth);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-center\">\r\n");
#nullable restore
#line 64 "D:\Route Back-End\zz\Project Graduation\project V 17\project V 17\PL\Views\Personal\ReportedChildren.cshtml"
                             if (entity.Is_he_missing == true)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <p> Yes </p>\r\n");
#nullable restore
#line 67 "D:\Route Back-End\zz\Project Graduation\project V 17\project V 17\PL\Views\Personal\ReportedChildren.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <p> No </p>\r\n");
#nullable restore
#line 71 "D:\Route Back-End\zz\Project Graduation\project V 17\project V 17\PL\Views\Personal\ReportedChildren.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                        </td>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n                        <td class=\"table table-striped table-hover bg-light mt-4\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0df6913c9904c38d5f699b2c0a730f304fd64d51e3ba3806c08118752c05371414438", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 86 "D:\Route Back-End\zz\Project Graduation\project V 17\project V 17\PL\Views\Personal\ReportedChildren.cshtml"
                                                                                                                             WriteLiteral(entity.NationalPerson_Id);

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
            WriteLiteral("\r\n                        </td>\r\n\r\n                    </tr>\r\n");
#nullable restore
#line 90 "D:\Route Back-End\zz\Project Graduation\project V 17\project V 17\PL\Views\Personal\ReportedChildren.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n");
#nullable restore
#line 93 "D:\Route Back-End\zz\Project Graduation\project V 17\project V 17\PL\Views\Personal\ReportedChildren.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h1 class=\"alert alert-danger\">No Reported Children</h1>\r\n");
#nullable restore
#line 97 "D:\Route Back-End\zz\Project Graduation\project V 17\project V 17\PL\Views\Personal\ReportedChildren.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n</section>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IQueryable<PersonsViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
