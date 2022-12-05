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
var cal_obj2 = null;
var format = '%m/%d/%Y';

// show calendar
function show_cal(el) {

	if (cal_obj2) return;

//var text_field = document.getElementById(el.id);

	cal_obj2 = new RichCalendar();
	cal_obj2.start_week_day = 0;
	cal_obj2.show_time = false;
	cal_obj2.language = 'en';
	cal_obj2.autoclose = true;
	cal_obj2.user_onchange_handler = cal2_on_change;
	cal_obj2.user_onclose_handler = cal2_on_close;
	cal_obj2.user_onautoclose_handler = cal2_on_autoclose;
    cal_obj2.target_obj=el;
	cal_obj2.parse_date(el.value , format);

	cal_obj2.show_at_element(el, "adj_right-bottom");
	cal_obj2.change_skin('');

}

// user defined onchange handler
function cal2_on_change(cal, object_code) {
	
if (object_code == 'day') {
		cal_obj2.target_obj.value=cal.get_formatted_date(format);
		cal.hide();
		cal_obj2 = null;
	}
}

// user defined onclose handler
function cal2_on_close(cal) {
	if (window.confirm('Are you sure to close the calendar?')) {
		cal.hide();
		cal_obj2 = null;
	}
}

// user defined onclose handler (used in pop-up mode - when auto_close is true)
function cal2_on_autoclose(cal) {
	cal_obj2 = null;
}