#pragma checksum "C:\projects\manoj\smb_om\smb_om\Views\Admin\ViewLog.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "845826a07f9c73d61498e0a03ca66e78ee7041f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ViewLog), @"mvc.1.0.view", @"/Views/Admin/ViewLog.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"845826a07f9c73d61498e0a03ca66e78ee7041f1", @"/Views/Admin/ViewLog.cshtml")]
    public class Views_Admin_ViewLog : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<smb_om.Model.ViewLog>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("searchForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("searchForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return validate(this)"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "845826a07f9c73d61498e0a03ca66e78ee7041f14530", async() => {
                WriteLiteral("\r\n    <div id=\"content-body\">\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "845826a07f9c73d61498e0a03ca66e78ee7041f14829", async() => {
                    WriteLiteral(@"
            <input name=""token"" type=""hidden"" value=""7c96a9dc-f4a1-4313-94c6-c3bb2a9cb860""><table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
                <tbody>
                    <tr>
                        <td class=""stroke"" height=""1"" width=""1""></td>
                        <td align=""center"">
                            <div class=""application"">
                                <h1>Show Log</h1>
                                <p class=""error""></p>
                                <div class=""content-border"">
                                    <div class=""cmxform_short"">
                                        <fieldset>
                                            <h2>Search Criteria</h2>
                                            <hr class=""break"">
                                            <div class=""contentBlock"">
                                                <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""appTable"">
                                    ");
                    WriteLiteral(@"                <colgroup>
                                                        <col style=""width: 15%;"">
                                                        <col style=""width: 85%;"">
                                                    </colgroup>
                                                    <tbody>
                                                        <tr>
                                                            <td><label class=""label"" style=""color:black"">Order Number:</label></td>
                                                            <td><input class=""textbox"" id=""ordernumber"" maxlength=""254"" name=""ordernumber"" size=""40"" type=""text""></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan=""2""><input class=""button-css"" name=""searchsubmit"" type=""button"" onclick=""GetViewLog()"" value=""Submit""></td>
                                   ");
                    WriteLiteral(@"                     </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </fieldset>
                                    </div>
                                    <div class=""cmxform_results"">
                                        <fieldset>
                                            <h2>
                                              
                                                   
                                                <span>
                                                    Log Entries :
                                                    ORDER -
                                                    <span id=""spanordernumber""></span>
                                                </span>
                                                      

                                            </h2>
                   ");
                    WriteLiteral(@"                         <hr class=""break"">
                                            <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""appFixedTable"" id=""tblEmployee"">
                                                <colgroup>
                                                    <col style=""width: 20%;"">
                                                    <col style=""width: 20%;"">
                                                    <col style=""width: 60%;"">
                                                </colgroup>
                                                <tbody>
                                                    <tr class=""resultsHeader"">
                                                        <td>Category</td>
                                                        <td>TimeStamp</td>
                                                        <td>Message</td>
                                                    </tr>
");
                    WriteLiteral(@"                                                  
                                                </tbody>
                                            </table>
                                        </fieldset>

                                    </div>
                                </div>
                            </div>
                        </td>
                        <td class=""stroke"" height=""1"" width=""1""></td>
                    </tr>
                    <tr>
                        <td class=""stroke"" colspan=""3"" height=""1""></td>
                    </tr>
                </tbody>
            </table>
        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    </div>

    <script type=""text/javascript"">
        function GetViewLog() {

            var txt = $('#ordernumber').val();
            if (txt == '') {
                alert('Please enter ordernumber');
                return;
            }

           //     txt = ordernumber;
            $.getJSON('");
#nullable restore
#line 114 "C:\projects\manoj\smb_om\smb_om\Views\Admin\ViewLog.cshtml"
                  Write(Url.Content("~/"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"' + ""Admin/GetLog?ordernumber="" + txt,function (v)
            {
                var data = v;
                var ordernum = $(""#spanordernumber"");
                ordernum.html(data[0].ordernumber);

                if (data != null) {

                    var tblEmployee = $(""#tblEmployee"");
                    $.each(data, function (index, item) {
                        console.log(item.category);
                        var tr = $(""<tr  class=resultsOdd></tr>"");
                        tr.html((""<td>"" + item.category + ""</td>"")
                            + "" "" + (""<td>"" + item.date + ""</td>"")
                            + "" "" + (""<td>  <textarea class='textareaField' cols='50' rows='6' style='height: 100px;'>"" + item.message +""</textarea> </td>""));

                  
                        tblEmployee.append(tr);

                    });
                }
                    else {
                        alert(""OrderNumber :"" + txt + ""No details found"");
                    }
                WriteLiteral("\n\r\n            });\r\n        }\r\n");
                WriteLiteral("    </script>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<smb_om.Model.ViewLog>> Html { get; private set; }
    }
}
#pragma warning restore 1591