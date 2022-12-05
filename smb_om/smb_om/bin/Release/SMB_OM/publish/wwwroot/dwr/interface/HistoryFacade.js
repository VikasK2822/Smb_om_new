if (typeof dwr == 'undefined' || dwr.engine == undefined) throw new Error('You must include DWR engine before including this file');

(function() {
var c;
var addedNow = [];

if (!dwr.engine._mappedClasses["ImplReasonCodeLkupBean"]) {
c = function() {
this.reasonCodeName = null;
this.sslpStateId = null;
this.commaSeparatedCategories = null;
this.reasonCode = null;
this.sslpCategoryId = null;
}
c.$dwrClassName = 'ImplReasonCodeLkupBean';
c.$dwrClassMembers = {};
c.$dwrClassMembers.reasonCodeName = {};
c.$dwrClassMembers.sslpStateId = {};
c.$dwrClassMembers.commaSeparatedCategories = {};
c.$dwrClassMembers.reasonCode = {};
c.$dwrClassMembers.sslpCategoryId = {};
c.createFromMap = dwr.engine._createFromMap;
dwr.engine._setObject("ImplReasonCodeLkupBean", c);
dwr.engine._mappedClasses["ImplReasonCodeLkupBean"] = c;
addedNow["ImplReasonCodeLkupBean"] = true;
}

if (!dwr.engine._mappedClasses["ImplStateLkupBean"]) {
c = function() {
this.stateName = null;
this.stateId = null;
this.sclpCategoryId = null;
}
c.$dwrClassName = 'ImplStateLkupBean';
c.$dwrClassMembers = {};
c.$dwrClassMembers.stateName = {};
c.$dwrClassMembers.stateId = {};
c.$dwrClassMembers.sclpCategoryId = {};
c.createFromMap = dwr.engine._createFromMap;
dwr.engine._setObject("ImplStateLkupBean", c);
dwr.engine._mappedClasses["ImplStateLkupBean"] = c;
addedNow["ImplStateLkupBean"] = true;
}

if (!dwr.engine._mappedClasses["ImplWirelessCatalogInfo"]) {
c = function() {
this.infoText = null;
this.infoName = null;
this.endDate = null;
this.infoApplicableSku = null;
this.active = null;
this.imeiType = null;
this.createdTs = null;
this.lastModifiedTs = null;
this.infoType = null;
this.ctlgWrlsInfoId = null;
this.imeiSubCategory = null;
this.affiliate = null;
this.agentSuggestedVerbiage = null;
this.infoApplicableType = null;
this.startDate = null;
}
c.$dwrClassName = 'ImplWirelessCatalogInfo';
c.$dwrClassMembers = {};
c.$dwrClassMembers.infoText = {};
c.$dwrClassMembers.infoName = {};
c.$dwrClassMembers.endDate = {};
c.$dwrClassMembers.infoApplicableSku = {};
c.$dwrClassMembers.active = {};
c.$dwrClassMembers.imeiType = {};
c.$dwrClassMembers.createdTs = {};
c.$dwrClassMembers.lastModifiedTs = {};
c.$dwrClassMembers.infoType = {};
c.$dwrClassMembers.ctlgWrlsInfoId = {};
c.$dwrClassMembers.imeiSubCategory = {};
c.$dwrClassMembers.affiliate = {};
c.$dwrClassMembers.agentSuggestedVerbiage = {};
c.$dwrClassMembers.infoApplicableType = {};
c.$dwrClassMembers.startDate = {};
c.createFromMap = dwr.engine._createFromMap;
dwr.engine._setObject("ImplWirelessCatalogInfo", c);
dwr.engine._mappedClasses["ImplWirelessCatalogInfo"] = c;
addedNow["ImplWirelessCatalogInfo"] = true;
}

if (!dwr.engine._mappedClasses["ImplSFGCustomReportName"]) {
c = function() {
this.reportId = null;
this.reportName = null;
this.createdTs = null;
}
c.$dwrClassName = 'ImplSFGCustomReportName';
c.$dwrClassMembers = {};
c.$dwrClassMembers.reportId = {};
c.$dwrClassMembers.reportName = {};
c.$dwrClassMembers.createdTs = {};
c.createFromMap = dwr.engine._createFromMap;
dwr.engine._setObject("ImplSFGCustomReportName", c);
dwr.engine._mappedClasses["ImplSFGCustomReportName"] = c;
addedNow["ImplSFGCustomReportName"] = true;
}

if (!dwr.engine._mappedClasses["ImplFinalStateMaskLkupBean"]) {
c = function() {
this.orderType = null;
this.previousStateMask = null;
this.devComments = null;
this.seqNum = null;
this.category = null;
this.subcatsToCascade = null;
this.currentStateMask = null;
this.orderState = null;
}
c.$dwrClassName = 'ImplFinalStateMaskLkupBean';
c.$dwrClassMembers = {};
c.$dwrClassMembers.orderType = {};
c.$dwrClassMembers.previousStateMask = {};
c.$dwrClassMembers.devComments = {};
c.$dwrClassMembers.seqNum = {};
c.$dwrClassMembers.category = {};
c.$dwrClassMembers.subcatsToCascade = {};
c.$dwrClassMembers.currentStateMask = {};
c.$dwrClassMembers.orderState = {};
c.createFromMap = dwr.engine._createFromMap;
dwr.engine._setObject("ImplFinalStateMaskLkupBean", c);
dwr.engine._mappedClasses["ImplFinalStateMaskLkupBean"] = c;
addedNow["ImplFinalStateMaskLkupBean"] = true;
}

if (!dwr.engine._mappedClasses["EmailLogBean"]) {
c = function() {
this.emailBccAddr = null;
this.emailBlob = [];
this.emailXml = null;
this.emailTs = null;
this.errorMessage = null;
this.dispTransactionId = null;
this.emailFromAddr = null;
this.templateId = null;
this.emailSubject = null;
this.templateXsl = null;
this.transactionId = null;
this.emailToAddr = null;
this.emailCcAddr = null;
this.status = null;
}
c.$dwrClassName = 'EmailLogBean';
c.$dwrClassMembers = {};
c.$dwrClassMembers.emailBccAddr = {};
c.$dwrClassMembers.emailBlob = {};
c.$dwrClassMembers.emailXml = {};
c.$dwrClassMembers.emailTs = {};
c.$dwrClassMembers.errorMessage = {};
c.$dwrClassMembers.dispTransactionId = {};
c.$dwrClassMembers.emailFromAddr = {};
c.$dwrClassMembers.templateId = {};
c.$dwrClassMembers.emailSubject = {};
c.$dwrClassMembers.templateXsl = {};
c.$dwrClassMembers.transactionId = {};
c.$dwrClassMembers.emailToAddr = {};
c.$dwrClassMembers.emailCcAddr = {};
c.$dwrClassMembers.status = {};
c.createFromMap = dwr.engine._createFromMap;
dwr.engine._setObject("EmailLogBean", c);
dwr.engine._mappedClasses["EmailLogBean"] = c;
addedNow["EmailLogBean"] = true;
}

if (!dwr.engine._mappedClasses["ImplCtRequest"]) {
c = function() {
this.nspLid = null;
this.nspId = null;
this.orderNumber = null;
this.callEndTime = null;
this.createUserGuid = null;
this.callerLastName = null;
this.displayStatus = null;
this.callType = null;
this.nspName = null;
this.emailAddress = null;
this.requestNumber = null;
this.requestComment = null;
this.callerContactTn = null;
this.flexField9 = null;
this.callReasonLid = null;
this.flexField7 = null;
this.flexField8 = null;
this.callTrackerKey = null;
this.flexField5 = null;
this.flexField6 = null;
this.flexField3 = null;
this.callReason = null;
this.flexField4 = null;
this.flexField1 = null;
this.flexField2 = null;
this.callIntervalSec = null;
this.callStartTime = null;
this.updateUserGuid = null;
this.flexField10 = null;
this.updateTime = null;
this.callDispositionLid = null;
this.accountNumber = null;
this.requestCreateTime = null;
this.statusLid = null;
this.callDisposition = null;
this.createTime = null;
this.createdByUserGuid = null;
this.requestCommentId = null;
this.callerFirstName = null;
this.lastActivityPage = null;
this.requestGuid = null;
this.status = null;
}
c.$dwrClassName = 'ImplCtRequest';
c.$dwrClassMembers = {};
c.$dwrClassMembers.nspLid = {};
c.$dwrClassMembers.nspId = {};
c.$dwrClassMembers.orderNumber = {};
c.$dwrClassMembers.callEndTime = {};
c.$dwrClassMembers.createUserGuid = {};
c.$dwrClassMembers.callerLastName = {};
c.$dwrClassMembers.displayStatus = {};
c.$dwrClassMembers.callType = {};
c.$dwrClassMembers.nspName = {};
c.$dwrClassMembers.emailAddress = {};
c.$dwrClassMembers.requestNumber = {};
c.$dwrClassMembers.requestComment = {};
c.$dwrClassMembers.callerContactTn = {};
c.$dwrClassMembers.flexField9 = {};
c.$dwrClassMembers.callReasonLid = {};
c.$dwrClassMembers.flexField7 = {};
c.$dwrClassMembers.flexField8 = {};
c.$dwrClassMembers.callTrackerKey = {};
c.$dwrClassMembers.flexField5 = {};
c.$dwrClassMembers.flexField6 = {};
c.$dwrClassMembers.flexField3 = {};
c.$dwrClassMembers.callReason = {};
c.$dwrClassMembers.flexField4 = {};
c.$dwrClassMembers.flexField1 = {};
c.$dwrClassMembers.flexField2 = {};
c.$dwrClassMembers.callIntervalSec = {};
c.$dwrClassMembers.callStartTime = {};
c.$dwrClassMembers.updateUserGuid = {};
c.$dwrClassMembers.flexField10 = {};
c.$dwrClassMembers.updateTime = {};
c.$dwrClassMembers.callDispositionLid = {};
c.$dwrClassMembers.accountNumber = {};
c.$dwrClassMembers.requestCreateTime = {};
c.$dwrClassMembers.statusLid = {};
c.$dwrClassMembers.callDisposition = {};
c.$dwrClassMembers.createTime = {};
c.$dwrClassMembers.createdByUserGuid = {};
c.$dwrClassMembers.requestCommentId = {};
c.$dwrClassMembers.callerFirstName = {};
c.$dwrClassMembers.lastActivityPage = {};
c.$dwrClassMembers.requestGuid = {};
c.$dwrClassMembers.status = {};
c.createFromMap = dwr.engine._createFromMap;
dwr.engine._setObject("ImplCtRequest", c);
dwr.engine._mappedClasses["ImplCtRequest"] = c;
addedNow["ImplCtRequest"] = true;
}

if (!dwr.engine._mappedClasses["ImplReasonCodeScenarioBean"]) {
c = function() {
this.softDelete = null;
this.secondLevelRc = null;
this.reasonCodeId = null;
this.createdTs = null;
this.thirdLevelRcName = null;
this.lastModifiedTs = null;
}
c.$dwrClassName = 'ImplReasonCodeScenarioBean';
c.$dwrClassMembers = {};
c.$dwrClassMembers.softDelete = {};
c.$dwrClassMembers.secondLevelRc = {};
c.$dwrClassMembers.reasonCodeId = {};
c.$dwrClassMembers.createdTs = {};
c.$dwrClassMembers.thirdLevelRcName = {};
c.$dwrClassMembers.lastModifiedTs = {};
c.createFromMap = dwr.engine._createFromMap;
dwr.engine._setObject("ImplReasonCodeScenarioBean", c);
dwr.engine._mappedClasses["ImplReasonCodeScenarioBean"] = c;
addedNow["ImplReasonCodeScenarioBean"] = true;
}

if (!dwr.engine._mappedClasses["ImplDispHistory"]) {
c = function() {
this.reasonCodeName = null;
this.transComment = null;
this.stateName = null;
this.stateId = null;
this.dispTransactionId = null;
this.userName = null;
this.categoryName = null;
this.categoryId = null;
this.transactionId = null;
this.timestamp = null;
}
c.$dwrClassName = 'ImplDispHistory';
c.$dwrClassMembers = {};
c.$dwrClassMembers.reasonCodeName = {};
c.$dwrClassMembers.transComment = {};
c.$dwrClassMembers.stateName = {};
c.$dwrClassMembers.stateId = {};
c.$dwrClassMembers.dispTransactionId = {};
c.$dwrClassMembers.userName = {};
c.$dwrClassMembers.categoryName = {};
c.$dwrClassMembers.categoryId = {};
c.$dwrClassMembers.transactionId = {};
c.$dwrClassMembers.timestamp = {};
c.createFromMap = dwr.engine._createFromMap;
dwr.engine._setObject("ImplDispHistory", c);
dwr.engine._mappedClasses["ImplDispHistory"] = c;
addedNow["ImplDispHistory"] = true;
}

if (!dwr.engine._mappedClasses["ImplOceAttributes"]) {
c = function() {
this.ocePricePlanCode = null;
this.attributeOperations = null;
this.quantity = null;
this.oceOnly = null;
this.childComponent = null;
this.userName = null;
this.characteristicId = null;
this.createdTs = null;
this.userId = null;
this.modifiedTs = null;
this.parentComponent = null;
this.attribute = null;
this.componentOperations = null;
this.productType = null;
}
c.$dwrClassName = 'ImplOceAttributes';
c.$dwrClassMembers = {};
c.$dwrClassMembers.ocePricePlanCode = {};
c.$dwrClassMembers.attributeOperations = {};
c.$dwrClassMembers.quantity = {};
c.$dwrClassMembers.oceOnly = {};
c.$dwrClassMembers.childComponent = {};
c.$dwrClassMembers.userName = {};
c.$dwrClassMembers.characteristicId = {};
c.$dwrClassMembers.createdTs = {};
c.$dwrClassMembers.userId = {};
c.$dwrClassMembers.modifiedTs = {};
c.$dwrClassMembers.parentComponent = {};
c.$dwrClassMembers.attribute = {};
c.$dwrClassMembers.componentOperations = {};
c.$dwrClassMembers.productType = {};
c.createFromMap = dwr.engine._createFromMap;
dwr.engine._setObject("ImplOceAttributes", c);
dwr.engine._mappedClasses["ImplOceAttributes"] = c;
addedNow["ImplOceAttributes"] = true;
}
})();

(function() {
if (dwr.engine._getObject("HistoryFacade") == undefined) {
var p;

p = {};





p.getDispHistory = function(p0, callback) {
return dwr.engine._execute(p._path, 'HistoryFacade', 'getDispHistory', arguments);
};





p.getRepComments = function(p0, callback) {
return dwr.engine._execute(p._path, 'HistoryFacade', 'getRepComments', arguments);
};





p.getEmailLogs = function(p0, callback) {
return dwr.engine._execute(p._path, 'HistoryFacade', 'getEmailLogs', arguments);
};





p.getCallHistory = function(p0, callback) {
return dwr.engine._execute(p._path, 'HistoryFacade', 'getCallHistory', arguments);
};

dwr.engine._setObject("HistoryFacade", p);
}
})();

