/*
 * Copyright 2008-2022 Sequential Tech  All Rights Reserved.
 *
 * This source code is the confidential and proprietary information of
 * Sequential Tech
 *
 * ("Confidential Information"). You shall not disclose such Confidential
 * Information and shall use it only in accordance with the terms of the
 * license agreement you entered into with Synchronoss Technologies.
 */
function submitAction(myAction) {
  document.forms[0].action = myAction;
  document.forms[0].submit();

  return false;
}

function Browser() {
  var ua, s, i;

  this.isIE    = false;  // Internet Explorer
  this.isOP    = false;  // Opera
  this.isNS    = false;  // Netscape
  this.isSF    = false;  // Safari
  this.version = null;

  ua = navigator.userAgent;

   s = "Safari";
  if ((i = ua.indexOf(s)) >= 0) {
    this.isSF = true;
    this.version = parseFloat(ua.substr(i + s.length));
    return;
  }

  s = "Opera";
  if ((i = ua.indexOf(s)) >= 0) {
    this.isOP = true;
    this.version = parseFloat(ua.substr(i + s.length));
    return;
  }

  s = "Netscape6/";
  if ((i = ua.indexOf(s)) >= 0) {
    this.isNS = true;
    this.version = parseFloat(ua.substr(i + s.length));
    return;
  }

  // Treat any other "Gecko" browser as Netscape 6.1.
  s = "Gecko";
  if ((i = ua.indexOf(s)) >= 0) {
    this.isNS = true;
    this.version = 6.1;
    return;
  }

  s = "MSIE";
  if ((i = ua.indexOf(s))) {
    this.isIE = true;
    this.version = parseFloat(ua.substr(i + s.length));
    return;
  }
}


function enableAllFields() {
    var d = window.document;
    disableFieldsByContainer(d, false);
 }


function disableAllFields() {
    var d = window.document;
    disableFieldsByContainer(d, true);
}

function disableFieldsByContainer(oContainer, bDisabled) {
    var c = oContainer.getElementsByTagName('INPUT');
    for (i = 0; i < c.length; i++) {
     if (c[i].type == 'checkbox' ||
         c[i].type == 'file' ||
         c[i].type == 'radio' ||
         c[i].type == 'password' ||
         c[i].type == 'text') {
         c[i].disabled = bDisabled;
     }
    }

    c = oContainer.getElementsByTagName('SELECT');
    for (i = 0; i < c.length; i++) {
     c[i].disabled = bDisabled;
    }

    c = oContainer.getElementsByTagName('TEXTAREA');
    for (i = 0; i < c.length; i++) {
     c[i].disabled = bDisabled;
    }
}

// Sets the readonly value for all text / password / textarea inputs
// on the specified container to the value of bReadOnly
function readonlyFieldsByContainer(oContainer, bReadOnly) {
  var c = oContainer.getElementsByTagName('INPUT');
  for (i = 0; i < c.length; i++) {
    if (c[i].type == 'password' || c[i].type == 'text') {
      c[i].readOnly = bReadOnly;
      c[i].className = "readonly";
    } else if (c[i].type == 'checkbox' || c[i].type == 'radio') {
      c[i].className = "readonly";
      c[i].disabled = bReadOnly;
    }
  }

  c = oContainer.getElementsByTagName('SELECT');
  for (i = 0; i < c.length; i++) {
    if (c[i].className != "no-readonly") {
        c[i].className = "readonly";
        c[i].disabled = bReadOnly;
    }
  }

  c = oContainer.getElementsByTagName('TEXTAREA');
  for (i = 0; i < c.length; i++) {
    c[i].readOnly = bReadOnly;
    c[i].className = "readonly";
  }

  // calendar links
  c = oContainer.getElementsByTagName('A');
  for (i = 0; i < c.length; i++) {
    // if it starts w/ this, it's a calendar
    if (!c[i].href.indexOf("javascript:show_cal")) {
      c[i].href="#";
    }
  }
}

//ZIP Function
function validateZIP(field) {
//alert("in");
//alert(field==null);
var valid = "0123456789-";
var hyphencount = 0;
if (field.length!=5 && field.length!=10) {
alert("Please enter a 5 digit or 5 digit plus 4 zip code.");
return false;
}
for (var i=0; i < field.length; i++) {
temp = "" + field.substring(i, i+1);
if (temp == "-") hyphencount++;
if (valid.indexOf(temp) == "-1") {
alert("Zip code contains invalid characters.");
return false;
}
if ((hyphencount > 1) || ((field.length==10) && ""+field.charAt(5)!="-")) {
alert("Zip code must be properly formatted 5 digit or 5 digit plus 4 in the form NNNNN-NNNN.");
return false;
}
}
return true;
}

function submitAjaxAction(method, paramArray, callBackMethod) {
    //alert("submitAjaxAction: method is:" + method);
    var f = document.forms[0];

    var getResponse = new net.ContentLoader(method, paramArray, callBackMethod);
}

function initDropDowns() {
    var d = window.document;
    var c = d.getElementsByTagName('SELECT');
    for (i=0; i < c.length; i++) {
        var sel = c[i];
        if (sel.multiple == false) {
            var name = sel.name;
            if (name.indexOf('/') > -1) {
                name = name.substr(name.lastIndexOf('/') + 1);
            }
            name = name.substr(0,1).toUpperCase() + name.substr(1);

            var hid = d.getElementsByName('selected' + name);
            if (hid.length > 0) {
                var valFound = false;
                //Select from existing options
                for (j=0; j < sel.options.length; j++) {
                    if (sel.options[j].value == hid[0].value) {
                        sel.selectedIndex = j;
                        valFound = true;
                        break;
                    }
                }
                if (!valFound && hid[0].value.length > 0) {
                    //Dynamically add if value is no longer in the option collection
                    var newOption = new Option(hid[0].value, hid[0].value);
                    newOption.className = 'deprecated';
                    sel.options[sel.options.length] = newOption;
                    sel.selectedIndex = sel.options.length - 1;
                }
            }
        }
    }
}


function validationEligibility(theform, action){
   // alert("validationEligibility: action is:" + action);
    if(action == 'coverageCheck'){
    	if(trim(theform.coveragezip.value)==""||theform.coveragezip.length<5)
    	{
    		//if(trim(theform.custaddcity.value)==""||trim(theform.custaddstate.options[theform.custaddstate.selectedIndex].text)=="" )
			if(trim(theform.custaddcity.value)==""||trim(theform.selectedcustaddstate.value)=="" )
    		{
    		alert("Please complete the zipcode or the address fields before performing coverage check.");
    		return;
    		}

    	}else
	    	{	if(!validateZIP(theform.coveragezip.value)) {
	           	fieldFocus(theform.coveragezip);
	           	return;
	        	}
        	}

        //disableButtons(document, true);
        //document.getElementById("coverageResp").value = 'Checking...';
        var paramArray=new Array();
        paramArray[0] = theform.coveragezip.value;
        paramArray[1] = theform.custadd1.value;
        paramArray[2] = theform.custadd2.value;
        paramArray[3] = theform.custaddcity.value;
        paramArray[4] = theform.selectedcustaddstate.value;

      // alert("Before calling Ajax action for coverage");
        submitAjaxAction(action, paramArray, respCoverageCheck);
    }

    if(action == 'lnpCheck'){
        if(!isPhoneNumber(theform.lnpmdn.value)) {
            fieldFocus(theform.lnpmdn);
           	return;
        }
        disableButtons(document, true);
        document.getElementById("lnpResp").value = 'Checking...';
        paramArray = new Array(theform.lnpmdn.value);
        submitAjaxAction(action, paramArray, respLNPCheck);
    }


}

function respCoverageCheck() {

    xmlDoc = this.req.responseXML.documentElement;
    var imagerefid = "";
    var mapcenterx="";
    var mapcentery ="";
    var geocenterx="";
    var geocentery="";
    var scale="";
                var nodes=xmlDoc.childNodes.length;
                //alert('The xml got was'+xmlDoc.xml);
                for(var i=0; i<nodes; i++)
                {
		                        if(xmlDoc.childNodes[i].tagName=='respmessage')
					                {
					                document.getElementById("coverageResp").value = xmlDoc.childNodes[i].text;

					                }
					                if(document.getElementById("coverageResp").value=="")
					                {

			                			if(xmlDoc.childNodes[i].tagName=='mapcenterx')
						                {
						                mapcenterx = xmlDoc.childNodes[i].text;

						                }
						                if(xmlDoc.childNodes[i].tagName=='mapcentery')
						                {
						                mapcentery = xmlDoc.childNodes[i].text;
						                }
						                if(xmlDoc.childNodes[i].tagName=='geocenterx')
						                {
						                geocenterx = xmlDoc.childNodes[i].text;
						                }
						                if(xmlDoc.childNodes[i].tagName=='geocentery')
						                {
						                geocentery = xmlDoc.childNodes[i].text;
						                }
						                if(xmlDoc.childNodes[i].tagName=='scale')
						                {
						                scale = xmlDoc.childNodes[i].text;
						                }
						        	}
						        //alert('The url formed is'+'http://coverage.sprintpcs.com/WebImageStream?mapcenterx='+mapcenterx+'&mapcentery='+mapcentery+'&geocenterx='+geocenterx+'&geocentery='+geocentery+'&endlinex=&endliney=&scale='+scale+'&width=542&height=406&showPinpoint=T&layers=TFFFFTFTTTFFFTFFFFFF');


        		}

    document['scale-01.gif'].src = 'http://coverage.sprintpcs.com/WebImageStream?mapcenterx='+mapcenterx+'&mapcentery='+mapcentery+'&geocenterx='+geocenterx+'&geocentery='+geocentery+'&endlinex=&endliney=&scale='+scale+'&width=542&height=406&showPinpoint=T&layers=TFFFFTFTTTFFFTFFFFFF';
    //document.getElementById("coverageResp").value = xmlDoc;
    /*if(document.getElementById("oZipCovChecked")) {
        document.getElementById("oZipCovChecked").checked = true;
    }



    disableButtons(document, false);*/

}

function respLNPCheck() {

    xmlDoc = this.req.responseXML.documentElement;
    document.getElementById("lnpResp").value = xmlDoc.firstChild.nodeValue;
    if(document.getElementById("lnpEligCheck")) {
        document.getElementById("lnpEligCheck").value = 'true';
    }
    disableButtons(document, false);
}

function trim(str) {
    if (str) {
        return str.replace(/^\s*|\s*$/g,"");
    } else {
        return '';
    }
}

function nullString(str) {
    return(str==null || trim(str).length==0);
}

function formatMaskPhone(oField) {
    try {
        var val = trim(oField.value);
        var re =  /^([1]?)\s?\D?(\d{3})\D{0,2}(\d{3})\D?(\d{4})$/;

        if (val.length == 0) {
            //Valid as empty
            oField.value = val;
            return true;

        } else if (re.test(val)) {
            //Valid format
            oField.value = val.replace(re, "$2$3$4");

            var maxLen = oField.maxLength;
            if (maxLen > 0 && oField.value.length > maxLen) {
                throw('Too Long');            }

        } else {
            throw('Invalid format');
        }
    } catch(err) {
        alert('Invalid Phone Number\nValid format is: 9999999999');
        oField.select();
        fieldFocus(oField);
        return false;
    }
    return true;
}

function formatMaskPhoneNoVal(oField) {
    try {
        var val = trim(oField.value);
        var re =  /^([1]?)\s?\D?(\d{3})\D{0,2}(\d{3})\D?(\d{4})$/;

        if (val.length == 0) {
            //Valid as empty
            oField.value = val;
            return;

        } else if (re.test(val)) {
            //Valid format
            oField.value = val.replace(re, "$2$3$4");

            var maxLen = oField.maxLength;
            if (maxLen > 0 && oField.value.length > maxLen) {
                throw('Too Long');            }

        } else {
            throw('Invalid format');
        }
    } catch(err) {
        return;
    }
}
function formatMaskPhoneWithDash(oField, formatField) {
    try {
        var val = trim(oField.value);
        var re =  /^([1]?)\s?\D?(\d{3})\D{0,2}(\d{3})\D?(\d{4})$/;

        if (val.length == 0) {
            //Valid as empty
            oField.value = val;
            return;

        } else if (re.test(val)) {
            //Valid format
            formatField.value = val.replace(re, "$2-$3-$4");

            var maxLen = oField.maxLength;
            if (maxLen > 0 && oField.value.length > maxLen) {
                throw('Too Long');            }

        } else {
            throw('Invalid format');
        }
    } catch(err) {
        return;
    }
}
function formatMaskDateMMDD(oField) {
    try {
        var re = /^(\d{1,2})\D?(\d{1,2})$/;
        var val = trim(oField.value);

        if (val.length == 0) {
            //Valid as empty
            oField.value = val;
            return true;

        } else if (re.test(val)) {
            //Valid basic format
            val = new String(oField.value)
			val = val.split("/")
			var mm = val[0];
			var dd = val[1];

            //var mm = val.replace(re, "$1");
            if (mm < 1 || mm > 12) {
                throw('Invalid month');
            }

            //var dd = val.replace(re, "$2");
            if (dd < 1 || dd > 31) {
                throw('Invalid day');
            }
            if(mm ==2&&dd>29){
                throw('Invalid day');
            }

            //Convert invalid dates that passed basic test (eg invalid leap years)
           /* var d = new Date(val.replace(re, "$1/$2"));

            //Pad with zeros
            mm = d.getMonth();
            if (mm < 10) {
                mm = '0' + mm;
            }

            dd = d.getDate();
            if (dd < 10) {
                dd = '0' + dd;
            }

            oField.value = mm + '/' + dd;

            var maxLen = oField.maxLength;
            if (maxLen > 0 && oField.value.length > maxLen) {
                throw('Too long');
            }*/

        } else {
            throw('Invalid format');
        }

    } catch(err) {
        alert('Invalid Date\nValid format is: MM/DD');
        oField.select();
        fieldFocus(oField);
        return false;
    }
    return true;
}
function formatMaskDateDob(oField) {
    try {
        var re = /^(\d{4})\D?(\d{1,2})\D?(\d{1,2})$/;
        var val = trim(oField.value);

        if (val.length == 0) {
            //Valid as empty
            oField.value = val;
            return true;

        } else if (re.test(val)) {
            //Valid basic format

            var mm = val.replace(re, "$2");
            if (mm < 1 || mm > 12) {
                throw('Invalid month');
            }

            var dd = val.replace(re, "$3");
            if (dd < 1 || dd > 31) {
                throw('Invalid day');
            }

            //Convert invalid dates that passed basic test (eg invalid leap years)
            var d = new Date(val.replace(re, "$2/$3/$1"));

            //Pad with zeros
            mm = d.getMonth() + 1;
            if (mm < 10) {
                mm = '0' + mm;
            }

            dd = d.getDate();
            if (dd < 10) {
                dd = '0' + dd;
            }

            // this doesn't handle when user enters 08 for 2008.
            // it returns 1908 instead.
            //var yyyy = d.getFullYear();

            // thanks to www.quirksmode.org!
            var year = d.getYear();
            var yyyy = year % 100;
            //Considering the Epoch time for less than 38
            //yyyy += (yyyy > 69) ? 1900 : 2000;
            yyyy += (yyyy < 38) ? 2000 : 1900;

            oField.value = yyyy + '-' + mm + '-' + dd ;

            var maxLen = oField.maxLength;
            if (maxLen > 0 && oField.value.length > maxLen) {
                throw('Too long');
            }

        } else {
            throw('Invalid format');
        }

    } catch(err) {
        alert('Invalid Date\nValid format is: YYYY-MM-DD');
        oField.select();
        fieldFocus(oField);
        return false;
    }
    return true;
}
function formatMaskDate(oField) {
    try {
        var re = /^(\d{1,2})\D?(\d{1,2})\D?(\d{2}|\d{4})$/;
        var val = trim(oField.value);

        if (val.length == 0) {
            //Valid as empty
            oField.value = val;
            return true;

        } else if (re.test(val)) {
            //Valid basic format

            var mm = val.replace(re, "$1");
            if (mm < 1 || mm > 12) {
                throw('Invalid month');
            }

            var dd = val.replace(re, "$2");
            if (dd < 1 || dd > 31) {
                throw('Invalid day');
            }

            //Convert invalid dates that passed basic test (eg invalid leap years)
            var d = new Date(val.replace(re, "$1/$2/$3"));

            //Pad with zeros
            mm = d.getMonth() + 1;
            if (mm < 10) {
                mm = '0' + mm;
            }

            dd = d.getDate();
            if (dd < 10) {
                dd = '0' + dd;
            }

            // this doesn't handle when user enters 08 for 2008.
            // it returns 1908 instead.
            //var yyyy = d.getFullYear();

            // thanks to www.quirksmode.org!
            var year = d.getYear();
            var yyyy = year % 100;
            yyyy += (yyyy > 69) ? 1900 : 2000;

            oField.value = mm + '/' + dd + '/' + yyyy;

            var maxLen = oField.maxLength;
            if (maxLen > 0 && oField.value.length > maxLen) {
                throw('Too long');
            }

        } else {
            throw('Invalid format');
        }

    } catch(err) {
        alert('Invalid Date\nValid format is: MM/DD/YYYY');
        oField.select();
        fieldFocus(oField);
        return false;
    }
    return true;
}
function formatMaskDateWithNoYearChanges(oField) {
    try {
        var re = /^(\d{1,2})\D?(\d{1,2})\D?((19|20)\d{2})$/;
        var val = trim(oField.value);

        if (val.length == 0) {
            //Valid as empty
            oField.value = val;
            return true;

        } else if (re.test(val)) {
            //Valid basic format

            var mm = val.replace(re, "$1");
            if (mm < 1 || mm > 12) {
                throw('Invalid month');
            }

            var dd = val.replace(re, "$2");
            if (dd < 1 || dd > 31) {
                throw('Invalid day');
            }

            var yyyy = val.replace(re, "$3");
            oField.value = mm + '/' + dd + '/' + yyyy;
            var maxLen = oField.maxLength;
            if (maxLen > 0 && oField.value.length > maxLen) {
                throw('Too long');
            }

        } else {
            throw('Invalid format');
        }

    } catch(err) {
        alert('Invalid Date\nValid format is: MM/DD/YYYY');
        oField.select();
        fieldFocus(oField);
        return false;
    }
    return true;
}

function formatMaskCCNum(oField) {
	formatMaskCCNum(oField, null);
}

function formatMaskCCNum(oField, ccType) {
    try {
        var val = trim(oField.value);
        var fmtMsg;

        //Strip all spaces
        var re = new RegExp("\\s", "g");
        val = val.replace(re,'');

        //Determine format based on credit card type
        if (ccType == 'Visa') {
        	//13 or 16 digits starting with 4
        	fmtMsg = 'Valid formats for ' + ccType + ' are: \n4999999999999999\n4999999999999';
        	re = /^(4|(4\d\d\d))(\d{12})$/;
        } else if (ccType == 'MasterCard') {
        	//16 digits starting with 51 through 55
        	fmtMsg = 'Valid formats for ' + ccType + ' are: \n5199999999999999\n5299999999999999\n5399999999999999\n5499999999999999\n5599999999999999';
        	re = /^5{1}[1-5]{1}(\d{14})$/;
        } else if (ccType == 'Discover') {
        	//16 digits starting with 6011
        	fmtMsg = 'Valid format for ' + ccType + ' is: 6011999999999999';
        	re = /^(6011)(\d{12})$/;
        } else if (ccType == 'American Express') {
        	//15 digits starting with 34 or 37
        	fmtMsg = 'Valid formats for ' + ccType + ' are: \n349999999999999\n379999999999999';
        	re = /^((34)|(37))(\d{13})$/;
        } else if (ccType == 'Diners Club' || ccType == 'Carte Blanche') {
        	//14 digits starting with 300 through 305, 36, or 38
        	fmtMsg = 'Valid formats for ' + ccType + ' are: \n30099999999999\n30199999999999\n30299999999999\n30399999999999\n30499999999999\n30599999999999\n36999999999999\n38999999999999';
        	re = /^((30[0-5]{1})|(36\d)|(38\d))(\d{11})$/;
        } else {
        	//13 to 16 digits
        	fmtMsg = 'Valid format is: 9999999999999999';
        	re = /^(\d{13,16})$/;
        }

        if (val.length == 0) {
            //Valid as empty
            oField.value = val;
            return true;
        } else if (re.test(val)) {
            //Valid format
            oField.value = val;

            var maxLen = oField.maxLength;
            if (maxLen > 0 && oField.value.length > maxLen) {
                throw('Too long');
            }

        } else {
            throw(fmtMsg);
        }
    } catch(err) {
        alert('Invalid Credit Card Number\n\n' + err);
        oField.select();
        fieldFocus(oField);
        return false;
    }
    return true;
}

function formatMaskCCExp(oField) {
    try {
        var val = trim(oField.value);
        var re = /^(\d{2})\D?(\d{2})$/;

        if (val.length == 0) {
            //Valid as empty
            oField.value = val;
            return true;

        } else if (re.test(val)) {
            //Valid basic format

            var mm = val.replace(re, "$1");
            if (mm < 1 || mm > 12) {
                throw('Invalid month');
            }

            oField.value = val.replace(re, "$1/$2");
            var Creditexp = oField.value;
			return ValidateCreditExpiry(oField,Creditexp)
        } else {
            throw('Invalid format');
        }
    } catch(err) {
        alert('Invalid Credit Card Expiration Date\nValid format is: MM/YY');
        oField.select();
        fieldFocus(oField);
        return false;
    }
}

//CreditCard Ex. Date Validation
function ValidateCreditExpiry(oField, Creditexp) {
    var current = new Date();
    var currentMonth = current.getMonth() + 1;
    var currentYear = current.getFullYear().toString();
    var currentyearsub = currentYear.substring((currentYear.length) - 2);
    var CreditExpVal = new String(Creditexp)
    CreditExpVal = CreditExpVal.split("/")
    var mm = CreditExpVal[0];
    var yy = CreditExpVal[1];
    if (currentyearsub <= yy) {
        if (currentyearsub == yy) {
            if (currentMonth > mm) {
                alert('Month/Year should be more than or equal to the current month/year')
                oField.select();
                fieldFocus(oField);
                return false;
            }
        }
    } else {
        alert('Month/Year should be more than or equal to the current month/year');
        oField.select();
        fieldFocus(oField);
        return false;
    }
    return true;
}

function formatMaskCCV(oField) {
    try {
        var val = trim(oField.value);
        var re = /^(\d{3})$/;

        if (val.length == 0) {
            //Valid as empty
            oField.value = val;
            return true;
        } else if (re.test(val)) {
            //Valid format
            return true;
        } else {
            throw('Invalid format');
        }
    } catch(err) {
        alert('Invalid CCV Number\nValid format is: 999');
        oField.select();
        fieldFocus(oField);
        return false;
    }
    return true;
}

function formatMaskEmail(oField)
{
    //var re = /^.+@.+\..+$/;
    var re = /^[A-Za-z0-9_!#\$%&'\*\+=\?\^`{}\|~//](([_\.\-a-zA-Z0-9!#\$%&'\*\+=\?\^`{}\|~//]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$/;
    var val = trim(oField.value);
    var match = re.test(val);
    if (val.length > 0 && !match) {
        alert('Invalid E-Mail Address');
        oField.select();
        fieldFocus(oField);
        return false;
    } else {
        oField.value = val;
    }
    return true;
}

/**
 * Tests the field value to ensure it is a valid Zip Code.
 * Allows the user to enter using the format: 5 digits, any optional character, optional 4 digits.
 * If correct, the value will be formatted as 99999[-9999] regardless of the formatting the user applies.
 * If the input value is invalid the user receives an alert message, their cursor is returned to the field, and the value they entered is highlighted.
 *
 * Expects to be called by the onblur event.
 *
 * @param oField Object of an INPUT field
 */
function formatMaskZipCode(oField) {
    try {
        var val = trim(oField.value);
        var re1 =  /^\d{5}$/;
        var re2 = /^(\d{5})\D?(\d{4})$/;

        if (val.length == 0) {
            //Valid as empty
            oField.value = val;
            return true;
        } else if (re1.test(val)) {
            //Valid standard format
            return true;
        } else if (re2.test(val)) {
            //Valid extended format
            oField.value = val.replace(re2, "$1-$2");

            var maxLen = oField.maxLength;
            if (maxLen > 0 && oField.value.length > maxLen) {
                throw('Too long');
            }

        } else {
            throw('Invalid format');
        }
    } catch(err) {
        alert('Invalid Zip Code\nValid format is: 99999 or 99999-9999');
        oField.select();
        fieldFocus(oField);
        return false;
    }
    return true;
}

function formatMaskNumeric(oField) {
    try {
        var val = trim(oField.value);
        var re1 =  /^\d+$/;

        if (val.length == 0) {
            //Valid as empty
            oField.value = val;
            return true;
        } else if (re1.test(val)) {
            //Valid standard format
            return true;
        } else {
            throw('Invalid format');
        }
    } catch(err) {
        alert('Invalid Number');
        oField.select();
        fieldFocus(oField);
        return false;
    }
    return true;
}

function formatMaskCurrency(oField) {
    try {
        var val = trim(oField.value);
        var re1 =  /^\d+(.\d\d)?$/;
        var re2 = /^\d+$/;

        if (val.length == 0) {
            //Valid as empty
            oField.value = val;
            return false;

        } else if (re1.test(val)) {
            //Valid standard format
            if (re2.test(val)) {
              oField.value = val + '.00';
            }
            return true;

        } else {
            throw('Invalid format');
        }
    } catch(err) {
        alert('Invalid Currency');
        oField.select();
        fieldFocus(oField);
        return false;
    }
}


/**
 * Tests the field value to ensure it is a valid Social Security Number.
 * Allows the user to enter using the format: 3 digits, any optional character, 2 digits, any optional character, 4 digits.
 * If correct, the value will be formatted as 999-99-9999 regardless of the formatting the user applies.
 * If the input value is invalid the user receives an alert message, their cursor is returned to the field, and the value they entered is highlighted.
 *
 * Expects to be called by the onblur event.
 *
 * @param oField Object of an INPUT field
 */
function formatMaskSSN(oField) {
    try {
        var val = trim(oField.value);
        var re = /^(\d{3})\D?(\d{2})\D?(\d{4})$/;

        if (val.length == 0) {
            //Valid as empty
            oField.value = val;
            return true;
        } else if (re.test(val)) {
            //Valid basic format
            oField.value = val.replace(re, "$1-$2-$3");

            var maxLen = oField.maxLength;
            if (maxLen > 0 && oField.value.length > maxLen) {
                throw('Too long');
            }
        } else {
            throw('Invalid format');
        }
    } catch(err) {
        alert('Invalid Social Security Number\nValid format is: 999-99-9999');
        oField.select();
        fieldFocus(oField);
        return false;
    }
    return true;
}

function formatMaskSSNWithoutDash(oField, formatField) {
    try {
        var val = trim(oField.value);
        var re = /^(\d{3})(\d{2})(\d{4})$/;

        if (val.length == 0) {
            //Valid as empty
            oField.value = val;
            return;

        } else if (re.test(val)) {
            //Valid format
            formatField.value = val.replace(re, "$1-$2-$3");

            var maxLen = oField.maxLength;
            if (maxLen > 0 && oField.value.length > maxLen) {
                throw('Too Long');            }

        } else {
            throw('Invalid format');
        }
    }  catch(err) {
        alert('Invalid Social Security Number\nValid format is: 999999999');
        oField.select();
        fieldFocus(oField);
        return false;
    }
    return true;
}

function formatDocumentId(oField){
    try {
        var val = trim(oField.value);
        // letters numbers and hyphens and decimals
        var re =  /^K025[A-Za-z0-9-\.]+$|^K023[A-Za-z0-9-\.]+$/;

        if (val.length == 0) {
            //Valid as empty
            oField.value = val;
            return true;

        } else if (re.test(val)) {
            //Valid format
            //strip out hyphens
            removeHyphens(oField);

            // can't use oField.maxLength here since the field needs to allow for hyphens
            var maxLen = 16;
            if (maxLen > 0 && oField.value.length > maxLen) {
                throw('Too Long');
            }
        } else {
            throw('Invalid format');
        }
    } catch(err) {
        alert('Invalid Document ID\nValue must be alphanumeric, less than 16 characters long after removing hyphens and must start with K023 or K025');
        //oField.select();
        fieldFocus(oField);
        return false;
    }
    return true;
}

function removeHyphens(oField){
    oField.value = oField.value.replace(/-/g, "");
}

function disableButtons(oContainer, bDisabled) {
    var c = oContainer.getElementsByTagName('INPUT');

    for (i = 0; i < c.length; i++) {
        if (c[i].type == 'submit' || c[i].type == 'button' || c[i].type == 'image') {
        	setButtonState(c[i].id, !bDisabled);
        }
    }
}

function getRadioValue(radioObj) {
    return getRadioAttribute(radioObj, 'value');
}

function getRadioAttribute(radioObj, attributeName) {
    if (radioObj.length) {
        for (var i = 0; i < radioObj.length; i++) {
            if (radioObj[i].checked)
                return radioObj[i].getAttribute(attributeName);
        }
    } else if (radioObj.type) {
        if (radioObj.type=='radio' && radioObj.checked)
            return radioObj.getAttribute(attributeName);
    }
    return "";
}

function isRadioSelected(radioObj) {
    if (radioObj.length) {
        for (var i = 0; i < radioObj.length; i++) {
            if (radioObj[i].checked)
                return true;
        }
    } else if (radioObj.type) {
        if (radioObj.type=='radio' && radioObj.checked)
            return true;
    }
    return false;
}

function getSelectValue(selectObj) {
    return getSelectAttribute(selectObj, 'value');
}

function getSelectAttribute(selectObj, attributeName) {
    var selIndx = selectObj.selectedIndex;
    var nothing = '';
    if(selIndx == undefined){
        return nothing;
    }else{
        return selectObj[selIndx].getAttribute(attributeName);
    }
}

function setSelectValue(selectObj, checkValue){
	for (var selIndx = 0; selIndx < selectObj.options.count-1; selIndx++) {
	  if (selectObj.options[selIndx].value == checkValue) {
	    selectObj.options[selIndx].selected = true;
	  }
	}
}

function resetForm(oForm) {
    if (confirm("You are about to reset all fields. Are you sure you want to do this?")) {
        oForm.reset();
    }
}

function roundCurr(val) {
    var newVal = 0;

    if (val.toFixed) { //if browser supports toFixed() method
        newVal = val.toFixed(2);
    } else {
        newVal = Math.round(val * 100) * .01;
    }

    return newVal;
}

function validateRequiredFields(oContainer) {
  var oField;
	var fieldLabel;

	try {
		var labels = oContainer.getElementsByTagName('LABEL');
		for (i = 0; i < labels.length; i++) {

			if (labels[i].className == 'label-required') {
				fieldLabel = trim(labels[i].innerText);
				//alert(fieldLabel);
				if (fieldLabel == null || fieldLabel.length == 0)
					fieldLabel = trim(labels[i].innerHTML);

				if (fieldLabel == null || fieldLabel.length == 0 || fieldLabel == '&nbsp;') {
					fieldLabel = 'Field';
        }

        //alert(document.getElementById(labels[i].htmlFor).id);
				oField = document.getElementById(labels[i].htmlFor);
				if (oField!= null && !oField.disabled && oField.type) {
					if (oField.type == 'text' ||
						oField.type == 'password' ||
            oField.type == 'textarea' ||
            oField.type == 'file') {
						if (nullString(oField.value)) {
							throw(fieldLabel + ' is required');
						}
					} else if (oField.type == 'select-one') {
						if (oField.options[oField.selectedIndex].value == '') {
							throw(fieldLabel + ' is required');
						}
					} else if (oField.type == 'radio') {
					    var radioField = document.getElementsByName(oField.name);
						if (!isRadioSelected(radioField)) {
							throw(fieldLabel + ' is required');
						}
					}
				}

			}
		}
		return true;

	} catch (err) {
        alert(err);
        fieldFocus(oField);
        return false;
	}
}


function validateRequiredFieldsWithoutAlert(oContainer) {
	var oField;
	var fieldLabel;

	try {
		var labels = oContainer.getElementsByTagName('LABEL');
		for (i = 0; i < labels.length; i++) {

			if (labels[i].className == 'label-required') {
				fieldLabel = trim(labels[i].innerText);
				//alert(fieldLabel);
				if (fieldLabel == null || fieldLabel.length == 0)
					fieldLabel = trim(labels[i].innerHTML);

				if (fieldLabel == null || fieldLabel.length == 0)
					fieldLabel = 'Field';

				//alert(document.getElementById(labels[i].htmlFor).id);
				oField = document.getElementById(labels[i].htmlFor);
				if (oField.type) {
					if (oField.type == 'text' ||
						oField.type == 'password' ||
						oField.type == 'file') {
						if (nullString(oField.value)) {
							throw(fieldLabel + ' is required');
						}
					} else if (oField.type == 'select-one') {
						if (oField.selectedIndex == 0) {
							throw(fieldLabel + ' is required');
						}
					} else if (oField.type == 'radio') {
					    var radioField = document.getElementsByName(oField.name);
						if (!isRadioSelected(radioField)) {
							throw(fieldLabel + ' is required');
						}
					}
				}

			}
		}
		return null;

	} catch (err) {
		//Note: this will alert the messages. Only return Error message or null.
        //alert(err);
        fieldFocus(oField);
        return err;
	}
}

// returns an array of encrypted fields.  This assumes that there's a label with a style of 'encrypted-field'
// that has a 'for' property set to the real field.
// the array returned is two dimensional in the form of:
//     arr[0] = fieldname
//     arr[1] = encrypted value
function getEncryptedFields() {
    var result = new Array();
    try {
        var idx = 0;
        var labels = document.getElementsByTagName('LABEL');
        for (i = 0; i < labels.length; i++) {
            var arr = new Array(2);
            if (labels[i].className == 'encrypted-field') {
                var val = trim(labels[i].innerText);

                if (val == null || val.length == 0)
                    val = trim(labels[i].innerHTML);

                if (val != null && val.length > 0) {
                    // create the array.  First element is the id of the field, second is the encrypted value
                    arr[0] = labels[i].htmlFor;
                    arr[1] = val.replace(/##NEWLINE##/g, "\n");

                    // add to result
                    result[idx] = arr;

                    // increment
                    idx++;
                }
            }
        }
    } catch (err) {
    }
    return result;
}

function hasNonVisibleParent(element) {
  var parent = element.parentNode;
  // recurse up the hierarchy until the document root is reached, or there is no parent, or the parent has a null style
  while (parent != null && parent != window.document && parent.style != null) {
    if (parent.style.visibility == 'hidden' || parent.style.display == 'none') {
      return true;
    }
    parent = parent.parentNode;
  }
  return false;
}

function fieldFocus(oField) {
	var getField;
  // null oFields were throwing a runtime exception that usually caused control to drop out of a validate function,
  // thus submitting a form.
  // bug 17899 - calling .focus() on an element invisible b/c its parent is invisible causes a javascript error in IE
  if (oField != null && !hasNonVisibleParent(oField)) {
    if (oField.id != '') {
      getField = "document.getElementById('" + oField.id + "')";
    } else {
      getField = "document.getElementsByName('" + oField.name + "')[0]";
    }
    setTimeout(getField + ".focus();",1);  //This has to be delayed due to a bug in the Mozilla event model
  }
}

function maxLength(field, limit) {
    if (field.value.length > (limit)) {
    field.value = field.value.slice(0,limit);
    }
}

/**
 * Used to check/uncheck the master checkbox when a child checkboxes is selected/deselected.
 * This should be implimented on the ONCLICK event of each child checkbox.
 *
 * @param oMstrCbx Single INPUT object of type CHECKBOX that will be used to control a collection of other checkboxes
 * @param oCbxCol  Multiple INPUT controls of type CHECKBOX that can be checked/unchecked based on the master checkbox
 */
function checkOne(oMstrCbx, oCbxCol) {
    var isChecked = false;
    var cntChecked = 0;
    var cntAvail = 0;

    for (a=0; a < oCbxCol.length; a++) {
        if (oCbxCol[a].disabled == false) {
            cntAvail++;
            if (oCbxCol[a].checked) {
                cntChecked++;
                isChecked = true;
            }
        }
    }

    if (cntAvail == cntChecked) {
        oMstrCbx.checked = true;
    } else {
        oMstrCbx.checked = false;
    }
}

function validateEligibleMdns() {
    for(var i=0; i<eligMdns.length;i++){
        var cnt = 0;
        for (var j=0; j<wlnpMdns.length;j++){
            if (wlnpMdns[j] == eligMdns[i])
                cnt++;
        }
        if (cnt == 0) {
            return false;
        }
    }
    return true;
}

/**
 * Used to check/uncheck child checkboxes when the master checkbox is selected/deselected.
 * This should be implimented on the ONCLICK event on the master checkbox.
 *
 * @param oMstrCbx Single INPUT object of type CHECKBOX that will be used to control a collection of other checkboxes
 * @param oCbxCol  Multiple INPUT controls of type CHECKBOX that can be checked/unchecked based on the master checkbox
 */
function checkAll(oMstrCbx, oCbxCol) {
    if(oCbxCol.length == null){
       oCbxCol.checked = oMstrCbx.checked;
       return;
    }

    for (a=0; a < oCbxCol.length; a++) {
        if (oCbxCol[a].disabled == false) {
            oCbxCol[a].checked = oMstrCbx.checked;
        }
    }
}

function CurrencyFormatted(amount)
{
	var i = parseFloat(amount);
	if(isNaN(i)) { i = 0.00; }
	var minus = '';
	if(i < 0) { minus = '-'; }
	i = Math.abs(i);
	i = parseInt((i + .005) * 100);
	i = i / 100;
	s = new String(i);
	if(s.indexOf('.') < 0) { s += '.00'; }
	if(s.indexOf('.') == (s.length - 2)) { s += '0'; }
	s = minus + s;
	return s;
}

/**
 * Used to check and set enabled/disabled and non-required/required states.
 * Used for all input types, labels, and buttons.
 */

 var FIELD_OPTIONAL = false;
 var FIELD_REQUIRED = true;
 var FIELD_ENABLED = true;
 var FIELD_DISABLED = false;

 function setFieldState (idLabel, bRequired, bEnabled) {
     var label = document.getElementById(idLabel);
     var fieldId = label.htmlFor;
     var field = document.getElementById(fieldId);
     field.disabled = !bEnabled;
     var newClassName = 'label';
     if (bRequired == FIELD_REQUIRED) {
         newClassName = newClassName + '-required';
     }
     if (bEnabled == FIELD_DISABLED) {
         newClassName = newClassName + '-disabled';
     }
     label.className = newClassName;
}

 var BUTTON_ENABLED = true;
 var BUTTON_DISABLED = false;

//set button state
function setButtonState(idButton, bEnabled) {
	if (idButton.length > 0) {
	    var btn = (document.getElementById(idButton));
	    if (btn) {
	    	btn.disabled = !bEnabled;
	    	var idx = btn.className.indexOf('-disabled');
			if (idx > -1 && bEnabled) {
			    btn.className = btn.className.substr(0,idx);
			} else if (idx < 0 && !bEnabled) {
			    btn.className = btn.className + "-disabled";
			}
		}
	}
}

function saveUserInfo(){
	var browserName = window.navigator.appName+'';
	var browserVersion = window.navigator.appVersion +'';
	var machineCpuClass = window.navigator.cpuClass+'';
	var machineOperatingSystem = window.navigator.platform+'';
	var browserLanguage = window.navigator.browserLanguage+'';
	var defaultUserLanguage = window.navigator.userLanguage+'';
	var appMinorVersion = window.navigator.appMinorVersion+'';
	var cookieEnabled = window.navigator.cookieEnabled+'';
	var userAgent = window.navigator.userAgent+'';
	var javaEnabled = window.navigator.javaEnabled()+'';
	var taintEnabled = window.navigator.taintEnabled()+'';
	var availHeight = (window.screen).availHeight+'';
	var availWidth = (window.screen).availWidth+'';
	var colorDepth = (window.screen).colorDepth+'';
	var screenHeight = (window.screen).height+'';
	var screenWidth = (window.screen).width+'';

	var tbDate = new Date();
	var month = tbDate.getMonth()+1;
	var browserDate = tbDate.getYear() + '-' + month + '-' + tbDate.getDate() + ' ' + tbDate.getHours() + ':' + tbDate.getMinutes() + ':' + tbDate.getSeconds();

	var temp='browserVersion='+browserVersion+'\n'+'browserName='+browserName+'\n'+'machineCpuClass='+machineCpuClass+'\n'+'machineOperatingSystem='+machineOperatingSystem+'\n'+'defaultUserLanguage='+defaultUserLanguage+'\n'+'appMinorVersion='+appMinorVersion+'\n'+'browserLanguage='+browserLanguage+'\n'+'cookieEnabled='+cookieEnabled+'\n'+'userAgent='+userAgent+'\n'+'javaEnabled='+javaEnabled+'\n'+'taintEnabled='+taintEnabled+'\n'+'availHeight='+availHeight+'\n'+'availWidth='+availWidth+'\n'+'colorDepth='+colorDepth+'\n'+'screenHeight='+screenHeight+'\n'+'screenWidth='+screenWidth+'\n'+'browserDate='+browserDate;
	//alert(temp);
	var params = new Array(browserName,browserVersion,machineCpuClass,machineOperatingSystem,browserLanguage,defaultUserLanguage,appMinorVersion,cookieEnabled,userAgent,javaEnabled,taintEnabled,availHeight,availWidth,colorDepth,screenHeight,screenWidth,browserDate);
	var uniqueUsernameLoader = new net.ContentLoader('saveUserInformation', params , userSavingStatus);
}

function userSavingStatus(){
	return true;
}

function checknumber(strng){
   var error="";
   var anum=/(^\d+$)|(^\d+\.\d+$)/
   if (anum.test(strng)){
         return 'true';
   } else{
        return 'false';
   }
}

function checkAlphaNumbericNSpChars(oField) {
    var val = trim(oField.value);
    if (val != '') {
        var re = new RegExp("^[a-zA-Z0-9\\r\\n//$@#%&'()+-=.,! *:|_;?<>{}]+$");
        var m = re.exec(val);
        if (m == null) {
            alert("Enter valid characters e.g alphanumeric or $@#%&()+-=.,! *:|_;?<>{}");
            oField.select();
            fieldFocus(oField);
            return false;
        }
    }
    return true;
 }


function isAlphaNumeric(val)
{  if (val.match(/^[a-zA-Z0-9]+$/))
	{
		return true;
	}
	else
	{
		return false;
	}
}

/*
 * Currently windowname used incorrectly. Ignoring for now, but keeping around just in case
 * the intention was to popup new URL's in the same window
 */
function popup(mylink, windowname) {
    if (! window.focus)return true;
    var href;
    if (typeof(mylink) == 'string')
        href = mylink;
    else
        href = mylink.href;
    window.open(href, '_blank', 'width=1000,height=500,scrollbars=yes');
    return false;
}


function formatState(oField)
{
     try {
          var val = trim(oField.value);
          var re =  /^(AA|AK|AL|AR|AZ|AP|AE|CA|CO|CT|DC|DE|FL|GA|HI|IA|ID|IL|IN|KS|KY|LA|MA|MD|ME|MI|MN|MO|MS|MT|NC|ND|NE|NH|NJ|NM|NV|NY|OH|OK|OR|PA|PR|RI|SC|SD|TN|TX|UT|VA|VI|VT|WA|WI|WV|WY)$/;

          if (val.length == 0) {
              oField.value = val;
              return true;
          } else if (val.length==2) {
              val = val.toUpperCase();
              oField.value = val;
              if (re.test(val))
                  return true;
              else
                  throw('Invalid State');
		  } else {
              throw('State is greater than 2 characters');
          }
    } catch(err) {
        alert('Invalid State Format');
        oField.select();
        fieldFocus(oField);
        return false;
    }
    return true;
}

function showEmailEditor(transactionId) {
  var emailTemplateId = $("#selectedTemplate option:selected").attr('name');
  if(emailTemplateId != undefined){
    $(".popupoverlay").show();
    $("#emailTemplates").hide();
    EmailFacade.getHtmlEditorEmail(transactionId, emailTemplateId, {
      callback: function (data) {
        $(".jqte_editor").html(data);
        $('.jqte_editor').jqte();
        $('#emailEditView').show();
      }
    });
  }
}

function cancelEmail(){
  $(".popupText").empty();
  $(".popupText").append('<div class="jqte_editor"/>');
  $('#emailEditView').hide();
  $(".popupoverlay").hide();
}

function showTemplates(){
  $("#supressOrderemail").prop('checked', true);
  $(".popupoverlay").show();
  $("#emailTemplates").show();
}

function hideTemplates() {
  $(".popupoverlay").hide();
  $("#emailTemplates").hide();
}

function sendMail(transactionId, emailAdress){
  var mailBody = $(".jqte_editor").html();
  var emailTemplateId = $("#selectedTemplate option:selected").attr('name');
  if(mailBody != null){
    EmailFacade.sendEmail(mailBody, transactionId, emailTemplateId, emailAdress, {
      callback: function () {
        $(".popupText").empty();
        $(".popupText").append('<div class="jqte_editor"/>');
        $('#emailEditView').hide();
        $(".popupoverlay").hide();
        alert("sent successfully");
      }
    });
  }
}