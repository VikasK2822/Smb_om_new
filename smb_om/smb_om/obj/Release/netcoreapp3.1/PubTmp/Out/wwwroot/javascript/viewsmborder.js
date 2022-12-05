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
$(document).ready(function () {
  var tabs = new ddtabcontent("product-info-tabs");
  tabs.setpersist(true);
  tabs.setselectedClassTarget("link");
  tabs.init();
  tabs.expandit(0);

  tabs = new ddtabcontent("account-verify-tabs");
  tabs.setpersist(true);
  tabs.setselectedClassTarget("link");
  tabs.init();
  tabs.expandit(0);

  tabs = new ddtabcontent("contact-address-tabs");
  tabs.setpersist(true);
  tabs.setselectedClassTarget("link");
  tabs.init();
  tabs.expandit(0);

  if (document.getElementById("tabs-section4")!=null || document.getElementById("tabs-section4")!=undefined){
    tabs = new ddtabcontent("tabs-section4");
    tabs.setpersist(true);
    tabs.setselectedClassTarget("account-verify-tabs");
    tabs.init();
    tabs.expandit(0);
  }


  // Access Installation
  //if ($("#accessLine1ActivationDate") != null) {
  //  $("#accessLine1ActivationDate").datepicker({
  //                                               showOtherMonths: true,
  //                                               selectOtherMonths: true
  //                                             });
  //}
  //if ($("#accessLine2ActivationDate") != null) {
  //  $("#accessLine2ActivationDate").datepicker({
  //                                               showOtherMonths: true,
  //                                               selectOtherMonths: true
  //                                             });
  //}
  //if ($("#accessLine1TelephoneNum") != null) {
  //  $("#accessLine1TelephoneNum").mask("999-999-9999");
  //}
  //if ($("#accessLine2TelephoneNum") != null) {
  //  $("#accessLine2TelephoneNum").mask("999-999-9999");
  //}

  //// DSL
  //if ($("#dslActivationDate") != null) {
  //  $("#dslActivationDate").datepicker({
  //                                       showOtherMonths: true,
  //                                       selectOtherMonths: true
  //                                     });
  //}
  //if ($('#dslTnOrFtn') != null) {
  //  $("#dslTnOrFtn").mask("999-999-9999");
  //}

  // Uverse Installation
  //if ($("#uverseRequestedActivationDate") != null) {
  //  $("#uverseRequestedActivationDate").datepicker({
  //                                                   showOtherMonths: true,
  //                                                   selectOtherMonths: true
  //                                                 });
  //}
  //if ($('#uverseRequestedActivationTime') != null) {
  //  $('#uverseRequestedActivationTime').timepicker({
  //                                                   timeFormat: 'h:mm p',
  //                                                   interval: 60,
  //                                                   dynamic: false,
  //                                                   dropdown: true,
  //                                                   scrollbar: true
  //                                                 });
  //}
  //if ($("#uverseActivationDate") != null) {
  //  $("#uverseActivationDate").datepicker({
  //                                          showOtherMonths: true,
  //                                          selectOtherMonths: true
  //                                        });
  //}

  //if ($("#anticipatedProvisioningDate") != null) {
  //  $("#anticipatedProvisioningDate").datepicker({
  //                                                 showOtherMonths: true,
  //                                                 selectOtherMonths: true
  //                                               });
  //}

  //// DTV Installation
  //if ($("#dtvRequestedActivationDate") != null) {
  //  $("#dtvRequestedActivationDate").datepicker({
  //                                                showOtherMonths: true,
  //                                                selectOtherMonths: true
  //                                              });
  //}
  //if ($('#dtvRequestedActivationTime') != null) {
  //  $('#dtvRequestedActivationTime').timepicker({
  //                                                timeFormat: 'h:mm p',
  //                                                interval: 60,
  //                                                dynamic: false,
  //                                                dropdown: true,
  //                                                scrollbar: true
  //                                              });
  //}
  //if ($("#dtvActivationDate") != null) {
  //  $("#dtvActivationDate").datepicker({
  //                                       showOtherMonths: true,
  //                                       selectOtherMonths: true
  //                                     });
  //}

  // Wired Installation

  if ($('#access-state') != null) {
    initListGroup('access-states', document.getElementById('access-state'), document.getElementById('access-reason-code'));
    $('#access-state').trigger("change");
  }
  if ($('#dsl-state') != null) {
    initListGroup('dsl-states', document.getElementById('dsl-state'), document.getElementById('dsl-reason-code'));
    $('#dsl-state').trigger("change");
  }
  if ($('#wireless-state') != null) {
    initListGroup('wireless-states', document.getElementById('wireless-state'), document.getElementById('wireless-reason-code'));
    $('#wireless-state').trigger("change");
  }
  if ($('#directv-state') != null) {
    initListGroup('directv-states', document.getElementById('directv-state'), document.getElementById('directv-reason-code'));
    $('#directv-state').trigger("change");
  }
  if ($('#iptv-state') != null) {
    initListGroup('iptv-states', document.getElementById('iptv-state'), document.getElementById('iptv-reason-code'));
    $('#iptv-state').trigger("change");
  }
  if ($('#internet-state') != null) {
    initListGroup('internet-states', document.getElementById('internet-state'), document.getElementById('internet-reason-code'));
    $('#internet-state').trigger("change");
  }
  if ($('#voip-state') != null) {
    initListGroup('voip-states', document.getElementById('voip-state'), document.getElementById('voip-reason-code'));
    $('#voip-state').trigger("change");
    //$("#voipLine1ReservedTn").mask("999-999-9999");
    //$("#voipLine2ReservedTn").mask("999-999-9999");
  }
  if ($('#digitallife-state') != null) {
    initListGroup('digitallife-states', document.getElementById('digitallife-state'), document.getElementById('digitallife-reason-code'));
    $('#digitallife-state').trigger("change");
  }

  $('input[type=text]').each(function () {
    $(this).data('initial_value', $(this).val());
  });

  <!-- This is to set the redirect url to redirect to same landing page -->
  setRedirectUrlParameter();

  <!-- This is to display product state/reason code in instalation date view -->
  showStateReasonCodeInInsDateSec('-state', '-reason-code');
  <!-- This is to display warning if Actual instalation dates are different -->
  showWarningForDiffInsDate();
});

function stateChanged(val, id) {
  $('#' + id).hide();
  if (val.value === '25' || val.value === '26' || val.value === '27' || val.value === '28' || val.value === '29' || val.value === '30' || val.value === '31' || val.value === '32' || val.value === '35') {
    $('#' + id).show();
  }

  var productStateIds = ['access-state', 'dsl-state', 'iptv-state', 'directv-state', 'internet-state', 'voip-state', 'digitallife-state'];
  var isIncomplete = false;
  var isSubmitted = false;
  $(productStateIds).each(function (i, val) {
    if (/(31|32)/.test($('#' + val).val())) {
      isIncomplete = true;
    }
    if (/(27|29|33)/.test($('#' + val).val())) {
      isSubmitted = true;
    }
  });

  if (isIncomplete === true) {
    $('#anticipateDate').css('display', '');
  } else {
    $('#anticipateDate').css('display', 'none');
  }

  if (isSubmitted === true) {
    // Fiber
    if ((/(27|29|33)/.test($('#internet-state').val()) || /(27|29|33)/.test($('#iptv-state').val()) || /(27|29|33)/.test($('#voip-state').val()))) {
      $("#uverseActivationDate").removeAttr('disabled');
      $("#uverseActivationTime").removeAttr('disabled');
      $("#omsOrderId").removeAttr('disabled');
    } else {
      $("#uverseActivationDate").attr("disabled", true);
      $("#uverseActivationTime").attr("disabled", true);
      $("#omsOrderId").attr("disabled", true);
    }

    // DTV
    if ((/(27|29|33)/.test($('#directv-state').val()))) {
      $("#dtvActivationDate").removeAttr('disabled');
      $("#dtvActivationTime").removeAttr('disabled');
    } else {
      $("#dtvActivationDate").attr("disabled", true);
      $("#dtvActivationTime").attr("disabled", true);
    }


    // DSL
    if ((/(27|29|33)/.test($('#dsl-state').val()))) {
      enableFieldByIds(['dslOrderNum', 'dslTrackingNumber', 'dslTnOrFtn', 'dslActivationDate']);
    } else {
      disableFieldByIds(['dslOrderNum', 'dslTrackingNumber', 'dslTnOrFtn', 'dslActivationDate']);
    }

    // ACCESS
    if ((/(27|29|33)/.test($('#access-state').val()))) {
      $("div[id^='toggle_access_line_']").each(function (index, obj) {
        enableFieldByIds(['accessLine' + (index + 1) + 'OrderNum', 'accessLine' + (index + 1) + 'TelephoneNum', 'accessLine' + (index + 1) + 'ActivationDate']);
      });
    } else {
      $("div[id^='toggle_access_line_']").each(function (index, obj) {
        disableFieldByIds(['accessLine' + (index + 1) + 'OrderNum', 'accessLine' + (index + 1) + 'TelephoneNum', 'accessLine' + (index + 1) + 'ActivationDate']);
      });
    }
  } else {
    $("#uverseActivationDate").attr("disabled", true);
    $("#dtvActivationDate").attr("disabled", true);
    $("#uverseActivationTime").attr("disabled", true);
    $("#dtvActivationTime").attr("disabled", true);
    $("#omsOrderId").attr("disabled", true);
    disableFieldByIds(['dslOrderNum', 'dslTrackingNumber', 'dslTnOrFtn', 'dslActivationDate']);
    $("div[id^='toggle_access_line_']").each(function (index, obj) {
      disableFieldByIds(['accessLine' + (index + 1) + 'OrderNum', 'accessLine' + (index + 1) + 'TelephoneNum', 'accessLine' + (index + 1) + 'ActivationDate']);
    });
  }

  //VOIP Lines
  if ($('#voipLine1ReservedTn') != null) {
    if (/(29|30|33)/.test(val.value)) {
      $('#voipLine1ReservedTn').removeAttr('disabled');
      $('#voipLine2ReservedTn').removeAttr('disabled');
    } else {
      $('#voipLine1ReservedTn').attr("disabled", true);
      $('#voipLine2ReservedTn').attr("disabled", true);
    }
  }
}

function enableFieldByIds(ids) {
  $(ids).each(function (i, val) {
    $('#' + val).removeAttr('disabled');
  });
}

function disableFieldByIds(ids) {
  $(ids).each(function (i, val) {
    $('#' + val).attr('disabled', true);
  });
}

function surveyBrNumber(templateId) {
  if (templateId != null && templateId.match('^bulk-email-survey_')) {
    var brId = templateId.substr(templateId.indexOf('_') + 1);
    return brId.substr(0, brId.indexOf('_'));
  }
  return 'N/A';
}

function openEmail(transactionId, templateId, templateXsl, emailTs) {
  window.open('./view_customer_email?transactionId=' + transactionId + '&templateId=' + templateId + '&templateXsl=' + templateXsl, '_blank', 'height=600,width=800,location=no,menubar=no,status=no,toolbar=no,scrollbars=yes', false);
}

function openUSCS(transactionId) {
  loadRepComments();
  loadSystemNotes();
  window.open('./createUSCS?transactionId=' + transactionId);
}

function addSecondVoipLine(btn) {
  $("#voip_line_2").show();
  btn.value = 'Delete Second VOIP Line';
  btn.setAttribute("onclick", "deleteSecondVoipLine(this)");
  $('#secondVoipLine').val('Add Second VOIP Line');
}

function deleteSecondVoipLine(btn) {
  if (confirm("Are you sure you want to delete?")) {
    $("#voip_line_2").hide();
    btn.value = 'Add Second VOIP Line';
    btn.setAttribute("onclick", "addSecondVoipLine(this)");
    $('#secondVoipLine').val('Delete Second VOIP Line');
  }
}

var unmasked = false;

function viewMaskedData(transactionId, userId) {
  if (unmasked) {
    return;
  }

  var encryptedFields = getEncryptedFields();
  EncryptionFacade.decryptValues(transactionId, userId, encryptedFields, {
    callback: function (data) {
      for (var i = 0; i < data.length; i++) {
        var arr = data[i];
        var field = arr[0];
        var val = arr[1];

        // because the id field might not be unique
        var spans = document.getElementsByTagName('SPAN');
        for (var j = 0; j < spans.length; j++) {
          if (spans[j].id === field) {
            dwr.util.setValue(spans[j], val);
          }
        }
      }
      unmasked = true;
    }
  });
}

function resendEmail(emailTo, transId, userId) {
  EmailFacade.resendEmail(emailTo, transId, userId, {
    callback: function (data) {
      if (data === 'true') {
        alert("Email Successfully Sent to " + emailTo);
      } else {
        alert("Email Failed!  Please update the Account tab with an Alternate Email Address.");
      }
    }
  });
}

function resendSms(transId) {
  SmsFacade.resendLastSmS(transId, {
    callback: function (data) {
      if (data === true) {
        alert("Last SMS sent.");
      } else {
        alert("SMS Failed!");
      }
    }
  });
}

function createEscalation(transactionId, externalOrderNumber) {
  var params = "orderNum=" + externalOrderNumber;
  $.ajax({
           url: "checkOpenEscalation", data: params
         }).done(function (html) {
    var htmldata = $(html);
    esclVal = $(htmldata).filter('div#esclId').html();
    if (esclVal != "EscalationId") {
      var result = confirm("Escalation " + esclVal + " is already open for " + externalOrderNumber + ", press OK to be taken to the open escalation.");
      if (result === true) {
        document.location.href = "/escalation/client/viewEscalation?transId=" + esclVal;
      }
    } else {
      document.location.href = "/escalation/client/createEscalation?transactionId=" + transactionId;
    }
  });
}

function updateAndStartCallTracker(transactionId) {
  document.getElementById('returnUrl').value = 'calltracker';
}

function getSpecialProjectAction(specialProjectId, id) {
  $("#specialprojectaction_" + id).find('option').remove();
  $("#specialprojectaction_" + id).append('<option value="Select">Select</option>');
  if (specialProjectId.value != '') {
    SpecialProjectAction.processSpecialProjectAction(specialProjectId.value, {
      callback: function (data) {
        setDropDownSpecialProjectAction(data, id);
      }
    });
  }
}

function orderlevelDropdown() {
  var x = document.getElementById("specialprojectTable").rows.length;
  if (x < 19) {
    var table = document.getElementById("specialprojectTable");
    thRow = table.appendChild(document.createElement("tr"));

    var select = document.createElement("select");
    var newOption = document.createElement("option");

    select.setAttribute("id", "specialProjecttype_" + x);
    select.setAttribute("name", "specialprojecttype");
    select.setAttribute("onchange", "getSpecialProjectAction(this," + x + ")");
    select.setAttribute("class", "form-control");

    var select1 = document.createElement("select");
    select1.setAttribute("id", "specialprojectaction_" + x);
    select1.setAttribute("name", "specialprojectaction");
    select1.setAttribute("class", "form-control");

    var input = document.createElement("input");
    input.setAttribute("type", "hidden");
    input.setAttribute("value", "NEW");
    input.setAttribute("name", "specialProjectOrderState");

    thRow.appendChild(document.createElement("td")).appendChild(select);
    thRow.appendChild(input);
    thRow.appendChild(document.createElement("td")).appendChild(select1);
    thRow.appendChild(document.createElement("td"));

    var type = jQuery("#specialProjecttype").html();
    var action = jQuery("#specialprojectaction").html();

    jQuery("#specialProjecttype_" + x).html(type);
    jQuery("#specialprojectaction_" + x).html(action);
  } else {
    alert('Only 18 Special Projects can be added.');
  }
}

function setDropDownSpecialProjectAction(data, id) {
  var select = document.getElementById("specialprojectaction_" + id);
  var count = $(data).find('ImplSpecialProjectActionBean').size();

  if (count > 0) {
    $(data).find('ImplSpecialProjectActionBean').each(function () {
      var ProjectActionDesc = $(this).find('ProjectActionDesc').text();
      var ProjectActionId = $(this).find('ProjectActionId').text();
      var softDelete = $(this).find('SoftDelete').text();

      if (softDelete != 'Deleted') {
        var newOption = document.createElement("option");
        newOption.setAttribute("value", ProjectActionId);
        newOption.innerHTML = ProjectActionDesc;
        select.appendChild(newOption);
      }
    });
  } else if (count === 0) {
    if (window.DOMParser) {
      parser = new DOMParser();
      xmlDoc = parser.parseFromString(data, "text/xml");
    } else { // Internet Explorer
      xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
      xmlDoc.async = false;
      xmlDoc.loadXML(data);
    }

    if (xmlDoc.getElementsByTagName("client").length === 0 && xmlDoc.getElementsByTagName("ProjectActionDesc").length > 0) {
      var ProjectActionDesc = xmlDoc.getElementsByTagName("ProjectActionDesc")[0].childNodes[0].nodeValue;
      var ProjectActionId = xmlDoc.getElementsByTagName("ProjectActionId")[0].childNodes[0].nodeValue;
      var newOption = document.createElement("option");
      newOption.setAttribute("value", ProjectActionId);
      newOption.innerHTML = ProjectActionDesc;
      select.appendChild(newOption);
    }
  }
}

// enable fields
function editOrder() {

  var productStateIds = ['access-state', 'dsl-state', 'iptv-state', 'directv-state', 'internet-state', 'voip-state', 'digitallife-state'];
  var isInvalid = false;

  $(productStateIds).each(function (i, val) {
    if (/(25|26|28|30|31|32|34)/.test($('#' + val).val())) {
      isInvalid = true;
    }
    ;
  });

  $('.editable').each(function (i, obj) {
    obj.removeAttribute('disabled');

    if (isInvalid) {
      $("#uverseActivationDate").attr("disabled", true);
      $("#dtvActivationDate").attr("disabled", true);
      $("#uverseActivationTime").attr("disabled", true);
      $("#dtvActivationTime").attr("disabled", true);
    }

  });

  displayFields();
}

// display the fields
function displayFields()
{
  $('.showFields').css('display', '');
  $('.displayLabel').css('display', 'none');
  $('.edit-field').css('display', '');
  $('.edit-field').attr('disabled', false);
  $('#preferredContactMethod').attr('disabled', false);
  $('#contactMethodImpl').attr('disabled', false);
  // Allow edit for Service Struct/Level/Apt
  $('#structLevelApt').css('display', 'none');
  $('#serviceStructureType').css('display', '');
  $('#serviceLevelType').css('display', '');
  $('#serviceApartmentType').css('display', '');
  $('#serviceStructureValue').css('display', '');
  $('#serviceLevelValue').css('display', '');
  $('#serviceApartmentValue').css('display', '');
  // Allow edit for Billing Struct/Level/Apt
  $('#billingStructLevelApt').css('display', 'none');
  $('#billingStructureType').css('display', '');
  $('#billingStructureValue').css('display', '');
  $('#billingLevelType').css('display', '');
  $('#billingLevelValue').css('display', '');
  $('#billingApartmentType').css('display', '');
  $('#billingApartmentValue').css('display', '');
  // Allow edit for Shipping Struct/Level/Apt
  $('#shippingStructLevelApt').css('display', 'none');
  $('#shippingStructureType').css('display', '');
  $('#shippingStructureValue').css('display', '');
  $('#shippingLevelType').css('display', '');
  $('#shippingLevelValue').css('display', '');
  $('#shippingApartmentType').css('display', '');
  $('#shippingApartmentValue').css('display', '');
  // Allow Billing address to edit only when Billing address is not same as Service Address
  var hiddenBillingAddress = document.getElementById("hiddenBillingAddress").value;
  var hiddenServiceAddress = document.getElementById("hiddenServiceAddress").value;
  var hiddenShippingAddress = document.getElementById("hiddenShippingAddress").value;
  if (!(hiddenBillingAddress == hiddenServiceAddress)) {
    $('.displayBillingLabel').css('display', 'none');
    $('.edit-billing-field').css('display', '');
    $('.edit-billing-field').attr('disabled', false);
  }
  if (hiddenShippingAddress != null && !(hiddenShippingAddress == hiddenServiceAddress || hiddenShippingAddress == hiddenBillingAddress)) {
    $('.displayShippingLabel').css('display', 'none');
    $('.edit-shipping-field').css('display', '');
    $('.edit-shipping-field').attr('disabled', false);
  }
  $("#allowedithidden").val(true);
}

function validateUpdate(form) {

  var anticipatedProvisioningDate;
  var uverseActivationDate;
  var dtvActivationDate;
  var dslActivationDate;
  var accessActivationDate;
  var billingAccountNumber;

  if (document.getElementById('billingAccountNumber') != null) {
    billingAccountNumber = document.getElementById('billingAccountNumber').value;
  }

  if (document.getElementById('anticipatedProvisioningDate') != null) {
    anticipatedProvisioningDate = document.getElementById('anticipatedProvisioningDate').value;
  }

  if (document.getElementById('uverseActivationDate') != null) {
    uverseActivationDate = document.getElementById('uverseActivationDate').value;
  }

  if (document.getElementById('dtvActivationDate') != null) {
    dtvActivationDate = document.getElementById('dtvActivationDate').value;
  }

  if (document.getElementById('dslActivationDate') != null) {
    dslActivationDate = document.getElementById('dslActivationDate').value;
  }

  var productStateIds = ['access-state', 'dsl-state', 'iptv-state', 'directv-state', 'internet-state', 'voip-state', 'digitallife-state'];
  var isIncomplete = false;
  var isSubmitted = false;
  $(productStateIds).each(function (i, val) {
    if ('31' === $('#' + val).val()) {
      isIncomplete = true;
    }
    ;
    if ('29' === $('#' + val).val()) {
      isSubmitted = true;
    }
    ;
  });

  /*If Any product state is submitted check the respective product ActivationDate
   --Awaiting Day of Install -->  Install date should not be l today or in the past
   --Awaiting Install 3 day -->  Install date should not be less than 4 days away
   --Awaiting Install 2 day -->  Install date should not be less than 3 days away
   --Awaiting Install 1 day -->  Install date should not be less than 2 days away */

  // IPTV
  if (isSubmitted && '29' === $('#iptv-state').val()) {
    var validDate = validateActivationDate(uverseActivationDate, $('#iptv-state').val(), $('#iptv-reason-code').val());
    var validBan = validateBan(billingAccountNumber);
    var validOms = validateOmsOrderId($('#omsOrderId').val());
    if (!(validDate && validBan && validOms)) {
      return false;
    }
  }

  // Internet
  if (isSubmitted && '29' === $('#internet-state').val()) {
    var validDate = validateActivationDate(uverseActivationDate, $('#internet-state').val(), $('#internet-reason-code').val());
    var validBan = validateBan(billingAccountNumber);
    var validOms = validateOmsOrderId($('#omsOrderId').val());
    if (!(validDate && validBan && validOms)) {
      return false;
    }
  }

  // Voip
  if (isSubmitted && '29' === $('#voip-state').val()) {
    var validDate = validateActivationDate(uverseActivationDate, $('#voip-state').val(), $('#voip-reason-code').val());
    var validBan = validateBan(billingAccountNumber);
    var validOms = validateOmsOrderId($('#omsOrderId').val());
    if (!(validDate && validBan && validOms)) {
      return false;
    }
  }

  // DTV
  if (isSubmitted && '29' === $('#directv-state').val()) {
    var validDate = validateActivationDate(dtvActivationDate, $('#directv-state').val(), $('#directv-reason-code').val());
    var validDtvAccountNum = validateDtvAccountNum($('#dtvAccountNumber').val());
    if (!(validDate && validDtvAccountNum)) {
      return false;
    }
  }

  // DSL
  if (isSubmitted && '29' === $('#dsl-state').val()) {
    var validDate = validateActivationDate(dslActivationDate, $('#dsl-state').val(), $('#dsl-reason-code').val());
    if (!validDate) {
      return false;
    }
  }

  // ACCESS
  if (isSubmitted && '29' === $('#access-state').val()) {
    var value = true;
    $("div[id^='toggle_access_line_']").each(function (index, obj) {
      if (document.getElementById('accessLine' + (index + 1) + 'ActivationDate') != null) {
        accessActivationDate = document.getElementById('accessLine' + (index + 1) + 'ActivationDate').value;
      }
      value = validateActivationDate(accessActivationDate, $('#access-state').val(), $('#access-reason-code').val());
    });
    if (!value) {
      return false;
    }
  }

  //BR2029
  if (document.getElementById('smsContactPhoneNumber') != null) {
    var phoneNumber = document.getElementById('smsContactPhoneNumber').value;
    if (typeof(phoneNumber) !== 'undefined' && phoneNumber.replace(/\s+$/, "").length > 0 && !validPhoneNumber(phoneNumber.replace(/\s+$/, ""))) {
      alert("You must provide a 10 digit Contact Phone Number");
      return false;
    }
  }

  //BR2029
  if (document.getElementById('contactSmsPhoneNumber') != null) {
    var phoneNumber = document.getElementById('contactSmsPhoneNumber').value;
    if (typeof(phoneNumber) !== 'undefined' && phoneNumber.replace(/\s+$/, "").length > 0 && !validPhoneNumber(phoneNumber.replace(/\s+$/, ""))) {
      alert("You must provide a 10 digit Contact Phone Number");
      return false;
    }
  }

  /* Reserved Telephone Number for VOIP validation. */
  if ($('#voip-state') !== null && /(29|33)/.test($('#voip-state').val())) {
    reservedTns = ['voipLine1ReservedTn'];
    var isValid = true;
    if ($('#voip_line_2').is(':visible')) {
      reservedTns.push('voipLine2ReservedTn');
    }
    $(reservedTns).each(function (i, val) {
      if ($('#' + val).val() === '') {
        isValid = false;
      }
    });
    if (!isValid) {
      alert('You must provide a Reserved Telephone Number before you can update this order.');
      return false;
    }
  }

  //If any product state is incomplete and Anticipated Provisioning Date is empty, prompt alert to user
  //else pass empty value for anticipatedProvisioningDate
  if (isIncomplete) {
    if (anticipatedProvisioningDate === null || anticipatedProvisioningDate.length === 0) {
      alert("Anticipated Provisioning Date should not be empty");
      return false;
    } else if (diffStartRequested(anticipatedProvisioningDate, isIncomplete) <= 0) {
      // Check anticipatedProvisioningDate should be greater than today
      alert("Anticipated Provisioning Date should be a future date");
      return false;
    }
  } else {
    $("#anticipatedProvisioningDate").val('');
  }

  //Don't include unchanged fields
  disableNotChangedFields();

  //documents
  $('#documentsTab').find("input:checkbox").each(function (i, val) {
    $(val).val($(val).prop('checked'));
  });

  /* BAN validation. */
  if (billingAccountNumber != null && billingAccountNumber.length > 0) {
    if (!/^\d{9}$/.test(billingAccountNumber)) {
      alert('The Billing Account Number must be 9 numeric characters.');
      return false;
    }
    if (!/^(?!.*(.)\1{6,})/.test(billingAccountNumber)) {
      alert('No more than 6 identical numerical values are allowed in the Billing Account Number field.');
      return false;
    }
  }

  if (document.getElementById('contactPrimaryPhone') != null) {
    var contact_PrimaryPhone = document.getElementById('contactPrimaryPhone').value.replace(/\s+$/, "");
    if (typeof(contact_PrimaryPhone) !== 'undefined' && contact_PrimaryPhone.length > 0) {
      if (!validPhoneNumber(contact_PrimaryPhone)) {
        alert("You must provide a 10 digit Primary Phone number");
        return false;
      }
    }
  }

  if (document.getElementById('contactWorkPhone') != null) {
    var contact_WorkPhone = document.getElementById('contactWorkPhone').value.replace(/\s+$/, "");
    if (typeof(contact_WorkPhone) !== 'undefined' && contact_WorkPhone.length > 0) {
      if (!validPhoneNumber(contact_WorkPhone)) {
        alert("You must provide a 10 digit Work Phone number");
        return false;
      }
    }
  }

  if (document.getElementById('contactAdditionalContactPhone') != null) {
    var contact_additionalContactPhone = document.getElementById('contactAdditionalContactPhone').value.replace(/\s+$/, "");
    if (typeof(contact_additionalContactPhone) !== 'undefined' && contact_additionalContactPhone.length > 0) {
      if (!validPhoneNumber(contact_additionalContactPhone)) {
        alert("You must provide a 10 digit Additional Contact Phone number");
        return false;
      }
    }
  }

  if (document.getElementById('contactAdditionalContactPhone2') != null) {
    var contact_additionalContactPhone2 = document.getElementById('contactAdditionalContactPhone2').value.replace(/\s+$/, "");
    if (typeof(contact_additionalContactPhone2) !== 'undefined' && contact_additionalContactPhone2.length > 0) {
      if (!validPhoneNumber(contact_additionalContactPhone2)) {
        alert("You must provide a 10 digit Additional Contact Phone2 number");
        return false;
      }
    }
  }

  if (document.getElementById('contactAdditionalContactPhone3') != null) {
    var contact_additionalContactPhone3 = document.getElementById('contactAdditionalContactPhone3').value.replace(/\s+$/, "");
    if (typeof(contact_additionalContactPhone3) !== 'undefined' && contact_additionalContactPhone3.length > 0) {
      if (!validPhoneNumber(contact_additionalContactPhone3)) {
        alert("You must provide a 10 digit Additional Contact Phone3 number");
        return false;
      }
    }
  }

  if (document.getElementById('contactPrimaryEmail') != null) {
    var contact_PrimaryEmail = document.getElementById('contactPrimaryEmail').value;
    if (typeof(contact_PrimaryEmail) !== 'undefined' && (contact_PrimaryEmail == null || contact_PrimaryEmail.length < 1)) {
      alert("You must provide a valid email address before you can update this order");
      return false;
    } else if (typeof(contact_PrimaryEmail) !== 'undefined' && contact_PrimaryEmail != null) {
      if (!validEmail(contact_PrimaryEmail)) {
        alert('You must provide a valid Email Address');
        return false;
      }
    }
  }

  if (document.getElementById('contactSecondaryEmail') != null) {
    var contact_SecondaryEmail = document.getElementById('contactSecondaryEmail').value;
    if (typeof(contact_SecondaryEmail) !== 'undefined' && contact_SecondaryEmail != null && contact_SecondaryEmail.length > 0) {
      if (!validEmail(contact_SecondaryEmail)) {
        alert('You must provide a valid Secondary Email Address');
        return false;
      }
    }
  }

  if (document.getElementById('contactInstallerEmail') != null) {
    var contact_InstallerEmail = document.getElementById('contactInstallerEmail').value;
    if (typeof(contact_InstallerEmail) !== 'undefined' && (contact_InstallerEmail != null && contact_InstallerEmail.length > 0)) {
      if (!validEmail(contact_InstallerEmail)) {
        alert('You must provide a valid Installer Email Address');
        return false;
      }
    }
  }

  // Business Info Validate
  if (document.getElementById('stateOfIncorporation') != null) {
    var stateOfIncorporation = document.getElementById('stateOfIncorporation').value;
    if (typeof(stateOfIncorporation) !== 'undefined' && (stateOfIncorporation != null && stateOfIncorporation.length > 2)) {
      alert("You must provide a valid State Of Incorporation before you can update this order");
      return false;
    }
  }

  if (document.getElementById('officer1PhoneNumber') != null) {
    var officer1PhoneNumber = document.getElementById('officer1PhoneNumber').value.replace(/\s+$/, "");
    if (typeof(officer1PhoneNumber) !== 'undefined' && officer1PhoneNumber.length > 0) {
      if (!validPhoneNumber(officer1PhoneNumber)) {
        alert("You must provide a 10 digit officer1 Phone number");
        return false;
      }
    }
  }

  if (document.getElementById('officer2PhoneNumber') != null) {
    var officer2PhoneNumber = document.getElementById('officer2PhoneNumber').value.replace(/\s+$/, "");
    if (typeof(officer2PhoneNumber) !== 'undefined' && officer2PhoneNumber.length > 0) {
      if (!validPhoneNumber(officer2PhoneNumber)) {
        alert("You must provide a 10 digit officer2 Phone number");
        return false;
      }
    }
  }

  if (document.getElementById('officer1EmailAddress') != null) {
    var officer1EmailAddress = document.getElementById('officer1EmailAddress').value;
    if (typeof(officer1EmailAddress) !== 'undefined' && (officer1EmailAddress != null && officer1EmailAddress.length > 0)) {
      if (!validEmail(officer1EmailAddress)) {
        alert('You must provide a valid officer1 Email Address');
        return false;
      }
    }
  }

  if (document.getElementById('officer2EmailAddress') != null) {
    var officer2EmailAddress = document.getElementById('officer2EmailAddress').value;
    if (typeof(officer2EmailAddress) !== 'undefined' && (officer2EmailAddress != null && officer2EmailAddress.length > 0)) {
      if (!validEmail(officer2EmailAddress)) {
        alert('You must provide a valid officer2 Email Address');
        return false;
      }
    }
  }

  // Validate Address Details
  var service_Address1 = document.getElementById('serviceAddress1') != null ? document.getElementById('serviceAddress1').value : null;
  var service_StreetName = document.getElementById('serviceStreetName') != null ? document.getElementById('serviceStreetName').value : null;
  var service_City = document.getElementById('City').value;
  var service_State = document.getElementById('State').value;
  var service_ZipCode = document.getElementById('Zip').value;

  // Billing State and Zip Code
  var billing_State = document.getElementById('billingState').value;
  var billing_ZipCode = document.getElementById('billingZipCode').value;
  if (!((service_Address1 != null && service_Address1.length > 0) || (service_StreetName != null && service_StreetName.length > 0))) {
    alert("You must provide a valid Service Address before you can update this order");
    return false;
  }

  if (service_City == null || service_City.length < 1) {
    alert("You must provide a valid Service City before you can update this order");
    return false;
  }

  if (service_State == null || service_State.length < 1) {
    alert("You must provide a valid Service State before you can update this order");
    return false;
  }
  if (service_State != null && service_State.length > 2) {
    alert("You must provide a valid Service State before you can update this order");
    return false;
  }

  if (service_ZipCode == null || service_ZipCode.length < 1) {
    alert('You must provide a valid Service ZipCode (Numbers) before you can update this order');
    return false;
  } else if (service_ZipCode != null) {
    var reg = /^([0-9]{5,10})$/;
    if (reg.test(service_ZipCode) == false) {
      alert('You must provide a valid Service ZipCode (Numbers) before you can update this order');
      return false;
    }
  }

  if (billing_State == null || billing_State.length < 1) {
    alert("You must provide a valid Billing State before you can update this order");
    return false;
  }
  if (billing_State != null && billing_State.length > 2) {
    alert("You must provide a valid Billing State before you can update this order");
    return false;
  }

  if (billing_ZipCode == null || billing_ZipCode.length < 1) {
    alert('You must provide a valid Billing ZipCode (Numbers) before you can update this order');
    return false;
  } else if (billing_ZipCode != null) {
    var reg = /^([0-9]{5,10})$/;
    if (reg.test(billing_ZipCode) == false) {
      alert('You must provide a valid Billing ZipCode (Numbers) before you can update this order');
      return false;
    }
  }

    //BR2380
    var outboundIndicator = document.getElementById('outboundIndicatorId');
    var returnsUrl = document.getElementById('returnUrl').value;
    if(outboundIndicator !=null && outboundIndicator.length > 0 && (returnsUrl =='OBC' || returnsUrl =='SP_OBC_RES' || returnsUrl =='OBC_BUS')){
        document.getElementById('returnUrl').value='OBC_BUS';
        var outboundIndicatorText = outboundIndicator.options[outboundIndicator.selectedIndex].text;
        if(outboundIndicatorText == 'Select'){
            alert("Please select an Outbound Indicator to update the order.");
            return false;
        }
    }

  return true;
}

function validateActivationDate(activationDate, stateCode, reasonCode) {
  var value = true;
  if (activationDate != null && activationDate.length != 0) {

    if ('29' === stateCode && '329' === reasonCode && diffStartRequested(activationDate, reasonCode) != 0) {
      alert("Install date is in the future - this sub-state cannot be selected");
      value = false;
    }

    if ('29' === stateCode && '328' === reasonCode && diffStartRequested(activationDate, reasonCode) != 1) {
      if ($('#excludeWeekends').val() === "TRUE") {
        alert("Install Date is not on the next business day - this sub-state cannot be selected");
      } else {
        alert("Install Date is not tomorrow - this sub-state cannot be selected");
      }
      value = false;
    }

    if ('29' === stateCode && '52' === reasonCode && diffStartRequested(activationDate, reasonCode) != 2) {
      if ($('#excludeWeekends').val() === "TRUE") {
        alert("Install Date is not 1 business day away from tomorrow - this sub-state cannot be selected");
      } else {
        alert("Install Date is not 1 days away from tomorrow - this sub-state cannot be selected");
      }
      value = false;
    }

    if ('29' === stateCode && '53' === reasonCode && diffStartRequested(activationDate, reasonCode) != 3) {
      if ($('#excludeWeekends').val() === "TRUE") {
        alert("Install Date is not 2 business days away from tomorrow - this sub-state cannot be selected");
      } else {
        alert("Install Date is not 2 days away from tomorrow - this sub-state cannot be selected");
      }
      value = false;
    }

    if ('29' === stateCode && '54' === reasonCode && diffStartRequested(activationDate, reasonCode) < 4) {
      if ($('#excludeWeekends').val() === "TRUE") {
        alert("Install Date is less than 3 business days away from tomorrow - this sub-state cannot be selected");
      } else {
        alert("Install Date is less than 3 days away from tomorrow - this sub-state cannot be selected");
      }
      value = false;
    }
  } else {
    alert("Activation Date should not be empty");
    value = false;
  }
  return value;
}

// find the difference between today and the requestedDate
function diffStartRequested(requestedDate, stateValue) {

  var oneDay = 1000 * 60 * 60 * 24;
  var excludeWeekends = $('#excludeWeekends').val();
  var current = $('#currentDate').val();

  var requestedDateArr = requestedDate.split("/");
  var startDateArr = current.split("/");
  var start = new Date(startDateArr[2], (startDateArr[0] - 1), startDateArr[1]);
  var requestedDateOnly = new Date(requestedDateArr[2], (requestedDateArr[0] - 1), requestedDateArr[1]);

  daysDiff = Math.ceil((requestedDateOnly.getTime() - start.getTime()) / (oneDay));

  var day = new Date(requestedDateOnly.getTime());
  var startDay = new Date(start.getTime());

  if (excludeWeekends === "TRUE" && day.getDay() === 6) {
    if (startDay.getDay() === 1) {
      daysDiff = 0;
    } else if (startDay.getDay() === 6) {
      daysDiff = 1;
    } else {
      daysDiff = Math.ceil((requestedDateOnly.getTime() - start.getTime()) / (oneDay));
    }
  } else {
    if (stateValue != true) {
      if (excludeWeekends === "TRUE" && daysDiff > 0 && '329' != stateValue) {
        for (var i = start.getTime(), lst = requestedDateOnly.getTime(); i <= lst; i += oneDay) {
          var d = new Date(i);
          if (d.getDay() == 6 || d.getDay() == 0) {
            daysDiff--;
          }
        }
      }
    }
  }

  return daysDiff;
}

function disableNotChangedFields() {
  var fieldIds = [
    'uverseRequestedActivationDate', 'uverseRequestedActivationTime', 'uverseActivationDate', 'uverseActivationTime', 'dtvRequestedActivationDate', 'dtvRequestedActivationTime', 'dtvActivationDate', 'dtvActivationTime'
  ];

  //Check for flex fields
  $('#flex-field').find("input:text").each(function (i, val) {
    fieldIds.push($(val).attr('id'))
  });

  $(fieldIds).each(function (i, val) {
    if ($('#' + val) && $('#' + val).val() === $('#' + val).data('initial_value')) {
      $('#' + val).prop("disabled", true);
    }
  });
}

function validateOmsOrderId(omsOrderId) {
  var value = true;
  if (omsOrderId.length === 0) {
    alert("You must provide a Fiber OMS Order ID before you can update this order.");
    value = false;
  }
  return value;
}

function validateBan(billingAccountNumber) {
  var value = true;
  if (billingAccountNumber.length === 0) {
    alert("You must provide an Account Number before you can update this order.");
    value = false;
  }
  return value
}

function validateDtvAccountNum(dtvAccountNumber) {
  var value = true;
  if (dtvAccountNumber.length === 0 && '29' === $('#directv-state').val()) {
    alert('DTV Account Number must be provided to set a DirecTV product to Submitted state.');
    value = false;
  } else if (dtvAccountNumber != null && dtvAccountNumber.length != 0) {
    if (!(/^\d{1,15}$/).test(dtvAccountNumber)) {
      alert('DTV Account Number must be between 1 to 15 numeric characters.');
      value = false;
    }
  }
  return value;
}

function validEmail(email) {
  var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,})$/;
  return reg.test(email);
}

function validPhoneNumber(number) {
  var reg = /^\d{10}$/;
  return reg.test(number);
}

<!-- function used for BR 567 -->
function setRedirectUrlParameter() {
  var path = window.location.search;
  var querystring = path.split('&');
  var returnUrlParamValue;

  // loop through each name-value pair and populate object
  for (var i = 0; i < querystring.length; i++) {

    // get name and value
    var name = querystring[i].split('=')[0];
    var value = querystring[i].split('=')[1];

    if (name == 'returnUrl') {
      returnUrlParamValue = value;
      var returnUrlParam = document.getElementById('returnUrl');
      returnUrlParam.value = returnUrlParamValue;
      break;
    }
  }

}
