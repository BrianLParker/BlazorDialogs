// ------------------------------------------------------------
// Copyright (c) 2022, Brian Parker All rights reserved.
// Licensed under the MIT License.
// ------------------------------------------------------------

export function addCloseEventListener(dialog, dotNetHelper) {

    dialog.addEventListener('close', () => {
        dotNetHelper.invokeMethodAsync('OnDialogClosed');
    });

}

export function showDialog(dialog) {
    return dialog.showModal();
}

export function closeDialog(dialog) {
    return dialog.close();
}
