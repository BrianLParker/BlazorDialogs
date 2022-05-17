# Blazor Dialogs

This library gives the html `<dialog>` element some Blazor love. 

### Add the nuget package.

### Import the library
**_Imports.razor**
```
@using BlazorDialogs
```
### Usage

```
<button @onclick=@ShowDialogAsync>Open Dialog</button>
 
<Dialog @ref=@dialog DialogClosed=@DialogClosedAsync >
	YOUR CONTENT
</Dialog>

@code {
    private Dialog dialog;

    async Task ShowDialogAsync() => await dialog.ShowDialogAsync();

    async Task DialogClosedAsync() { /* process content */ }
}
```

### How to open a dialog on a components initialization (pages are components).

Use your hosting components `OnAfterRenderAsync` method to show the dialog. This is required as the `@ref` is not initialized before this.
```
protected override async Task OnAfterRenderAsync(bool firstRender)
{
    if(firstRender is true)
    {
        await dialog.ShowDialogAsync();
        StateHasChanged();
    }
    await base.OnAfterRenderAsync(firstRender);
}
```
The component captures attributes and applies them to the underlying `<dialog>` element.
Included in the component are the following css classes.

<p>Available options:</p>
 
| class name | effect |
| -- | -- |
| <code>bd-back-blur3</code> | blurs content behind the dialog by 3 pixels |
| <code>bd-back-blur5</code> | blurs content behind the dialog by 5 pixels |
| <code>bd-back-blur10</code> | blurs content behind the dialog by 10 pixels |
| <code>bd-backdrop-blur3</code> | blurs content behind the backdrop of the dialog by 3 pixels |
| <code>bd-backdrop-blur5</code> | blurs content behind the backdrop of the dialog by 5 pixels |
| <code>bd-backdrop-blur10</code> | blurs content behind the backdrop of the dialog by 10 pixels |