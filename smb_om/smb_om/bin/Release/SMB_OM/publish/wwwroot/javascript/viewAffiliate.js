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
var values;
var keys;
function loadAffiliateDataAjax(affiliateName) {
  setTimeout(function(){
    ViewAffiliateFacade.getAffiliateDetails(affiliateName, { callback: function (data) {
      values = Object.keys(data).map(function(item) {return data[item];});
      keys = Object.keys(data);
      //affiliate name
      document.getElementById('affiliate_Name').innerHTML = "Affiliate : " + affiliateName;
      //CSI username
      retriveValuesFromAjaxCall(affiliateName + ".USER_NAME", 'view-csiUserName');
      //salesCodes
      retriveValuesFromAjaxCall('WEST', 'view-salesCodeWest');
      retriveValuesFromAjaxCall('MIDWEST', 'view-salesCodeMidWest');
      retriveValuesFromAjaxCall('EAST', 'view-salesCodeEast');
      retriveValuesFromAjaxCall('SOUTHWEST', 'view-salesCodeSouthwest');
      retriveValuesFromAjaxCall('SOUTHEAST', 'view-salesCodeSoutheast');
      retriveValuesFromAjaxCall('WIRELESS', 'view-salesCodeWireless');
      //automation calls
      retriveBooleanValuesFromAjaxCall('EXISTING_CUSTOMER', 'view-ExistingCustomer');
      retriveBooleanValuesFromAjaxCall('SERVICE_QUAL', 'view-sq');
      retriveBooleanValuesFromAjaxCall('CREDIT_CHECK', 'view-cc');
      retriveBooleanValuesFromAjaxCall('ORDER_QUAL', 'view-oq');
      retriveBooleanValuesFromAjaxCall('VALIDATE', 'view-validate');
      retriveBooleanValuesFromAjaxCall('CREATE', 'view-create');
      retriveBooleanValuesFromAjaxCall('ORDERWIRED', 'view-wiredOrder');
      retriveBooleanValuesFromAjaxCall('ORDERUVERSE', 'view-uverseOrder');
      retriveBooleanValuesFromAjaxCall('ORDERWIRELESS', 'view-wirelessOrder');
      retriveBooleanValuesFromAjaxCall('CUCADP', 'view-cucadpOrder');
      retriveBooleanValuesFromAjaxCall('AUTOMATE_CREDIT_RISK', 'view-automatedCreditRiskOrder');
      //OSN
      retriveBooleanValuesFromAjaxCall(affiliateName + ".9", 'view-osn.canceled');
      retriveBooleanValuesFromAjaxCall(affiliateName + ".17", 'view-osn.cancelled_nrfc');
      retriveBooleanValuesFromAjaxCall(affiliateName + ".8", 'view-osn.complete');
      retriveBooleanValuesFromAjaxCall(affiliateName + ".7", 'view-osn.incomplete');
      retriveBooleanValuesFromAjaxCall(affiliateName + ".1106", 'view-osn.resend');
      retriveBooleanValuesFromAjaxCall(affiliateName + ".10", 'view-osn.pending');
      retriveBooleanValuesFromAjaxCall(affiliateName + ".20", 'view-osn.submitted');
      retriveBooleanValuesFromAjaxCall(affiliateName + ".24", 'view-osn.order_confirmation');
      retriveBooleanValuesFromAjaxCall(affiliateName + ".1107", 'view-osn.fraud_check');
      retriveBooleanValuesFromAjaxCall(affiliateName + ".11020", 'view-osn.agent_note_generated');
      //IUCSP config
      retriveValuesFromAjaxCall(affiliateName + "UVERSE_IUCSP_1STRUN_START", 'viewUVERSEIUCSP1StrunStart');
      retriveValuesFromAjaxCall(affiliateName + "WIRED_IUCSP_1STRUN_START", 'viewWIREDIUCSP1StrunStart');
      retriveSwitchValuesFromAjaxCall(affiliateName + "UVERSE_IUCSP_OSN_ACCT_STATUS", 'viewUVERSEIUCSPOSNAccountStatus');
      retriveSwitchValuesFromAjaxCall(affiliateName + "WIRED_IUCSP_OSN_ACCT_STATUS", 'viewWIREDIUCSPOSNAccountStatus');
      retriveValuesFromAjaxCall(affiliateName + "UVERSE_IUCSP_START", 'viewUVERSEIUCSPStart');
      retriveValuesFromAjaxCall(affiliateName + "WIRED_IUCSP_START", 'viewWIREDIUCSPStrat');
      retriveValuesFromAjaxCall(affiliateName + "UVERSE_IUCSP_NEXTRUN_END", 'viewUVERSEIUCSPNextrunEnd');
      retriveValuesFromAjaxCall(affiliateName + "WIRED_IUCSP_NEXTRUN_END", 'viewWIREDIUCSPNextrunEnd');
      retriveValuesFromAjaxCall(affiliateName + "UVERSE_IUCSP_RUNS", 'viewUVERSEIUCSPRuns');
      retriveValuesFromAjaxCall(affiliateName + "WIRED_IUCSP_RUNS", 'viewWIREDIUCSPRuns');
      retriveValuesFromAjaxCall(affiliateName + "UVERSE_IUCSP_NEXTRUN_START", 'viewUVERSEIUCSPNextrunStart');
      retriveValuesFromAjaxCall(affiliateName + "WIRED_IUCSP_NEXTRUN_START", 'viewWIREDIUCSPNextrunStart');
      retriveValuesFromAjaxCall(affiliateName + "UVERSE_IUCSP_1STRUN_END", 'viewUVERSEIUCSP1StrunEnd');
      retriveValuesFromAjaxCall(affiliateName + "WIRED_IUCSP_1STRUN_END", 'viewWIREDIUCSP1StrunEnd');
      retriveValuesFromAjaxCall(affiliateName + "AFFILIATE_PARTNER", 'view-affiliatePartnerName');
      retriveValuesFromAjaxCall(affiliateName + ".GW", 'view-smbcGatewayUrl');
      retriveValuesFromAjaxCall(affiliateName + ".WLP", 'view-smbcPortalUrl');

      retriveSwitchValuesFromAjaxCall(affiliateName + "IUCSP_BATCH_PROCESS", 'viewIucspBatchProcess');
      //cvv congig
      retriveSwitchValuesFromAjaxCall('AFFILIATE_CVV_VALIDATE', 'view-cvvValidate');
      retriveSwitchValuesFromAjaxCall('AFFILIATE_VALIDATE_TO_ORDER', 'view-validateToOrder');
      //SMBC
      retriveValuesFromAjaxCall('SMBC_AFFILIATES', 'view-smbcAffiliate');
      retriveValuesFromAjaxCall('SMB_AFFILIATES', 'view-smbAffiliate');
      //NCVC
      retriveSwitchValuesFromAjaxCall('AFFILIATE_NCVC_CREDITCUST', 'view-ncvc');

      document.getElementById('view-smbcGatewayUrl').href = document.getElementById('view-smbcGatewayUrl').innerHTML;
      document.getElementById('view-smbcPortalUrl').href = document.getElementById('view-smbcPortalUrl').innerHTML.replace(/&amp;/g, "&");

    }
    });
  }, 1000);
}

function getGatewayUrl() {
  var isSmbc = document.getElementById('smbcAffiliate').checked;
  ViewAffiliateFacade.getGatewayUrl(isSmbc, {
    callback: function (data) {
      document.getElementById('affiliateGatewayUrl').innerHTML = data;
      document.getElementById('affiliateGatewayUrl').href = data;
      document.getElementById('affiliateGWUrl').value = data;
    }
  });

}

function getPortalUrl() {
  var isSmbc = document.getElementById('smbcAffiliate').checked;
  var partner = document.getElementById('affiliate_partner').value;
  var affiliate = document.getElementById('affiliateName').value;
  ViewAffiliateFacade.getPortalUrl(isSmbc, partner, affiliate, {
    callback: function (data) {
      document.getElementById('affiliatePortalUrl').innerHTML = data;
      document.getElementById('affiliatePortalUrl').href = data;
      document.getElementById('affiliateWLPUrl').value = data;
    }
  });

}

function retriveValuesFromAjaxCall(keyFromAjax, labelId) {
  if ((keys.indexOf(keyFromAjax) != -1) && (values[keys.indexOf(keyFromAjax)] != null || values[keys.indexOf(keyFromAjax)] != "")) {
    document.getElementById(labelId).innerHTML = values[keys.indexOf(keyFromAjax)];
  } else {
    document.getElementById(labelId).innerHTML = "-";
  }
}

function retriveBooleanValuesFromAjaxCall(keyFromAjax, labelId) {
  if ((keys.indexOf(keyFromAjax) != -1) && (values[keys.indexOf(keyFromAjax)] != null || values[keys.indexOf(keyFromAjax)] != "")) {
    document.getElementById(labelId).innerHTML = values[keys.indexOf(keyFromAjax)];
  } else {
    document.getElementById(labelId).innerHTML = "false";
  }
}

function retriveSwitchValuesFromAjaxCall(keyFromAjax, labelId) {
  if ((keys.indexOf(keyFromAjax) != -1) && (values[keys.indexOf(keyFromAjax)] != null || values[keys.indexOf(keyFromAjax)] != "")) {
    document.getElementById(labelId).innerHTML = values[keys.indexOf(keyFromAjax)];
  } else {
    document.getElementById(labelId).innerHTML = "OFF";
  }
}