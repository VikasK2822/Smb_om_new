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
  tabs = new ddtabcontent("history-tabs");
  tabs.setpersist(true);
  tabs.setselectedClassTarget("link");
  tabs.init();
  tabs.expandit(0);

  // load history
  loadRepComments();
});

function loadRepComments() {
  var transactionId = $('#transactionId').val();
  dwr.engine.setAsync(true);

  HistoryFacade.getRepComments(transactionId, {
    callback: function (data, value) {
      var dispTransactionId;
      var html = '';
      var options = {
        year: 'numeric',
        month: 'numeric',
        day: 'numeric',
        hour: 'numeric',
        minute: 'numeric',
        second: 'numeric'
        //timeZoneName: 'short'
      };

      $(data).each(function (index, obj) {
        var timestamp = obj.timestamp;
        var categoryName = obj.categoryName;
        var stateName = obj.stateName;
        var reasonCodeName = obj.reasonCodeName;
        var userName = obj.userName;
        var transComment = obj.transComment;
        var categoryId = obj.categoryId;
        var stateId = obj.stateId;
        if (!(obj.categoryId == 110 && obj.stateId == 2)) {
          html += '<tr style="height: 25px">';
          if (obj.dispTransactionId != dispTransactionId) {
            html += '<td style="hardBreak">' + new Intl.DateTimeFormat('en-US', options).format(timestamp) + '</td>';
            html += '<td style="hardBreak">' + (userName != null ? userName : 'System') + '</td>';
          } else {
            html += '<td style="hardBreak">&nbsp;</td>';
            html += '<td style="hardBreak">&nbsp;</td>';
          }
          html += '<td style="hardBreak">' + (categoryName + (categoryId != 110 && stateId != 20 ? ' : ' + stateName : '') + (reasonCodeName != null ? ' : ' + reasonCodeName : '')) + '</td>';
          if (obj.dispTransactionId != dispTransactionId) {
            dispTransactionId = obj.dispTransactionId;
            html += '<td style="hardBreak">' + (transComment != null ? transComment : '') + '</td>';
          } else {
            html += '<td style="hardBreak">&nbsp;</td>';
          }
          html += '</tr>';
        }
      });
      $('#rep-comments-content').html(html);
    }
  });
}

function enableHistory() {

  loadSystemNotes();
  loadEmailHistory();
  loadCallHistory();
  loadSmsHistory();

  $("#loadHistory").removeClass("button-css");
  $("#loadHistory").attr("disabled", "disabled");
  $("#system_note_load").removeAttr("style");
  $("#order_history_load").removeAttr("style");
  $("#call_history_load").removeAttr("style");
  $("#email_history_load").removeAttr("style");
  $("#sms_history_load").removeAttr("style");

  $("#system_notes").removeClass("disabled");
  $("#order_history").removeClass("disabled");
  $("#call_history").removeClass("disabled");
  $("#email_history").removeClass("disabled");
  $("#sms_history").removeClass("disabled");
}

function loadSystemNotes() {
  var transactionId = $('#transactionId').val();
  dwr.engine.setAsync(true);

  HistoryFacade.getDispHistory(transactionId, {
    callback: function (data, value) {
      var dispTransactionId;
      var html = '';
      var options = {
        year: 'numeric',
        month: 'numeric',
        day: 'numeric',
        hour: 'numeric',
        minute: 'numeric',
        second: 'numeric'
        //timeZoneName: 'short'
      };

      $(data).each(function (index, obj) {
        var timestamp = obj.timestamp;
        var categoryName = obj.categoryName;
        var stateName = obj.stateName;
        var reasonCodeName = obj.reasonCodeName;
        var userName = obj.userName;
        var transComment = obj.transComment;
        var categoryId = obj.categoryId;
        var stateId = obj.stateId;
        html += '<tr style="height: 25px">';
        if (obj.dispTransactionId != dispTransactionId) {
          html += '<td style="hardBreak">' + new Intl.DateTimeFormat('en-US', options).format(timestamp) + '</td>';
          html += '<td style="hardBreak">' + (userName != null ? userName : 'System') + '</td>';
        } else {
          html += '<td style="hardBreak">&nbsp;</td>';
          html += '<td style="hardBreak">&nbsp;</td>';
        }
        html += '<td style="hardBreak">' + (categoryName + (categoryId != 110 && stateId != 20 ? ' : ' + stateName : '') + (reasonCodeName != null ? ' : ' + reasonCodeName : '')) + '</td>';
        if (obj.dispTransactionId != dispTransactionId) {
          dispTransactionId = obj.dispTransactionId;
          html += '<td style="hardBreak">' + (transComment != null ? transComment : '') + '</td>';
        } else {
          html += '<td style="hardBreak">&nbsp;</td>';
        }
        html += '</tr>';
      });
      $('#system-notes-content').html(html);
    }
  });
}

function loadEmailHistory() {
  var transactionId = $('#transactionId').val();
  $.ajax({
           url: "./view_email_history?transactionId=" + transactionId,
           async: false,
           cache: false
         }).done(function (html) {
    $('#email-history-content').html(html);
  });
}

function loadCallHistory() {
  var transactionId = $('#transactionId').val();
  dwr.engine.setAsync(true);

  HistoryFacade.getCallHistory(transactionId, {
    callback: function (data, value) {
      var html = '';
      var options = {
        year: 'numeric',
        month: 'numeric',
        day: 'numeric',
        hour: 'numeric',
        minute: 'numeric',
        second: 'numeric'
        //timeZoneName: 'short'
      };
      $(data).each(function (index, obj) {
        if (obj != null) {
          html += '<tr>';
          html += '<td style="hardBreak">' + (obj.callStartTime != null ? new Intl.DateTimeFormat('en-US', options).format(obj.callStartTime) : '') + '</td>';
          html += '<td style="hardBreak">' + (obj.callEndTime != null ? new Intl.DateTimeFormat('en-US', options).format(obj.callEndTime) : '') + '</td>';
          html += '<td style="hardBreak">' + (obj.callReason != null ? obj.callReason : '') + '</td>';
          html += '<td style="hardBreak">' + (obj.callDisposition != null ? obj.callDisposition : '') + '</td>';
          html += '<td style="hardBreak">' + (obj.requestComment != null ? obj.requestComment : '') + '</td>';
          html += '<td style="hardBreak">' + (obj.flexField2 != null ? obj.flexField2 : '') + '</td>';
          html += '</tr>';
        }
      });
      $('#call-history-content').html(html);
    }
  });
}

function loadSmsHistory() {
  var transactionId = $('#transactionId').val();
  $.ajax({
           url: "./view_sms_history?transactionId=" + transactionId,
           async: false,
           cache: false
         }).done(function (html) {
    $('#sms-history-content').html(html);
  });
}