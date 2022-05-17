// ------------------------------------------------------------
// Copyright (c) 2022, Brian Parker All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ------------------------------------------------------------

using BlazorDialogs;
using Microsoft.AspNetCore.Components;

namespace BlazorDialogs;

public partial class DialogCloseButton : ComponentBase
{
    [CascadingParameter]
    public Dialog Dialog { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> CapturedAttributes { get; set; } =
        new Dictionary<string, object>
        {
            { "style", "margin: 0; border: none; background-color: transparent; color: white;" }
        };

    private async Task CloseDialog() => await Dialog.CloseDialogAsync();

    
}