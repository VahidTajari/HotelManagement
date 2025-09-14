using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BlazorServer.App.Utils;

public static class JSRuntimeExtensions
{
#pragma warning disable MA0137
    public static ValueTask ToastrSuccess(this IJSRuntime JSRuntime, string message)

    {
        return JSRuntime.InvokeVoidAsync("ShowToastr", "success", message);
    }

    public static ValueTask ToastrError(this IJSRuntime JSRuntime, string message)
    {
        return JSRuntime.InvokeVoidAsync("ShowToastr", "error", message);
    }
#pragma warning restore MA0137
}
