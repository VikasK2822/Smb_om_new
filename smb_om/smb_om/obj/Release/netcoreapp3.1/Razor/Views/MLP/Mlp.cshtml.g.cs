#pragma checksum "C:\projects\manoj\smb_om\smb_om\Views\MLP\Mlp.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dbd86e6d88668037a2e42f6c47b4c38f3467e2bd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MLP_Mlp), @"mvc.1.0.view", @"/Views/MLP/Mlp.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dbd86e6d88668037a2e42f6c47b4c38f3467e2bd", @"/Views/MLP/Mlp.cshtml")]
    public class Views_MLP_Mlp : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<smb_om.Model.MlpModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dbd86e6d88668037a2e42f6c47b4c38f3467e2bd3039", async() => {
                WriteLiteral(@"
    <div id=""content-body"">
        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
            <tbody>
                <tr>
                    <td class=""stroke"" height=""1"" width=""1""></td>
                    <td align=""center"">
                        <div class=""application"">
                            <div style=""display: inline-block;width: 80%;"">
                                <h1>
                                    Business- Main Landing Page
                                </h1>
                            </div>
                            <div style=""width: 10%;float: right;display: inline;margin-top: 1.5%;margin-right: 1.5%;"">

                            </div>
                            <p class=""error""></p>
                            <div class=""cmxform_short content-border"" id=""queueDiv"">
                                <fieldset>

                                    <div");
                BeginWriteAttribute("class", " class=\"", 1039, "\"", 1047, 0);
                EndWriteAttribute();
                WriteLiteral(@" id=""rc1_received"">
                                        <h2 xmlns=""http://www.w3.org/1999/xhtml"">NEW SMBC Business</h2>
                                        <hr xmlns=""http://www.w3.org/1999/xhtml"" class=""break"" />
                                        <fieldset xmlns=""http://www.w3.org/1999/xhtml"">
                                            <div class=""contentBlock"">
                                                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
");
                WriteLiteral("                                                    <tbody>\r\n");
#nullable restore
#line 38 "C:\projects\manoj\smb_om\smb_om\Views\MLP\Mlp.cshtml"
                                                         if (Model.product_Types != null && Model.product_Types.Count > 0)
                                                        {
                                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\projects\manoj\smb_om\smb_om\Views\MLP\Mlp.cshtml"
                                                             for (int i = 0; i < Model.product_Types.Count; i++)
                                                            {
                                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "C:\projects\manoj\smb_om\smb_om\Views\MLP\Mlp.cshtml"
                                                                 if (!string.IsNullOrEmpty(@Model.product_Types[i].ProductName))
                                                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                                    <tr>\r\n                                                                        <td style=\"vertical-align: top; text-align: right;\"><span class=\"subheader\">");
#nullable restore
#line 45 "C:\projects\manoj\smb_om\smb_om\Views\MLP\Mlp.cshtml"
                                                                                                                                               Write(Model.product_Types[i].ProductName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span></td>
                                                                        <td colspan=""2"">
                                                                            <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style=""padding: 0px; margin: 0px;"">
                                                                                            Oldest Order in Queue:
                                                                                            <br /><br />
                                                                                            Total Number of Orders in Queue:

                                                                                        </td>
                          ");
                WriteLiteral("                                                              <td style=\"padding: 0px; margin: 0px; text-align: right;\">\r\n                                                                                            ");
#nullable restore
#line 57 "C:\projects\manoj\smb_om\smb_om\Views\MLP\Mlp.cshtml"
                                                                                       Write(Model.product_Types[i].OldestOrderQuene);

#line default
#line hidden
#nullable disable
                WriteLiteral("<br /><br />");
#nullable restore
#line 57 "C:\projects\manoj\smb_om\smb_om\Views\MLP\Mlp.cshtml"
                                                                                                                                           Write(Model.product_Types[i].TotalnoOrders);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>

                                                                        <td style=""text-align: right;"">");
#nullable restore
#line 67 "C:\projects\manoj\smb_om\smb_om\Views\MLP\Mlp.cshtml"
                                                                                                  Write(Model.product_Types[i].ProductName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\r\n                                                                        <td><span");
                BeginWriteAttribute("style", " style=\'", 5132, "\'", 5261, 11);
                WriteAttributeValue("", 5140, "height:", 5140, 7, true);
                WriteAttributeValue(" ", 5147, "15px;", 5148, 6, true);
                WriteAttributeValue(" ", 5153, "width:", 5154, 7, true);
                WriteAttributeValue(" ", 5160, "15px;", 5161, 6, true);
                WriteAttributeValue(" ", 5166, "background-color:", 5167, 18, true);
#nullable restore
#line 69 "C:\projects\manoj\smb_om\smb_om\Views\MLP\Mlp.cshtml"
WriteAttributeValue("", 5184, Model.product_Types[i].SLA_Color, 5184, 33, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 5217, ";", 5217, 1, true);
                WriteAttributeValue(" ", 5218, "border-radius:", 5219, 15, true);
                WriteAttributeValue(" ", 5233, "50%;", 5234, 5, true);
                WriteAttributeValue(" ", 5238, "display:", 5239, 9, true);
                WriteAttributeValue(" ", 5247, "inline-block;", 5248, 14, true);
                EndWriteAttribute();
                WriteLiteral("></span></td>\r\n                                                                        <td>\r\n                                                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dbd86e6d88668037a2e42f6c47b4c38f3467e2bd11205", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 71 "C:\projects\manoj\smb_om\smb_om\Views\MLP\Mlp.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.product_Types[i].ProductName);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                                                            <input name=""token"" type=""hidden"" value=""0832eaeb-d1ad-441b-804e-f9b694ce769b"" form=""NEWRC1RECEIVEDFFLFFL"" />
                                                                            <select class=""adjPulldown"" name=""criteria"" style=""width: 100%;"" form=""NEWRC1RECEIVEDFFLFFL""");
                BeginWriteAttribute("id", " id=\"", 5857, "\"", 5883, 2);
                WriteAttributeValue("", 5862, "drpdown_", 5862, 8, true);
#nullable restore
#line 73 "C:\projects\manoj\smb_om\smb_om\Views\MLP\Mlp.cshtml"
WriteAttributeValue("", 5870, i.ToString(), 5870, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n");
#nullable restore
#line 75 "C:\projects\manoj\smb_om\smb_om\Views\MLP\Mlp.cshtml"
                                                                                 foreach (var item1 in Model.product_Types[i].PartnerDaysOrder)
                                                                                {


#line default
#line hidden
#nullable disable
                WriteLiteral("                                                                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dbd86e6d88668037a2e42f6c47b4c38f3467e2bd14182", async() => {
                    WriteLiteral("\r\n                                                                                        ");
#nullable restore
#line 79 "C:\projects\manoj\smb_om\smb_om\Views\MLP\Mlp.cshtml"
                                                                                   Write(item1.PartnerText);

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                                                                                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 78 "C:\projects\manoj\smb_om\smb_om\Views\MLP\Mlp.cshtml"
                                                                                      WriteLiteral(item1.PartnerValue);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 81 "C:\projects\manoj\smb_om\smb_om\Views\MLP\Mlp.cshtml"
                                                                                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                                            </select>
                                                                        </td>
                                                                        <td>
                                                                            <input class=""button-css"" name=""defaultNext"" type=""button""");
                BeginWriteAttribute("id", " id=\"", 6905, "\"", 6931, 2);
                WriteAttributeValue("", 6910, "btnnext_", 6910, 8, true);
#nullable restore
#line 86 "C:\projects\manoj\smb_om\smb_om\Views\MLP\Mlp.cshtml"
WriteAttributeValue("", 6918, i.ToString(), 6918, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" value=\"Get Next Order\"");
                BeginWriteAttribute("onclick", " onclick=\"", 6955, "\"", 7041, 5);
                WriteAttributeValue("", 6965, "onbuttonclick(\'drpdown_", 6965, 23, true);
#nullable restore
#line 86 "C:\projects\manoj\smb_om\smb_om\Views\MLP\Mlp.cshtml"
WriteAttributeValue("", 6988, i.ToString(), 6988, 13, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 7001, "\',\'", 7001, 3, true);
#nullable restore
#line 86 "C:\projects\manoj\smb_om\smb_om\Views\MLP\Mlp.cshtml"
WriteAttributeValue("", 7004, Model.product_Types[i].ProductName, 7004, 35, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 7039, "\')", 7039, 2, true);
                EndWriteAttribute();
                WriteLiteral(" />\r\n\r\n                                                                        </td>\r\n\r\n                                                                    </tr>\r\n");
#nullable restore
#line 91 "C:\projects\manoj\smb_om\smb_om\Views\MLP\Mlp.cshtml"

                                                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 92 "C:\projects\manoj\smb_om\smb_om\Views\MLP\Mlp.cshtml"
                                                                 

                                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 94 "C:\projects\manoj\smb_om\smb_om\Views\MLP\Mlp.cshtml"
                                                             
                                                        }
                                                        else
                                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                                            <tr>
                                                                <td>
                                                                    <div class=""alert alert-warning"" id=""no_orders"">No orders available</div>
                                                                </td>
                                                            </tr>
");
#nullable restore
#line 103 "C:\projects\manoj\smb_om\smb_om\Views\MLP\Mlp.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                    </tbody>
                                                </table>
                                            </div>
                                        </fieldset>

                                    </div>
                                </fieldset>
                            </div>
                            <div class=""divider""></div>
                        </div>
                    </td>
                    <td class=""stroke"" height=""1"" width=""1""></td>
                </tr>
            </tbody>
        </table>
    </div>
    <script type=""text/javascript"">
        function onbuttonclick(partner_Element,product_name)
        {

            var order_partner_name = $(""#""+partner_Element+"""").val();

            $.getJSON('");
#nullable restore
#line 127 "C:\projects\manoj\smb_om\smb_om\Views\MLP\Mlp.cshtml"
                  Write(Url.Content("~/"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"' + ""MLP/GetOrderTransactionId?product_name="" + product_name + ""&partner_name="" + order_partner_name, function (OrderId_Data)
            {

                debugger;
                window.location.href = ""/orderprocess/Index/?orderId="" + OrderId_Data+""&returnurl=mlp"";

            });


        }
    </script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<smb_om.Model.MlpModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
