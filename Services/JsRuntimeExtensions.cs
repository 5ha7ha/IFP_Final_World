using Microsoft.JSInterop;

namespace TravelTheWorld.Services;

public static class JsRuntimeExtensions
{
    /// <summary>Calls a JS function; focus and scrolling are only decoration, so a JS problem never breaks the page.</summary>
    public static async Task TryInvokeVoidAsync(this IJSRuntime js, string identifier, params object?[] args)
    {
        try { await js.InvokeVoidAsync(identifier, args); }
        catch (JSException) { }
    }
}