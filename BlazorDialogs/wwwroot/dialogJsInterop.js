// ------------------------------------------------------------
// Copyright (c) 2022, Brian Parker All rights reserved.
// Licensed under the MIT License.
// ------------------------------------------------------------

export function showDialog(element, parm) {   
    let dialog = element;
    let dotNetHelper = parm;
    dialog.addEventListener('close', () => {
        dotNetHelper.invokeMethodAsync('OnDialogClosed');
    });
    return element.showModal();
}

export function closeDialog(element, parm) {
    return element.close();
}
