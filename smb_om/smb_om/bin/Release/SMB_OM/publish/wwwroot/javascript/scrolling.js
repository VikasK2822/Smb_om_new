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
/* ################################## FF Specific Rules ################################## */
var tbodys = document.getElementsByTagName('tbody');
var otbody;
for (var i = 0; i < tbodys.length; i++) {
    otbody = tbodys[i];
    if (otbody.className.indexOf('scrollingFF') > -1) {
        if(otbody.scrollHeight<=200) otbody.style.height="auto"; /* sets max-height for FF */
    }
}