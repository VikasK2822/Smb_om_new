#pragma checksum "C:\projects\manoj\smb_om\smb_om\Views\UserManager\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1729d34d05988210abc3c98751e956248d5ece15"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserManager_Index), @"mvc.1.0.view", @"/Views/UserManager/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1729d34d05988210abc3c98751e956248d5ece15", @"/Views/UserManager/Index.cshtml")]
    public class Views_UserManager_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<smb_om.Model.UserManager>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/jquery.passwordRequirements.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.passwordRequirements.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\projects\manoj\smb_om\smb_om\Views\UserManager\Index.cshtml"
  
    ViewData["Title"] = "Sequential-Tech";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1729d34d05988210abc3c98751e956248d5ece153911", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<div class=\"main\">\r\n    <div class=\"main-box\">\r\n        <div class=\"title\">\r\n            <h2>User Information</h2>\r\n        </div>\r\n        <input id=\"userProgram\" type=\"hidden\" value=\"Y\" />\r\n        <input id=\"userPartner\" type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 527, "\"", 535, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n        <input id=\"userAffiliate\" type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 588, "\"", 596, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
        <input id=""loginUserId"" type=""hidden"" value=""sachin.s"" />
        <div class=""customer-form"">

            <form asp-action=""Create"" asp-controller=""UserManager"" id=""user_manager"" method=""post"" name=""user_manager"">
                <div class=""checkout-block margin-bottom-20"">
                    <div class=""checkout-title"" style=""width: auto;"">
                        <h5>Create User</h5>
                    </div>
");
            WriteLiteral("                    ");
#nullable restore
#line 30 "C:\projects\manoj\smb_om\smb_om\Views\UserManager\Index.cshtml"
               Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 32 "C:\projects\manoj\smb_om\smb_om\Views\UserManager\Index.cshtml"
                     if (ViewBag.Message != null)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\projects\manoj\smb_om\smb_om\Views\UserManager\Index.cshtml"
                         if (ViewBag.Message.Contains("Error"))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div style=\"color: #D8000C;background-color: #FFD2D2;margin: 0px 0px 14px 0px; padding:2px;display: inline-block;\">\r\n                                <strong>\r\n                                    ");
#nullable restore
#line 38 "C:\projects\manoj\smb_om\smb_om\Views\UserManager\Index.cshtml"
                               Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </strong>\r\n                            </div>\r\n");
#nullable restore
#line 41 "C:\projects\manoj\smb_om\smb_om\Views\UserManager\Index.cshtml"

                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div style=\"color:#0f24e2;margin: 0px 0px 14px 0px; padding:2px;display: inline-block;\">\r\n                                <strong>\r\n                                    ");
#nullable restore
#line 47 "C:\projects\manoj\smb_om\smb_om\Views\UserManager\Index.cshtml"
                               Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </strong>\r\n                            </div>\r\n");
#nullable restore
#line 50 "C:\projects\manoj\smb_om\smb_om\Views\UserManager\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "C:\projects\manoj\smb_om\smb_om\Views\UserManager\Index.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"row\">\r\n");
            WriteLiteral(@"                        <div class=""inner-row"" style=""padding: 0 4% 0 0;"">
                            <span class=""label"" style=""padding: 0 0 0;"">
                                <label asp-for=""Role_Type"" class=""control-label""><span class=""marked-red"">*</span>Role</label>
                            </span>
                            <div class=""text-row"">
                                <span>
                                    <select class=""select avarage-select order_userid_group"" asp-for=""Role_Type"" style=""height: 20px;"">
                                        <option");
            BeginWriteAttribute("value", " value=\"", 3651, "\"", 3659, 0);
            EndWriteAttribute();
            WriteLiteral(@">--Select--</option>
                                        <option value=""50"">User</option>
                                        <option value=""40"">Affiliate Admin</option>
                                        <option value=""30"">Corporate Admin</option>
                                        <option value=""20"">SuperUser</option>
                                        <option value=""10"">Global Admin</option>
                                    </select>
                                </span>
                                <span class=""inline-error"" asp-validation-for=""Role_Type""></span>
");
            WriteLiteral(@"                            </div>
                        </div>
                        <div class=""inner-row"" style=""padding: 0 4% 0 0;"">
                            <span class=""label"" style=""padding: 0 0 0;"">
                                <label asp-for=""First_Name"" class=""control-label""><span class=""marked-red"">*</span>First Name</label>
                            </span>
                            <div class=""text-row"">
                                <span>
                                    <input asp-for=""First_Name"" class=""home text large"" />
                                </span>
                                <span class=""inline-error"" id=""first_name-error""></span>
                            </div>
                        </div>
                        <div class=""inner-row"" style=""padding: 0 4% 0 0;"">
                            <span class=""label"" style=""padding: 0 0 0;"">
                                <label asp-for=""Last_Name"" class=""control-label"">Last Name</label>
 ");
            WriteLiteral(@"                           </span>
                            <div class=""text-row"">
                                <span>
                                    <input asp-for=""Last_Name"" class=""home text large"" />
                                </span>
                                <span class=""inline-error""></span>
                            </div>
                        </div>
                        <div class=""inner-row"" style=""padding: 0 4% 0 0;"">
                            <span class=""label"" style=""padding: 0 0 0;"">
                                <label asp-for=""UserId"" class=""control-label""><span class=""marked-red"">*</span>Login Id</label>
                            </span>
                            <div class=""text-row"">
                                <span>
                                    <input asp-for=""UserId"" class=""home text large"" />
                                </span>
");
            WriteLiteral(@"                                <span class=""inline-error"" asp-validation-for=""UserId""></span>
                            </div>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""inner-row"" style=""padding: 0 4% 0 0;"">
                            <span class=""label"" style=""padding: 0 0 0;"">
                                <label asp-for=""Email"" class=""control-label""><span class=""marked-red"">*</span>Email Address</label>
                            </span>
                            <div class=""text-row"">
                                <span>
                                    <input asp-for=""Email"" class=""home text large"" />
                                </span>
                                <span class=""inline-error"" id=""email-error""></span>
                            </div>
                        </div>
                        <div class=""inner-row"" style=""padding: 0 4% 0 0;"">
                        ");
            WriteLiteral(@"    <span class=""label"" style=""padding: 0 0 0;"">
                                <label asp-for=""Phone_Number"" class=""control-label""><span class=""marked-red"">*</span>Phone Number</label>
                            </span>
                            <div class=""text-row"">
                                <span>
                                    <input asp-for=""Phone_Number"" class=""home text large"" />
                                </span>
                                <span class=""inline-error"" id=""phone_number-error""></span>
                            </div>
                        </div>
                        <div class=""inner-row"" style=""padding: 0 4% 0 0;"">
                            <span class=""label"" style=""padding: 0 0 0;"">
                                <label asp-for=""Password"" class=""control-label""><span class=""marked-red"">*</span>Password</label>
                            </span>
                            <div class=""text-row"">
                                <span>
 ");
            WriteLiteral(@"                                   <input asp-for=""Password"" class=""home text large pr-password"" type=""password"" />
                                </span>
                                <span class=""inline-error"" id=""password-error""></span>
                            </div>
                        </div>
                        <div class=""inner-row"" style=""padding: 0 4% 0 0;"">
                            <span class=""label"" style=""padding: 0 0 0;"">
                                <label asp-for=""Confirm_Password"" class=""control-label""><span class=""marked-red"">*</span>Confirm Password</label>
                            </span>
                            <div class=""text-row"">
                                <span>
                                    <input asp-for=""Confirm_Password"" class=""home text large"" type=""password"" />
                                </span>
                                <span class=""inline-error"" id=""confirm_password-error""></span>
                            </div");
            WriteLiteral(@">
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""inner-row"" style=""padding: 0 4% 0 0;"">
                            <span class=""label"" style=""padding: 0 0 0;"">
                                <label asp-for=""Account_Lock"">Account Lock</label>
                            </span>
                            <div class=""text-row"">
                                <span>
                                    <input class=""radio order_userid_group"" type=""checkbox"" asp-for=""Account_Lock"" checked=""checked"">
");
            WriteLiteral(@"                                </span>
                                <span class=""inline-error""></span>
                            </div>
                        </div>
                        <div class=""inner-row"" style=""padding: 0 4% 0 0;"">
                            <span class=""label"" style=""padding: 0 0 0;"">
                                <label asp-for=""Pass_Never_Expire"" class=""control-label"">Password Never Expires</label>
                            </span>
                            <div class=""text-row"">
                                <span>
                                    <input class=""radio order_userid_group"" type=""checkbox"" asp-for=""Pass_Never_Expire"" checked=""checked"">
");
            WriteLiteral(@"                                </span>
                                <span class=""inline-error""></span>
                            </div>
                        </div>
                        <div class=""inner-row"" style=""padding: 0 4% 0 0;"">
                            <span class=""label"" style=""padding: 0 0 0;"">
                                <label asp-for=""Max_Login""><span class=""marked-red"">*</span>Max Logins</label>
                            </span>
                            <div class=""text-row"">
                                <span>
                                    <input asp-for=""Max_Login"" class=""home text large"" type=""text"" />
                                </span>
                                <span class=""inline-error""></span>
                                <span class=""inline-error"" asp-validation-for=""Max_Login""></span>

                            </div>
                        </div>
                    </div>
                    <div class=""row"">
        ");
            WriteLiteral(@"                <div class=""inner-row"" style=""padding: 0 4% 0 0;"">
                            <span class=""label"" style=""padding: 0 0 0;""><label asp-for=""Program"">Program</label></span>
                            <div class=""text-row"">
                                <span>
                                    <input class=""radio order_userid_group"" asp-for=""Program"" asp-type=""checkbox"" checked=""checked"">
                                </span>
                                <span class=""inline-error""></span>
                            </div>
                        </div>
                        <div class=""inner-row"" style=""padding: 0 4% 0 0;"">
                            <span class=""label"" style=""padding: 0 0 0;""><label asp-for=""PartnerId"">Partner</label></span>
                            <div class=""text-row"">
                                <span>
                                    <select class=""select avarage-select order_userid_group"" asp-for=""PartnerId"" onchange=""populateAffiliate(");
            WriteLiteral(@");"" style=""height: 24px;"">
                                    </select>
                                </span><span class=""inline-error""></span>
                            </div>
                        </div>
                        <div class=""inner-row"" style=""padding: 0 4% 0 0;"">
                            <span class=""label"" style=""padding: 0 0 0;""><label asp-for=""Affiliate_Name"">Affiliate</label></span><div class=""text-row"">
                                <span>
                                    <select class=""select avarage-select order_userid_group"" asp-for=""Affiliate_Name"" style=""height: 24px;"">
                                        <option selected=""selected""");
            BeginWriteAttribute("value", " value=\"", 13838, "\"", 13846, 0);
            EndWriteAttribute();
            WriteLiteral(@">--Select--</option>
                                    </select>
                                </span><span class=""inline-error""></span>
                            </div>
                        </div>

                        <div class=""inner-row"" style=""padding: 0 4% 0 0;"">
                            <div class=""text-row"" style=""margin-top: 25%;"">
                                <div class=""general-btn"">
                                    <div class=""holder"">
                                        <div class=""frame"">
                                            <span>
                                                <span class=""btn-blue"">
                                                    <input class=""submit form"" id=""searchbutton"" type=""submit"" value=""Submit"">Submit
                                                </span>
                                            </span>
                                        </div>
                                    </div>
                  ");
            WriteLiteral("              </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </form>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 257 "C:\projects\manoj\smb_om\smb_om\Views\UserManager\Index.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1729d34d05988210abc3c98751e956248d5ece1521580", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script>
        function isValidPhoneNumber(val) {
            val = val.replace(/[\s|-]+/g, """");
            if (val.length == 10) {
                val = val.substring(0, 3) + '-' + val.substring(3, 6) + '-' + val.substring(6, 10);
                return val.match(/^\d{10}$|^\d{3}-\d{3}-\d{4}$/) && !val.match(/^0{3}-0{3}-0{4}$/);
            }
            return false;
        }
    </script>
    <script type=""text/javascript"">
        function populateAffiliate() {
            var PartnerId = $(""#PartnerId"").val();
            $.ajax({
                type: ""GET"",
                url: ""../api/values/getAffiliate/"" + PartnerId,
                contentType: ""application/json; charset=utf-8"",
                dataType: ""json"",
            }).done(function (data) {
                var s;
                for (var i = 0; i < data.length; i++) {
                    s += '<option value=""' + data[i].affiliateName + '"">' + data[i].affiliateName + '</option>';
                }
          ");
                WriteLiteral(@"      console.log(s);
                $(""#Affiliate_Name"").html(s);
            });
        }

        $(document).ready(function () {

            $("".submit.form"").on(""click"", function () {
                if ($(""#user_manager"").valid()) {
                    $('#order-processing').modal({
                        backdrop: 'static',
                        keyboard: false
                    });
                    setTimeout(
                        function () {
                            $(""#user_manager"").submit();
                        }, 300
                    );
                }
                return false;
            });

            //$(""#user_manager"").validate({
            //    rules: {
            //        Phone_Number: {
            //            Phone_Number: '#Phone_Number'
            //        }
            //    },
            //});
            //$.validator.addMethod(""Phone_Number"", function (val, element) {
            //    return this.optional(el");
                WriteLiteral(@"ement) || isValidPhoneNumber(val);
            //}, 'Please enter a valid phone number');

            ////$.validator.addMethod(""email"", function (val, element) {
            ////    return this.optional(element) || isValidEmailAddress(val);
            ////}, 'Please enter a valid email address');



            /*  $('#Password').attr('data-password', '888');*/
            $('.pr-password').passwordRequirements({
                numCharacters: 10,
                useLowercase: true,
                useUppercase: true,
                useNumbers: true,
                useSpecial: true
            });

            $.ajax({
                type: ""GET"",
                url: ""../api/values/GetPartner"",
                contentType: ""application/json; charset=utf-8"",
                dataType: ""json"",
            }).done(function (data) {
                var s;
                for (var i = 0; i < data.length; i++) {
                    s += '<option value=""' + data[i].partnerId + '"">' + d");
                WriteLiteral(@"ata[i].partnerName + '</option>';
                }
                $(""#PartnerId"").html(s);
            });
            $.ajax({
                type: ""GET"",
                url: ""../api/values/getAffiliate"",
                contentType: ""application/json; charset=utf-8"",
                dataType: ""json"",
            }).done(function (data) {
                var s;
                for (var i = 0; i < data.length; i++) {
                    s += '<option value=""' + data[i].affilitateId + '"">' + data[i].affiliateName + '</option>';
                }
                $(""#Affiliate_Name"").html(s);
            });

            $('#searchbutton').click(function () {

                var trackValid = 0;
                document.getElementById('Role_Type-error').innerHTML = """";
                document.getElementById('first_name-error').innerHTML = """";
                document.getElementById('UserId-error').innerHTML = """";
                document.getElementById('email-error').innerHTML = """";
");
                WriteLiteral(@"                document.getElementById('phone_number-error').innerHTML = """";
                document.getElementById('password-error').innerHTML = """";
                document.getElementById('confirm_password-error').innerHTML = """";


                if ($('#Role_Type').val() == null || $('#Role_Type').val() == """") {
                    document.getElementById('Role_Type-error').innerHTML = ""Role is required"";
                    trackValid = 1;

                }
                if ($('#First_Name').val() == null || $('#First_Name').val() == """") {
                    document.getElementById('first_name-error').innerHTML = ""First Name is Required"";
                    trackValid = 1;
                }
                if ($('#UserId').val() == null || $('#UserId').val() == """") {
                    document.getElementById('UserId-error').innerHTML = ""Login Id is Required"";
                    trackValid = 1;
                }

                if ($('#Email').val() == null || $('#Email').val");
                WriteLiteral(@"() == """") {
                    document.getElementById('email-error').innerHTML = ""Email is Required"";
                    trackValid = 1;
                }
                if ($('#Phone_Number').val() == null || $('#Phone_Number').val() == """") {
                    document.getElementById('phone_number-error').innerHTML = ""Phone Number is Required"";
                    trackValid = 1;
                }
                if ($('#Password').val() == null || $('#Password').val() == """") {
                    document.getElementById('password-error').innerHTML = ""Password is Required"";
                    trackValid = 1;
                }
                if ($('#Confirm_Password').val() == null || $('#Confirm_Password').val() == """") {
                    document.getElementById('confirm_password-error').innerHTML = ""Confirm Password is Required"";
                    trackValid = 1;
                }

                if ($('#Password').attr('data-password') != '1') {
                    ///alert(""");
                WriteLiteral(@"Password does not match complexity requirements"");
                    document.getElementById('password-error').innerHTML = ""Password does not match complexity requirements"";
                    $('#Password').focus();
                    trackValid = 1
                }
                if ($('#Password').val() != $('#Confirm_Password').val()) {
                    ///alert(""Password does not match complexity requirements"");
                    document.getElementById('confirm_password-error').innerHTML = ""Password & Confirm Password does not match"";
                    $('#Confirm_Password').focus();
                    trackValid = 1
                }
                //alert($('#Role_Type').val())
                if (trackValid == 1) {
                    return false;
                } else {
                    return true;
                }
            });

        });
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<smb_om.Model.UserManager> Html { get; private set; }
    }
}
#pragma warning restore 1591