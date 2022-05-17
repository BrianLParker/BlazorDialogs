// ------------------------------------------------------------
// Copyright (c) 2022, Brian Parker All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ------------------------------------------------------------

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorDialogs;

public partial class Dialog : ComponentBase, IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;
    private DotNetObjectReference<Dialog> dotNetObjectReference;
    private ElementReference dialogElement;

    public Dialog()
    {
        moduleTask = new(() => jsRuntime!.InvokeAsync<IJSObjectReference>(
            identifier: "import",
            args: "./_content/BlazorDialogs/dialogJsInterop.js")
        .AsTask());

        dotNetObjectReference = DotNetObjectReference.Create(this);
    }

    [Inject]
    private IJSRuntime jsRuntime { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> CapturedAttributes { get; set; }

    [Parameter]
    public EventCallback<bool> DialogClosed { get; set; }

    public bool IsDialogVisible { get; private set; } = false;

    public async ValueTask ShowDialogAsync()
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync(identifier: "showDialog", dialogElement, dotNetObjectReference);
        this.IsDialogVisible = true;
    }

    public async ValueTask CloseDialogAsync()
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync(identifier: "closeDialog", dialogElement);
        this.IsDialogVisible = false;
    }

    [JSInvokable]
    public void OnDialogClosed()
    {
        IsDialogVisible = false;
        DialogClosed.InvokeAsync(IsDialogVisible);
        StateHasChanged();
    }

    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}
