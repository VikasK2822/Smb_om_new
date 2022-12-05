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
function toggleDisplay(elem, imgelem) {
    if (elem.style.display == 'none') {
        elem.style.display = '';
        imgelem.src='../../images/collapse.gif';
    }
    else {
    elem.style.display = 'none';
    imgelem.src='../../images/expand.gif';
    }
}