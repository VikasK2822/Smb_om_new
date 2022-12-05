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
function validationAdd(output, field, message) {
  // Variables
  var messageExists = false;
  var messageString = (message.string) ? message.string: message;
  var messageType = (message.type && message.type == 'success') ? 'success': 'error';
  var messageUnique = (message.unique && message.unique == true) ? true: false;
  
  // If output container does not have a list, add one
  if (!jQuery('#' + output + ' ul').length) {
      jQuery('<ul />').prependTo('#' + output);
  }

// If message is an object
  if (message.string) {
    // If message should only be displayed once
    if (messageUnique) {
      // For each existing message in list
      jQuery('#' + output + ' ul li').each(function () {
        // Check to see list string matches passed string
        if (! messageExists && jQuery(this).text() == messageString) {
          // Set variable if match found
          messageExists = true;
        }
      });
    }
    
    // If message already exist
    if (messageExists) {
      // If message is an error and input field is provided
      if (messageType == 'error' && field) {
        // Add error class to self and nearby label
        jQuery('#' + field).prevAll('label:first').andSelf().addClass('error');
      }
    }
  }
  
  // If message is not object, or is object and message doesn't exist
  // yet
  if (! message.string || (message.string && ! messageExists)) {
    // Append message to output
    //jQuery('<li />').html('Please review and correct the highlighted area(s) below.').appendTo('#' + output + ' ul');
    jQuery('<li class="error" id="' + output + '-' + field + '"/>').html(messageString).appendTo('#' + output + ' ul');
    
    // If message is an error and input field is provided
    if (messageType == 'error' && field) {
      // Modify message with class and add click/focus
      jQuery('#' + output + ' ul li:last').addClass('cursor').click(function () {
        jQuery('#' + field).focus();
      });
      
      // Add error class to self and nearby label
      // jQuery('#' +
      // field).prevAll('label:first').andSelf().addClass('error');
      jQuery('#' + field).parent().parent().prev().find('label:first').andSelf().addClass('error');
    }
  }
  
  // If message is an error and input field is provided
  if (! messageExists && messageType == 'error' && field) {
    // Add message to inline error container, if one exists nearby
    jQuery('<span />').html(messageString).appendTo(jQuery('#' + field).siblings('.inline-error'));
  }
  
  // Show alert container
  jQuery('#' + output).show();
}

function validationReset(form) {
  
  // Empty all alert containers,
  // and reset classes
  jQuery('#' + form + ' .alerts').removeClass().empty();
  
  // Empty all inline errors
  jQuery('#' + form + ' .inline-error').empty();
  
  // Remove error class from all
  // fields
  jQuery('#' + form + ' .error').removeClass('error');
  
  // Remove success class from all
  // fields
  jQuery('#' + form + ' .success').removeClass('success');
}

// Function to remove element level validations
// output = The form-level container
// field = The field you want removed
function validationRemove(output, field) {
  // Remove the validation from individual fields
  jQuery('#' + field).siblings('.inline-error').children().remove();
  jQuery('#' + field).prevAll('label:first').andSelf().removeClass('error');
  // jQuery('#' + field).siblings('.inline-error').hide();
  
  // Remove the validation from the form-level container
  if (field) {
    jQuery('#' + output + '-' + field).remove();
  } else {
    jQuery('#' + output + ' ul li').each(function () {
      if (! jQuery(this).attr('id')) {
        jQuery(this).remove();
      }
    });
  }
  
  // If there are no validations left in the form-level container, remove the error states.
  if (jQuery('#' + output + ' ul li').size() < 1) {
    jQuery('#' + output).removeClass('error');
    jQuery('#' + output).removeClass('alert');
  }
}